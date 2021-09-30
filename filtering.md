# Filtering

An important part of the DD-ECO-API specification is filtering data.

There are already different filtering systems in existence, such as OData and GraphQL. These are, however, complex and hard to use, especially by non-IT persons.


The Filter Syntax provides a simple, flexible, but easy to learn alternative.

To query data, only one parameter is needed: filter=

## Data types and formats

The DD-ECO-API defines the following data types and formats:

* Strings are surrounded by either single- or double quotes.

* Dates are expressed in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.

* Numbers use US notation. This means fractional separators are periods. Comma's (thousands-separators) are ignored.

## Filter Syntax

The DD-ECO-API spec uses the so-called Filter Syntax to filter data.

The filter is specified using the filter= parameter.

Filter Syntax has the following structure:

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


## Implementing Filter Syntax

The process of implementing the Filter Syntax is easier than it looks.

A sample implementation of the Filter Syntax is provided in C# using the .NET Core 3.1 runtime. It compiles under Windows, Linux and MacOS.

it should be relatively easy to convert to other languages such as Java, Python and Rust.

A library able to parse JSON is required.

Specific functionality, such as the wkt and geojson operators (optional) may require a specialized library to validate those values.

In most situations, it is sufficient to dynamically generate (database) queries based on the parsed query.

