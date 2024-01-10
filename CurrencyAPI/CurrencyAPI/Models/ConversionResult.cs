namespace CurrencyAPI.Models;

public class ConversionResult
{
    public string Base { get; set; }
    
    public string LastUpdate { get; set; }
    
    public List<CurrencyData> Datas { get; set; }
}