# Filtering

An important part of the DD-ECO-API specification is filtering data.

There are already different filtering systems in existence, such as OData and GraphQL. These are, however, complex and hard to use, especially by non-IT persons.


The Filter Syntax provides a simple, flexible, but easy to learn alternative.

To query data, only one parameter is needed: filter=

## Data types and formats

The DD-ECO-API defines the following data types and formats:

Strings are surrounded by either single- or double quotes.

Dates are expressed in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.

Numbers use US notation. This means fractional separators are periods. Comma's (thousands-separators) are ignored.

The DD-ECO-API spec uses the so-called FilterSyntax to filter data.

The filter is specified using the filter= parameter.

FilterSyntax has the following structure:

## Standard comparers

&lt;parametername&gt;:&lt;comparer&gt;:&lt;comparevalue&gt;[;&lt;parametername&gt;:&lt;comparer&gt;:&lt;comparevalue&gt;]

The standard comparers are:

| Comparer | Description | Data types | Requirement |
|----------|-------------|------|----|
| eq | equal | string, date, number | Required |
| ne | not equal | string, date, number | Recommended |
| lt | less than | date, number | Recommended |
| le | less than or equal to | date, number | Recommended |
| ge | greater than or equal to | date, number | Recommended |
| gt | greater than | date, number | Recommended |
| in | item is one of the values in the list | array of string, array of number | Strongly recommended |
| notin | item is NOT one of the values in the list | array of string, array of number | Not required |
| like | String contains the value (is like). | string | Recommended |
| startswith | String starts with the value. | string | Recommended |
| endswith | String ends with the value. | string | Recommended |
| wkt | Item is within the Well-known-text=specified object | [Wkt](https://en.wikipedia.org/wiki/Well-known_text_representation_of_geometry) | Not required |
| geojson | Item is within the GeoJSON-specified object | [GeoJSON](https://en.wikipedia.org/wiki/GeoJSON) | Not required |
| bbox | Bounding box | array of number | Recommended |
| all | all items in the list must be present in the queried item | string, number | Not required |

The in- and notin operators allow logical OR comparisons within the property.

## Query examples

| Examples | Description |
| --- | --- |
| location&colon;eq&colon;"NLKAD";parameter&colon;eq&colon;"Eukariota";measuredvalue&colon;gt&colon;1000;measuredunit&colon;eq&colon;"n" | Find all Eukariota at location NLKAD where measured value > 1000 and the measurements where expressed in count (n) |
| location&colon;in&colon;["NKLAD","NKLBVA","NLKBRA"];parameter&colon;eq&colon;"Eukariota";measuredvalue&colon;gt&colon;1000;measuredunit&colon;eq&colon;"n" | Find all Eukariota at location NLKAD or NKLBVA or NLKBRA where measured value > 1000 and the measurements where expressed in count (n) |
| location&colon;in&colon;["NKLAD","NKLBVA","NLKBRA"];parameter&colon;in&colon;["Eukariota [1]","Plantae"];measuredvalue&colon;gt&colon;1000;measuredunit&colon;eq&colon;"n" | Find all Eukariota or Plantae at location NLKAD or NKLBVA or NLKBRA where measured value > 1000 and the measurements where expressed in count (n) |

## Custom comparers

Specific scenario's may require custom comparers.

An example: to retrieve alle measurements for Bristle worms (scientific name: Polychaeta), consisting of over 11.000 species, would take a huge number of requests as all species would be queried individually and the requester would need to know all names of the species.

For those scenario's the AquaDesk implementation created the custom tree operator (short for tree-of-life).

## Implementing Filter Syntax

The process of implementing the FilterSyntax may seem daunting, but may prove to be easier than it looks.

In most situations, it is sufficient to dynamically generate (database) queries based on the Filter Syntax.

## Parsing Filter Syntax

A C# project with code able to parse FilterSyntax can be found [here](/CSharp/DD-ECO-FilterParser/DD-ECO-FilterParser.csproj). It is written in C# 9.0 with the .NET CORE 3.1 runtime and uses no external packages.

For implementing wkt and geojson, external packages probably __are__ required.
