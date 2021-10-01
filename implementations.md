# Implementations and Demo environments

## Current implementations of v2

| Organization | Provider | Version | Remarks |
|--------------|----------|---------|---------|
| [EcoSys](www.ecosys.nl) | [AquaDesk](#AquaDesk) (EcoSys) | v2.0 | In production. Supplies biological, chemical and physical data. Is source of the TWN list/TaxaInfo. |
| Wageningen Marine Research (WMR) | Wageningen Marine Research | v2.0 | Work in Progress. Provides fish data. Specific for RWS. |
| Stichting Vogelonderzoek (SOVON) | AquaDesk (EcoSys) | v2.0 | Work in Progress. Provides bird data. Specific for RWS. |

## Demonstration environments

## AquaDesk

Url: [https://ddecoapi.aquadesk.nl](https://ddecoapi.aquadesk.nl)

Schema: [https://ddecoapi.aquadesk.nl/swagger/v2/swagger.json](https://ddecoapi.aquadesk.nl/swagger/v2/swagger.json)

Security: parts are protected by API Keys (X-API-KEY in header).

Demo key: oZlevFrMkwMMbn0mHQJe2bHFjaQugbtzQmShi3imijU

Remarks:

All data, except for organization-specific data is open and free.
Organization data (measurements, measurement objects, notes, methods, monitoring networks) are protected by API keys, which can be obtained by contacting the organizations that own the data.
The demo key above gives access to fictive data of the EcoSys organization. This data will be expanded with subsets of real data contributed by the other organizations.

The DD-ECO-API implementation of AquaDesk is the official source of the TWN List (Taxa Waterbeheer Nederland) and is included in the /v2/parameters endpoint. Use filter=parametertype:eq:'TAXON' to get all TWN list entries.
