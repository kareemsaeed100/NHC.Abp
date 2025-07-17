using Volo.Abp;

namespace NHC.Abp.Integration.Exceptions;

[Serializable]
internal class ClientCommunionException : AbpException
{

    /// <summary>
    /// Creates a new <see cref="ClientCommunionException"/> object.
    /// </summary>
    /// <param name="message">Exception message</param>
    public ClientCommunionException(string message)
        : base(message)
    {

    }

    /// <summary>
    /// Creates a new <see cref="ClientCommunionException"/> object.
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="innerException">Inner exception</param>
    public ClientCommunionException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
    public ClientCommunionException(string fullUrl, string message)
    {

    }
    public ClientCommunionException(string fullUrl, string HttpMethod, string message)
    {

    }
    public ClientCommunionException(string fullUrl, string httpMethod, string requestBody, string message)
    {

    }
    public ClientCommunionException(string fullUrl, string httpMethod, string requestBody, string response, string message)
    {

    }
}