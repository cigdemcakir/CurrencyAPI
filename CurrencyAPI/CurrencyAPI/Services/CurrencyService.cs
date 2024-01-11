using CurrencyAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using RestSharp;

namespace CurrencyAPI.Services;

public class CurrencyService
{
    private readonly RestClient _restClient;

    private readonly string _apiKey;

    public CurrencyService(IConfiguration configuration)
    {
        _apiKey = configuration["CollectAPI:APIKey"];
        
        _restClient = new RestClient("https://api.collectapi.com/economy");
    }
    
    private RestRequest CreateRequest(string resource)
    {
        var request = new RestRequest(resource);
        request.AddHeader("authorization",  _apiKey);
        request.AddHeader("content-type", "application/json");
        return request;
    }

    // Get exchange rate information
    public async Task<List<CurrencyRate>> GetAllCurrencyRatesAsync()
    {
        var request = CreateRequest("/allCurrency");
        
        var response = await _restClient.ExecuteAsync(request);
        
        if (response.IsSuccessful)
        {
            var resultObject = JsonConvert.DeserializeObject<CurrencyRatesResponse>(response.Content);
            return resultObject.Result;
        }
        else
        {
            throw new Exception("API call failed: " + response.ErrorMessage);
        }
    }
    
    // Get the exchange rates of all currencies against a specified base currency
    public async Task<string> GetCurrencyToAllRatesAsync(string baseCurrency)
    {
        var request = CreateRequest($"/currencyToAll?int=10&base={baseCurrency}");
        
        var response = await _restClient.ExecuteAsync(request);
        
        if (response.IsSuccessful)
        {
            var result = JsonConvert.DeserializeObject<ConversionResponse>(response.Content);
            return response.Content; 
        }
        else
        {
            throw new Exception("API call failed:" + response.ErrorMessage);
        }
    }

    // Convert a specific amount from one currency to another
    public async Task<string> ConvertCurrencyAsync(string baseCurrency, string targetCurrency, decimal amount)
    {
        var request = CreateRequest($"/exchange?base={baseCurrency}&to={targetCurrency}&int={amount}");

        var response = await _restClient.ExecuteAsync(request);
        
        if (response.IsSuccessful)
        {
            return response.Content;
        }
        else
        {
            throw new Exception("API call failed:" + response.ErrorMessage);
        }
    }
    
    // Retrieve a list of supported currencies from the CollectAPI /symbols endpoint
    public async Task<List<SupportedCurrency>> GetSupportedCurrenciesAsync()
    {
        var request = CreateRequest("/symbols");
        
        var response = await _restClient.ExecuteAsync(request);
        
        if (response.IsSuccessful)
        {
            var result = JsonConvert.DeserializeObject<SupportedCurrenciesResponse>(response.Content);
            return result.Result;
        }
        else
        {
            throw new Exception("API call failed:" + response.ErrorMessage);
        }
    }
}
