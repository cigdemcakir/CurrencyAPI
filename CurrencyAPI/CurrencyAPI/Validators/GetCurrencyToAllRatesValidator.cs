using FluentValidation;

namespace CurrencyAPI.Validators;

public class GetCurrencyToAllRatesValidator:AbstractValidator<GetCurrencyToAllRatesQuery>
{
    public GetCurrencyToAllRatesValidator()
    {
        RuleFor(query => query.BaseCurrency)
            .NotEmpty().WithMessage("Base currency is required.")
            .Must(BeAValidCurrency).WithMessage("Invalid currency code.");
    }

    private bool BeAValidCurrency(string currencyCode)
    {
        // "USD", "EUR" ...
        return currencyCode.Length == 3; 
    }
}

public class GetCurrencyToAllRatesQuery
{
    public string BaseCurrency { get; set; }
}