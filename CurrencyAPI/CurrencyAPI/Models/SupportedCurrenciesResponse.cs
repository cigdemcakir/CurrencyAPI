namespace CurrencyAPI.Models;

public class SupportedCurrenciesResponse
{
    public bool Success { get; set; }
    
    public List<SupportedCurrency> Result { get; set; }
}