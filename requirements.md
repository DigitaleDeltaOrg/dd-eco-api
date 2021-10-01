# Requirements and recommendations

## Notes

_must_ and _required_ means that the implementation of this is mandatory.
_should_ means that the implementation of this is optional, but recommended.

## Measurements

A minimal measurement _should_ consist of at least the following properties are strongly recommended:

- measurementdate: (when was the measurement taken)
- measurementlocation: (where was the measurement taken)
- unit: the unit that the measured value was expressed in. Examples are: n (amount, counted), kg (mass), cm (length), abundance (items/m2)
- quantity: the quantity that the measurement described. Examples are: height, length, concentration, acidity (pH), visibility
- parameter: the parameter that was measured. Examples: chloride, phytoplankton, oxygen. An example where parameter is not required, is quantity visibility
- measuredvalue: the measured value. This does not always need to be numeric. Example where non-numeric values are used are color, odor, visibility (good, poor)
- compartment: the compartment in which the measurement took place, for instance surface water, air, shore

It is _recommended_ that measurements have:

- externalkey: specifies an immutable 'id' or the entity, something consumers can depend on. It is recommended to _never_ use internal keys.
- changedate: specified when the measurement was most recently changed (added, updated).

Units, quantities, parameters, measured values and compartments _should_ be conform the [AQUO](https://www.aquo.nl/index.php/Categorie:Actueel) standard *where possible*.
Dates _must_ be in [ISO 8601 format](https://www.iso.org/iso-8601-date-and-time-format.html).

## Endpoints

- An endpoint named /v&lt;version&gt;/endpoints is _required_, which lists the available endpoints known by the server.
- An endpoint named /v&lt;version&gt;/measurements is _required_. This will return measurements (the goal of this API specification). There will be data directly referencing other endpoints: /measurements should provide all relevant data by itself.
- All other endpoints are considered Discovery endpoints and optional, giving more specific information on entities used in the /measurements endpoint.
- All endpoints (except /endpoints itself) _should_ provide a sub-endpoint called [/filters](filtersendpoint.md). The purpose of [/filters](filtersendpoint.md) is to return a list of known fields that can be used for filtering, together with the comparers they support for the specific fields. This is essential for the consumer.
- All non-error-responses (except for /filters sub-endpoints) _must_ use the same structure: first a [paging](output.md#paging-block) block, then the [provider](output.md#provider-block) block and lastly the [results](output.md#result-block) block.
- All endpoints (except /filters sub-endpoints) _must_ implement the specified [pagination](pagination.md) algorithm.
- All error responses _must_ adhere to the [error response](error-handling.md) specification.
- The provider _should_ provide their version of the DD-ECO-API specification as an OAS 3.x in JSON format.
- The provider _should_ provide an easy-to-reach (and find!) demo-environment of their implementation (either free or protected by an API key) and notify the DD-ECO-API maintainers of the URI of the implementation. This can also be used for compliancy tests or for testing what implications future features have.
- The provider _should_ implement [content compression](content-compression.md).
- The provider _should_ implement [content security](security.md) for non- or semi public data.
- The provider _should_ implement a method to retrieve what entities where removed since a specific date (/removed sub-endpoint).

## Discovery

The service _should_ provide endpoints that specify what entities are known and provided by the service. 

The following endpoints _should_ be available:

- /quantities
- /parameters
- /units

It is _recommended_ to have the following endpoints:

- /compartments
- /measurementobjects (locations)


## GET and POST

Primarily, the DD-ECO-API only supports GET requests. However, in some circumstances the data that need to be passed to the DD-ECO-API is more than either the client can send or the provider can receive. 

An example of this is a very detailed WKT or GeoJSON definition for an area. This can yield data in the megabyte ranges, well over the safe transmission limits (about 2K).

In these cases, where the provider can consider allowing the client to pass the filter through the body by using a POST.

The usage of a POST may seem contradicting, since a POST means that a resource needs to be created. 

However, passing Filter Syntax can be considered creating a resource, namely a search context. POST does not define that a permanent resource needs to be created.

