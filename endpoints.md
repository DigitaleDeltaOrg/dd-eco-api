# /endpoints

The /endpoints endpoint lists the available services and the fields and comparers that the services know for filtering.
This endpoint _should_ be unprotected, so no API Key or OAUTH2 should be required to access this endpoint.

Example [endpoint](https://ddecoapi.aquadesk.nl/v2/endpoints).
Example response:

``` json
{
    "paging": {
        "self": "v2/endpoints?page=1&pagesize=10000&nocount=false",
        "prev": "",
        "next": "",
        "maxPageSize": 10000,
        "defaultPageSize": 10000,
        "minPageSize": 1,
        "totalObjectCount": 27
    },
    "provider": {
        "name": "EcoSys",
        "supportUrl": "www.ecosys.nl",
        "apiVersion": "2.0.0",
        "responseType": "EndPointsListResponse"
    },
    "result": [
        {
            "baseuri": "v2/compartments",
            "description": "Aquo compartments.",
            "methods": [
                "Get"
            ],
            "filters": [
                {
                    "fieldName": "code",
                    "comparer": "eq",
                    "dataType": "StringType",
                    "description": "Code of the entity."
                },
                {
                    "fieldName": "code",
                    "comparer": "ne",
                    "dataType": "StringType",
                    "description": "Code of the entity."
                },
                {
                    "fieldName": "code",
                    "comparer": "in",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the entity."
                },
                {
                    "fieldName": "code",
                    "comparer": "notin",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the entity."
                },
                {
                    "fieldName": "name",
                    "comparer": "eq",
                    "dataType": "StringType",
                    "description": "Name of the entity."
                },
                {
                    "fieldName": "name",
                    "comparer": "ne",
                    "dataType": "StringType",
                    "description": "Name of the entity."
                },
                {
                    "fieldName": "name",
                    "comparer": "like",
                    "dataType": "StringType",
                    "description": "Name of the entity."
                },
                {
                    "fieldName": "name",
                    "comparer": "startswith",
                    "dataType": "StringType",
                    "description": "Name of the entity."
                },
                {
                    "fieldName": "name",
                    "comparer": "endswith",
                    "dataType": "StringType",
                    "description": "Name of the entity."
                },
                {
                    "fieldName": "name",
                    "comparer": "in",
                    "dataType": "ArrayOfStringType",
                    "description": "Name of the entity."
                },
                {
                    "fieldName": "name",
                    "comparer": "notin",
                    "dataType": "ArrayOfStringType",
                    "description": "Name of the entity."
                },

            ]
        },
        {
            "baseuri": "v2/measurements",
            "description": "Measurements. Requires Api Key",
            "methods": [
                "Get",
                "Post"
            ],
            "filters": [
                {
                    "fieldName": "calculatedunit",
                    "comparer": "eq",
                    "dataType": "StringType",
                    "description": "Code of the unit the calculated value was expressed in."
                },
                {
                    "fieldName": "calculatedunit",
                    "comparer": "ne",
                    "dataType": "StringType",
                    "description": "Code of the unit the calculated value was expressed in."
                },
                {
                    "fieldName": "calculatedunit",
                    "comparer": "in",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the unit the calculated value was expressed in."
                },
                {
                    "fieldName": "calculatedunit",
                    "comparer": "notin",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the unit the calculated value was expressed in."
                },
                {
                    "fieldName": "calculatedvalue",
                    "comparer": "eq",
                    "dataType": "NumericType",
                    "description": "Calculated value."
                },
                {
                    "fieldName": "calculatedvalue",
                    "comparer": "ne",
                    "dataType": "NumericType",
                    "description": "Calculated value."
                },
                {
                    "fieldName": "calculatedvalue",
                    "comparer": "lt",
                    "dataType": "NumericType",
                    "description": "Calculated value."
                },
                {
                    "fieldName": "calculatedvalue",
                    "comparer": "le",
                    "dataType": "NumericType",
                    "description": "Calculated value."
                },
                {
                    "fieldName": "calculatedvalue",
                    "comparer": "gt",
                    "dataType": "NumericType",
                    "description": "Calculated value."
                },
                {
                    "fieldName": "calculatedvalue",
                    "comparer": "ge",
                    "dataType": "NumericType",
                    "description": "Calculated value."
                },
                {
                    "fieldName": "calculatedvalue",
                    "comparer": "in",
                    "dataType": "ArrayOfNumericType",
                    "description": "Calculated value."
                },
                {
                    "fieldName": "calculatedvalue",
                    "comparer": "notin",
                    "dataType": "ArrayOfNumericType",
                    "description": "Calculated value."
                },
                {
                    "fieldName": "compartment",
                    "comparer": "eq",
                    "dataType": "StringType",
                    "description": "Code of the compartment."
                },
                {
                    "fieldName": "compartment",
                    "comparer": "ne",
                    "dataType": "StringType",
                    "description": "Code of the compartment."
                },
                {
                    "fieldName": "compartment",
                    "comparer": "in",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the compartment."
                },
                {
                    "fieldName": "compartment",
                    "comparer": "notin",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the compartment."
                },
                {
                    "fieldName": "measuredunit",
                    "comparer": "eq",
                    "dataType": "StringType",
                    "description": "Code of the unit the measured value was expressed in."
                },
                {
                    "fieldName": "measuredunit",
                    "comparer": "ne",
                    "dataType": "StringType",
                    "description": "Code of the unit the measured value was expressed in."
                },
                {
                    "fieldName": "measuredunit",
                    "comparer": "in",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the unit the measured value was expressed in."
                },
                {
                    "fieldName": "measuredunit",
                    "comparer": "notin",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the unit the measured value was expressed in."
                },
                {
                    "fieldName": "measuredvalue",
                    "comparer": "eq",
                    "dataType": "NumericType",
                    "description": "Measured value."
                },
                {
                    "fieldName": "measuredvalue",
                    "comparer": "ne",
                    "dataType": "NumericType",
                    "description": "Measured value."
                },
                {
                    "fieldName": "measuredvalue",
                    "comparer": "lt",
                    "dataType": "NumericType",
                    "description": "Measured value."
                },
                {
                    "fieldName": "measuredvalue",
                    "comparer": "le",
                    "dataType": "NumericType",
                    "description": "Measured value."
                },
                {
                    "fieldName": "measuredvalue",
                    "comparer": "gt",
                    "dataType": "NumericType",
                    "description": "Measured value."
                },
                {
                    "fieldName": "measuredvalue",
                    "comparer": "ge",
                    "dataType": "NumericType",
                    "description": "Measured value."
                },
                {
                    "fieldName": "measuredvalue",
                    "comparer": "in",
                    "dataType": "ArrayOfNumericType",
                    "description": "Measured value."
                },
                {
                    "fieldName": "measuredvalue",
                    "comparer": "notin",
                    "dataType": "ArrayOfNumericType",
                    "description": "Measured value."
                },
                {
                    "fieldName": "measurementdate",
                    "comparer": "eq",
                    "dataType": "DateType",
                    "description": "The date the measurement was performed (yyyy-MM-dd)."
                },
                {
                    "fieldName": "measurementdate",
                    "comparer": "ne",
                    "dataType": "DateType",
                    "description": "The date the measurement was performed (yyyy-MM-dd)."
                },
                {
                    "fieldName": "measurementdate",
                    "comparer": "lt",
                    "dataType": "DateType",
                    "description": "The date the measurement was performed (yyyy-MM-dd)."
                },
                {
                    "fieldName": "measurementdate",
                    "comparer": "le",
                    "dataType": "DateType",
                    "description": "The date the measurement was performed (yyyy-MM-dd)."
                },
                {
                    "fieldName": "measurementdate",
                    "comparer": "gt",
                    "dataType": "DateType",
                    "description": "The date the measurement was performed (yyyy-MM-dd)."
                },
                {
                    "fieldName": "measurementdate",
                    "comparer": "ge",
                    "dataType": "DateType",
                    "description": "The date the measurement was performed (yyyy-MM-dd)."
                },
                {
                    "fieldName": "measurementobject",
                    "comparer": "eq",
                    "dataType": "StringType",
                    "description": "Code of the measurement object."
                },
                {
                    "fieldName": "measurementobject",
                    "comparer": "ne",
                    "dataType": "StringType",
                    "description": "Code of the measurement object."
                },
                {
                    "fieldName": "measurementobject",
                    "comparer": "in",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the measurement object."
                },
                {
                    "fieldName": "measurementobject",
                    "comparer": "notin",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the measurement object."
                },
                {
                    "fieldName": "measurementpackage",
                    "comparer": "eq",
                    "dataType": "StringType",
                    "description": "Code of the measurement package."
                },
                {
                    "fieldName": "parameter",
                    "comparer": "eq",
                    "dataType": "StringType",
                    "description": "Code of the parameter."
                },
                {
                    "fieldName": "parameter",
                    "comparer": "ne",
                    "dataType": "StringType",
                    "description": "Code of the parameter."
                },
                {
                    "fieldName": "parameter",
                    "comparer": "like",
                    "dataType": "StringType",
                    "description": "Code of the parameter."
                },
                {
                    "fieldName": "parameter",
                    "comparer": "startswith",
                    "dataType": "StringType",
                    "description": "Code of the parameter."
                },
                {
                    "fieldName": "parameter",
                    "comparer": "endswith",
                    "dataType": "StringType",
                    "description": "Code of the parameter."
                },
                {
                    "fieldName": "parameter",
                    "comparer": "in",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the parameter."
                },
                {
                    "fieldName": "parameter",
                    "comparer": "notin",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the parameter."
                },
                {
                    "fieldName": "parametertype",
                    "comparer": "notin",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the parameter type."
                },
                {
                    "fieldName": "quantity",
                    "comparer": "eq",
                    "dataType": "StringType",
                    "description": "Code of the quantity."
                },
                {
                    "fieldName": "quantity",
                    "comparer": "ne",
                    "dataType": "StringType",
                    "description": "Code of the quantity."
                },
                {
                    "fieldName": "quantity",
                    "comparer": "in",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the quantity."
                },
                {
                    "fieldName": "quantity",
                    "comparer": "notin",
                    "dataType": "ArrayOfStringType",
                    "description": "Code of the quantity."
                }
            ],
            "security": "apikey"
        }
   ]
}
```
