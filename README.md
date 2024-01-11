<h2 align="center">Currency API Project</h2>

### Overview
This project focusing on building an API set that fetches current currency exchange rates from an online service. 
It includes methods to retrieve exchange rates for selected currencies and an API for currency conversion. 
Additionally, it provides an API to list all supported currencies.

https://github.com/cigdemcakir/Patika-CurrencyAPI/assets/102484836/64b78319-6e7a-4d9f-abbc-a5dc4a2bbf8b

### External API Service - Collect API

This project utilizes the Collect API to access real-time currency exchange data. Collect API is a comprehensive source for financial data, offering a wide range of information including current currency exchange rates. Integration with this service ensures that the project can provide accurate and up-to-date currency information, vital for conversion features and financial data accuracy.

### Features
- **Fetch Exchange Rates:**

Retrieves current exchange rates for various currencies based on a specified base currency ('/currencies/convertToAll/{baseCurrency}').

- **Currency Conversion:**

Converts a specified amount from one currency to another ('/currencies/convert/{baseCurrency}/{targetCurrency}/{amount}').

- **List All Currencies:**

Lists all currencies available for exchange ('/currencies/all').

- **List Supported Currencies:**

Retrieves a list of all currencies supported by the API ('/currencies/supported').

- **Data Validation with Fluent Validation:**
  
This project employs the Fluent Validation library to implement robust data validation. Fluent Validation is a popular .NET library used for building strongly-typed validation rules in an intuitive and concise manner. The validators in this project ensure the integrity of the data being processed, particularly for currency conversion requests.

- **Logging and Exception Handling:**
  
The project integrates advanced logging and custom exception middleware to enhance monitoring and error management. Logging tracks detailed information for every API request and response, aiding in issue diagnosis and performance optimization. The custom exception middleware uniformly handles uncaught exceptions, ensuring they are appropriately logged and responded to, thus maintaining the API's stability and reliability.

<div align="center">
    <img width="704" alt="Screenshot 2024-01-11 at 15 17 55" src="https://github.com/cigdemcakir/Patika-CurrencyAPI/assets/102484836/2202341e-b5eb-4669-b439-44c8d27f4b4b">
</div>


