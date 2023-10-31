using System.Net;

namespace Email_Validator_BackEnd.Services;

public class EmailValidatorService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public EmailValidatorService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> CheckEmailAsync(string email)
    {
        var apiKey = _configuration["ApiKey"];
        var encodedEmail = WebUtility.UrlEncode(email);
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://mailcheck.p.rapidapi.com/?domain={encodedEmail}"),
            Headers =
    {
        { "X-RapidAPI-Key", $"{apiKey}" },
        { "X-RapidAPI-Host", "mailcheck.p.rapidapi.com" },
    },
        };
        using (var response = await _httpClient.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}
