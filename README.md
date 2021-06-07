# Digital Delta Eco specification

This specification describes the Digital Delta Eco API (DD-ECO-API). It is meant for both [implementers](implementations.md) and [consumers](consumers.md) of the Digital Delta Eco specification.

It replaces [the older specification](https://github.com/DigitaleDeltaOrg/dd-eco-api-specs), which is *archived* and considered *obsolete*.

The DD-ECO-API v2.0 specification is written in [OpenAPI](https://www.openapis.org/) version 3.0.1. This makes viewing and interpreting the specification easier. It also opens the doors to more documentation- and code-generator tools.

v2.0 ia an extension of v1.0. The new features are entirely optional.

A minimal implementation of the DD-ECO-API can be viewed [here](https://redocly.github.io/redoc/?url=https://raw.githubusercontent.com/DigitaleDeltaOrg/dd-eco-api/main/OpenAPI/minimal.json).

A full implementation of the AquaDesk provider, as an example, can be viewed [here](https://redocly.github.io/redoc/?url=https://ddecoapi.aquadesk.nl/swagger/v2/swagger.json).

The new features include:

- [nocount](parameters.md#nocount) parameter
- [skipproperties](parameters.md#skipproperties) parameter
- [shape](parameters.md#shape) parameter
- Formalization of [content compression](content.md#contentcompression)

## About the Digital Delta Eco specification

The DD-ECO-API is a specification of a REST service to **retrieve** ecological data. However, it is not **limited** to ecological data. It is capable of handling biological, chemical, and physics-related data.

While the DD-API focusses on time series (data that in time only differs in the measured value), the DD-ECO-API focusses on observations, which also deals with sampling, preparation, measurement and (re)calculation.

A short description on ecological measurements and what makes it difference can be found [here](ecological-measurements.md).

Since ecology is diverse, in that no two ecological research projects may require the exact same data to be registered, the DD-ECO-API specification focusses on formalizing functionality and structure, but provides suggestions for properties to make the data useful (make information from data).

In the DD-ECO-API spec therefor describes:

- Minimal [requirements](requirements.md) and suggestions.
- How to find the data ny [filtering](filtering.md).
- How to [paginate](pagination.md) the responses.
- How to produce and control [output](output.md).
- How to protect [data](security.md).
- How to handle [errors](error-handling.md).
- Definition of [minimal information](minimal-measurement.md) required to make measurements meaningful.

The full list of requirements and recommendations are described [here](requirements.md).

The [Current implementations](implementations.md) page lists the current implementations of DD-ECO-API v2 with their current status.
The [Consumers](consumers.md) page provides a list of current consumers and the implementations they use.

## Authors

- **Geri Wolters** - *Initial work*, Maintainer - [EcoSys](https://www.ecosys.nl)
- **Stef Hummel** - *Initial work* - [Deltares](https://www.deltares.nl)

See also the list of [contributors](contributors.md) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](license.md) file for details
