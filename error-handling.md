# Error handling

When errors are encountered, error information is provided as follows: The HTTP status code is set to be a value between 400 and 499. The response body has the structure of the Problem type:

``` json
{
  "type": "Filter query syntax",
  "title": "Query syntax",
  "typeinfo": null,
  "status": 400,
  "detail": "See 'errors' attribute.",
  "ìnstance": null,
  "errors": [
      {
          "errortype": "InvalidValue",
          "context": "symbol:eq:"
      }
  ]
}
```

The value of field 'type' contains an error message. The value of field 'typeinfo' is optional and can contain a link to a page explaining the message. The value of field 'title' contains the title of the message. The value of field 'status' has contains the HTTP status code. The value of field 'detail' can provide extra information, such as given in the example. The value of field 'instance' is optional and can contain information that identifies the error and request at the provider. The field 'errors' is optional and can contain further information concerning the error. In the example, it explains what is wrong with the query syntax.
