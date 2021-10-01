# Output

The output of a query is always a JSON response.
By default, properties with a null value are excluded from the output, to reduce the size of the resulting response.

This leads to responses that do not always have the same number of columns.

This is not a problem for JSON, but for some coding styles, it might.

The content _can_ be [compressed](content-compression.md) if the consumer requests it AND the provider supports it.

## Paging block

The paging block is the first data block in the responses. It returns parameters concerning the query, such as page, pagesize, maximum values, number of items conforming to the filter response, the _relative_ url to the current, previous and next page. The structure is:

``` json
    "paging": {
        "self": "v2/endpoints?page=1&pagesize=10000&nocount=false",
        "prev": "",
        "next": "",
        "maxPageSize": 10000,
        "defaultPageSize": 10000,
        "minPageSize": 1,
        "totalObjectCount": 27
    }
```

If the provider implements [nocount](parameters.md#nocount) and the client specifies nocount=true, totalObjectCount _must_ be omitted.
self _must_ always be specified.
prev and next _must_ contain the relative links if there is respectively a previous or next page and the value should be the relative url of that page. The provided parameters _must_ be part of the url.

## Provider block

The provider block specifies information about the specific provider and is always the second block in the output.
The block content is:

``` json
    "provider": {
        "name": "<provider name>",
        "supportUrl": "<url to provide support by the provider>",
        "apiVersion": "<version of the api>",
        "responseType": "<type of the response, for parsing the content>"
    }
```

## Response block

The response block is the third and last block in the output response and consists of a simple JSON array of 'records'. It can consist of a collection of key/value pairs, key/array pairs or key/structure pairs.
The contents are up to the provider and the depend on the selected endpoint. 

The consumer has some control over the structure of the response by using the [skipproperties](parameters.md#skipproperties) and [shape](parameters.md#shape) properties.
