using CurrencyAPI.Services;
using CurrencyAPI.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyAPI.Controllers;

[ApiController]
[Route("[controller]s")]
public class CurrencyController : ControllerBase
{
    private readonly CurrencyService _currencyService;


    public CurrencyController(CurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    // Get all currency rates against a specific currency
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCurrencies()
    {
        try
        {
            var rates = await _currencyService.GetAllCurrencyRatesAsync();
            return Ok(rates);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    
    // Get exchange rates of all currencies against a specified base currency
    [HttpGet("convertToAll/{baseCurrency}")]
    public async Task<IActionResult> GetCurrencyToAllRates(string baseCurrency)
    {
        var query = new GetCurrencyToAllRatesQuery { BaseCurrency = baseCurrency };
        
        var validationResult = new GetCurrencyToAllRatesValidator().Validate(query);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }
        
        try
        {
            var conversionResult = await _currencyService.GetCurrencyToAllRatesAsync(baseCurrency);
            return Ok(conversionResult);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    // Convert a specific amount from one currency to another
    [HttpGet("convert/{baseCurrency}/{targetCurrency}/{amount}")]
    public async Task<IActionResult> ConvertCurrency(string baseCurrency, string targetCurrency, decimal amount)
    {
        var query = new ConvertCurrencyQuery
        {
            BaseCurrency = baseCurrency, 
            TargetCurrency = targetCurrency, 
            Amount = amount
        };
    
        var validationResult = await new ConvertCurrencyValidator().ValidateAsync(query);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }
    
        try
        {
            var conversionResult = await _currencyService.ConvertCurrencyAsync(baseCurrency, targetCurrency, amount);
            return Ok(conversionResult);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    
    // Endpoint to get a list of supported currencies
    [HttpGet("supported")]
    public async Task<IActionResult> GetSupportedCurrencies()
    {
        try
        {
            var currencies = await _currencyService.GetSupportedCurrenciesAsync();
            return Ok(currencies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}