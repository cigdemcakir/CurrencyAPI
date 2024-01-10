namespace CurrencyAPI.Models;

public class CurrencyRatesResponse
{
    public bool Success { get; set; }
    public List<CurrencyRate> Result { get; set; }
}