
INTRODUCTION
------------------------------------------------------------------------------------------------------------------------
This is a simple .NET Core Project which calculate the tax amount of municipality.

------------------------------------------------------------------------------------------------------------------------

RUNNING THE SERVICE APP
------------------------------------------------------------------------------------------------------------------------
Set MunicipalityTaxes as startup project.

Code will start running from Program.cs file inside MunicipalityTaxes project. 

Basically i have created a Service Layer named as App Library for fetching the tax details or inserting tax details. 

MunicipalityTaxes is the main project.
------------------------------------------------------------------------------------------------------------------------

LOGIC
------------------------------------------------------------------------------------------------------------------------
First thing i have done is fetching/inserting tax details from MunicipalityTaxesLogWebAPI via Applibrary to MunicipalityTaxes Project and displayed it.

I have used a table named 'MunicipalityTaxes' and a stored procedure 'FetchTaxesDetails' for fetching/inserting. I have kept the script in the project folder itself.

For fetching the tax details it requires 2 parameter as request body mentioned below and it will be a POST request. API url - https://localhost:44363/api/MunicipalityTaxes/GetMunicipalityTaxesDetails
{
    "MunicipalityName":"xyz",
    "checkDate":"2020-03-19"
}

For inserting the tax details it requires 5 parameter as request body mentioned below and it will be a POST request. API url - https://localhost:44363/api/MunicipalityTaxes/InsertMunicipalityTaxesDetails3
{
    "MunicipalityName":"zyx",
    "startDate":"2020-03-19",
    "endDate":"2020-03-19",
    "TaxType":"Yearly",
    "TaxAmount":0.2
}


------------------------------------------------------------------------------------------------------------------------
