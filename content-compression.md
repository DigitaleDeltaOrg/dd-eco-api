# Content compression

JSON responses, being text-based in nature, tend to have large responses. This takes up memory, processing power and bandwidth.
To address this, the content can be compressed with a standard protocols. Modern browsers will try to do this automatically.

This functionality is optional, but recommended, as the overhead of the compression is low, but the gains in traffic and response times are substantial.

When the consumer supplies the request header Accept-Encoding the server _should_ honor the request when one of the following compression methods is supplied:

- [deflate](https://en.wikipedia.org/wiki/Deflate)
- [gzip](https://en.wikipedia.org/wiki/Gzip) (recommended)
- [br](https://en.wikipedia.org/wiki/Brotli) (brotli, highly recommended)

When the provider supports the requested compression method, the provider should compress the response according to the requested compression method and add a Content-Encoding header with the compression method used for compression to the client.

Most frameworks will be able to compress data with the above compression algorithms.
