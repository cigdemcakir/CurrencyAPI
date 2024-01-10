using CurrencyAPI.Models;
using FluentValidation;

namespace CurrencyAPI.Validators;

public class ConvertCurrencyValidator : AbstractValidator<ConvertCurrencyQuery>
{
    public ConvertCurrencyValidator()
    {
        RuleFor(query => query.BaseCurrency)
            .NotEmpty().WithMessage("Base currency is required.")
            .Must(BeAValidCurrency).WithMessage("Invalid base currency code.");

        RuleFor(query => query.TargetCurrency)
            .NotEmpty().WithMessage("Target currency is required.")
            .Must(BeAValidCurrency).WithMessage("Invalid target currency code.");

        RuleFor(query => query.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");
    }

    private bool BeAValidCurrency(string currencyCode)
    {
        return currencyCode.Length == 3;
    }
}

public class ConvertCurrencyQuery
{
    public string BaseCurrency { get; set; }
    
    public string TargetCurrency { get; set; }
    
    public decimal Amount { get; set; }
}