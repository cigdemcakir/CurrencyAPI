namespace CurrencyAPI.Models;

public class CurrencyData
{
    public string Code { get; set; }
    
    public string Name { get; set; }
    
    public decimal Rate { get; set; }
    
    public string CalculatedStr { get; set; }
    
    public decimal Calculated { get; set; }
}