<h2 align="center">Currency API Project</h2>

### Overview
This project focusing on building an API set that fetches current currency exchange rates from an online service. 
It includes methods to retrieve exchange rates for selected currencies and an API for currency conversion. 
Additionally, it provides an API to list all supported currencies.

### Features
- **Fetch Exchange Rates:** Retrieves current exchange rates for various currencies based on a specified base currency ('/currencies/convertToAll/{baseCurrency}').
- **Currency Conversion:** Converts a specified amount from one currency to another ('/currencies/convert/{baseCurrency}/{targetCurrency}/{amount}').
- **List All Currencies:** Lists all currencies available for exchange ('/currencies/all').
- **List Supported Currencies:** Retrieves a list of all currencies supported by the API ('/currencies/supported').

