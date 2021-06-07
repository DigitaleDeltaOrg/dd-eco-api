# Pagination

Pagination is important for results sets that have potentially a large amount of items in them.
Therefor, implementation of a paging algorithm is required. But even paging algorithms can differ per implementation, yielding unexpected results.
To avoid confusion and undesired results, the DD-ECO-API defines the behavior of the paging algorithm.

Three items determine the query results:

- page parameter (starts with 1)
- pagesize parameter (minimum is 1, defaults and max are determined by the provider)
- filter parameter (defaults to empty). If defines the query filter.

The paging logic is as follows:

1. Apply the filter to the data.
2. Skip (pagesize * (page - 1) rows.
3. Return (pagesize) records.

A consumer can therefor assume (and depend on) the following:

- If the number of results returned is less than pagesize, there will be no more pages to be retrieved, so the end of the result set is reached.
