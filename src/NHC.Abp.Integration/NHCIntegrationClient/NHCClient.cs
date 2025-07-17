using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NHC.Abp.Integration.Exceptions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Settings;
namespace NHC.Abp.Integration.NHCIntegrationClient;

internal interface INHClient
{
    Task<NHCBaseResponse<TResponse>> GetAsync<TResponse>(
        string methodUri,
        Dictionary<string, string>? urlParam = null,
        Dictionary<string, string>? headers = null);
}

internal class NHCClient : INHClient, ITransientDependency
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ISettingProvider _settingProvider;
    private readonly ILogger<NHCClient> _logger;

    public NHCClient(
        IHttpClientFactory httpClientFactory,
        ISettingProvider settingProvider,
        ILogger<NHCClient> logger)
    {
        _httpClientFactory = httpClientFactory;
        _settingProvider = settingProvider;
        _logger = logger;
    }

    public async Task<NHCBaseResponse<TResponse>> GetAsync<TResponse>(
        string methodUri,
        Dictionary<string, string>? urlParam = null,
        Dictionary<string, string>? headers = null)
    {
        var baseUrl = await _settingProvider.GetOrNullAsync(NhcClientSetting.BaseUrl);
        methodUri = AddUrlParams(methodUri, urlParam);
        var fullUrl = baseUrl + methodUri;

        try
        {
            var client = _httpClientFactory.CreateClient();

            await AddHeadersAsync(client, headers);

            _logger.LogInformation("Requesting to {Url}. Headers: {Headers}", fullUrl, System.Text.Json.JsonSerializer.Serialize(client.DefaultRequestHeaders));

            var httpResponse = await client.GetAsync(new Uri(fullUrl));
            var content = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
            {
                _logger.LogInformation("Request to {Url} succeeded. Response: {Response}", fullUrl, content);

                var response = JsonConvert.DeserializeObject<NHCBaseResponse<TResponse>>(content);
                return response!;
            }

            _logger.LogError("Request to {Url} failed. StatusCode: {StatusCode}. Response: {Response}",
                fullUrl, httpResponse.StatusCode, content);

            throw new ClientCommunionException($"Request to {fullUrl} failed.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Request to {Url} failed.", fullUrl);
            throw new ClientCommunionException($"Request to {fullUrl} failed.");
        }
    }

    private static string AddUrlParams(string url, Dictionary<string, string>? urlParam)
    {
        if (urlParam is null || urlParam.Count == 0)
            return url;

        url += "?" + string.Join("&", urlParam.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));
        return url;
    }

    private async Task AddHeadersAsync(HttpClient client, Dictionary<string, string>? headers)
    {
        var clientId = await _settingProvider.GetOrNullAsync(NhcClientSetting.ClientId);
        var clientSecret = await _settingProvider.GetOrNullAsync(NhcClientSetting.ClientSecret);
        var refId = await _settingProvider.GetOrNullAsync(NhcClientSetting.RefId);

        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Add("X-IBM-Client-Id", clientId);
        client.DefaultRequestHeaders.Add("X-IBM-Client-Secret", clientSecret);
        client.DefaultRequestHeaders.Add("RefId", refId);

        if (headers is not null)
        {
            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}
