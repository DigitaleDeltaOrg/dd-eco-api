# Security

The DD-ECO-API can be protected using the following methods:

- Using API keys, by using the X-API-KEY header
- Using OAUTH2
- No protection

Which method to use is up to the provider. It can be specified per endpoint.
The /endpoints and /filters endpoint _should_ be left unprotected.

The DD-ECO-API should require at least [TLS](https://en.wikipedia.org/wiki/Transport_Layer_Security) 1.3.
