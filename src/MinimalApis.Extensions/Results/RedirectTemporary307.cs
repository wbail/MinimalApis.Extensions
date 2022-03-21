﻿using MinimalApis.Extensions.Metadata;

namespace MinimalApis.Extensions.Results;

/// <summary>
/// Represents an <see cref="IResult"/> for a <see cref="StatusCodes.Status307TemporaryRedirect"/> redirect response.
/// </summary>
public class RedirectTemporary307 : ResultBase, IProvideEndpointResponseMetadata
{
    private const int ResponseStatusCode = StatusCodes.Status307TemporaryRedirect;

    /// <summary>
    /// Initializes a new instance of the <see cref="RedirectTemporary307"/> class.
    /// </summary>
    /// <param name="uri">The URI to redirect to.</param>
    public RedirectTemporary307(string uri)
    {
        StatusCode = ResponseStatusCode;
        Uri = uri;
    }

    /// <summary>
    /// The URI to redirect to.
    /// </summary>
    public string Uri { get; init; }

    /// <inheritdoc />
    public override Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.Headers.Location = Uri;

        return base.ExecuteAsync(httpContext);
    }

    /// <summary>
    /// Provides metadata for parameters to <see cref="Endpoint"/> route handler delegates.
    /// </summary>
    /// <param name="endpoint">The <see cref="Endpoint"/> to provide metadata for.</param>
    /// <param name="services">The <see cref="IServiceProvider"/>.</param>
    /// <returns>The metadata.</returns>
    public static IEnumerable<object> GetMetadata(Endpoint endpoint, IServiceProvider services)
    {
        yield return new Mvc.ProducesResponseTypeAttribute(ResponseStatusCode);
    }
}
