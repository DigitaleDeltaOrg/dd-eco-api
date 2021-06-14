# Parameters

The following parameters are defined in the DD-ECO-API.

| Parameter | Purpose | Required | Default | Remarks |
|-----|-----|-----|-----|-----|
| [page](#page) | Define the page number to retrieve | Yes | 1 | Minimum page size is 1 |
| [pagesize](#pagesize) | Define the page size (number of 'records') to retrieve | Yes | Provider specified | Cannot be less than 1 |
| [filter](#filter) | Specifies the filter for filtering the data | No | | |
| [nocount](#nocount) | Specifies if totalObjectCount should be calculated and provided | No | False | Boolean value: True or False |
| [skipproperties](#skipproperties) | Specifies fields to exclude from the results response | No | | List of strings |
| [shape](#shape) | Specifies fields to include in the results response | No | | List of strings |
| [sort](#sort) | Specifies the sort order and sort direction of the response | No | | List of fields with direction |

## page

See [Pagination](pagination.md).

## pagesize

See [Pagination](pagination.md).

## filter

See [Filtering](filtering.md).

## nocount

Note: implementing sorting is _optional_.
The `nocount` parameter accepts a boolean (true or false) and controls whether not not the `totalobjectcount` property in the paging block will be present.
This parameter can be useful to improve on performance, since the server does not need to query the whole data set. This parameter is optional and the default behavior is to include the `totalobjectcount` property, so the default value is true.

## skipproperties

Note: implementing sorting is _optional_.
The `skipproperties` parameter provides a mechanism to exclude the specified fields from the results..
Example:
`&skipproperties=id,changedate`

This would remove the fields `id` and `changedate` from the response.
The consumer cannot define the order of the fields. This is up to the server.

## shape

Note: implementing `shape` is _optional_.
The `shape` parameter provides a mechanism to define what fields the response consists of.
When the consumer specified a field that the provider doesn't know, it _must_ be supplied by the provider with a null value.
The consumer cannot define the order of the fields. This is up to the server.

Example:

`shape=id,code,name,unknown`

## sort

Note: implementing sorting is _optional_.
The `sort` parameter defines the sort order of the results. It comprises of a list of field name and sort direction. Possible values of the sort direction is ASC (for ascending) and DESC (for descending).

Example:

`sort=changedate ASC,status DESC`
