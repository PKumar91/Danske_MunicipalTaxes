using AppLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace AppLibrary
{
    public interface IMunicipalityTaxesRepository
    {
        string Load();
        string Insert();
    }

    public class MunicipalityTaxesRepository : IMunicipalityTaxesRepository
    {
        private static MunicipalityTaxes _MunicipalityTaxes = null;
        public MunicipalityTaxesRepository()
        {
            if (_MunicipalityTaxes == null)
            {
                _MunicipalityTaxes = new MunicipalityTaxes();
            }
        }
        public string Load()
        {
            try
            {
                string responseJSON = "";
                Console.WriteLine("Enter Municipality Name");
                string muncName = Console.ReadLine();
                Console.WriteLine("Enter Date");
                string date = Console.ReadLine();
                _MunicipalityTaxes.MunicipalityName = muncName;
                _MunicipalityTaxes.checkDate = Convert.ToDateTime(date, CultureInfo.GetCultureInfo("en-US")).ToString("yyyy-MM-dd");

                string url = "https://localhost:44363/api/MunicipalityTaxes/GetMunicipalityTaxesDetails";

                HttpClient client = new HttpClient();
                var jsonData = new StringContent(JsonConvert.SerializeObject(_MunicipalityTaxes), Encoding.UTF8, "application/json");
                var res = client.PostAsync(url, jsonData);

                if (res.Result.IsSuccessStatusCode)
                {
                    responseJSON = res.Result.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    responseJSON = "Error while fetching Tax details";
                }
                return responseJSON;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public string Insert()
        {
            try
            {
                string responseJSON = "";
                string taxType = "";
                Console.WriteLine("Enter Municipality Name");
                string muncName = Console.ReadLine();
                bool flag = false;
                do
                {
                    Console.WriteLine("Enter Tax Type. Must be either Yearly/Monthly/Daily");
                    taxType = Console.ReadLine();
                    if (!taxType.Equals("Yearly", StringComparison.OrdinalIgnoreCase) && !taxType.Equals("Monthly", StringComparison.OrdinalIgnoreCase) && !taxType.Equals("Daily", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Incorrect entry");
                        flag = false;
                    }
                    else
                        flag = true;
                }
                while (!flag);

                Console.WriteLine("Enter Start Date");
                string stDate = Console.ReadLine();
                Console.WriteLine("Enter End Date");
                string endDate = Console.ReadLine();
                Console.WriteLine("Enter Tax Amount");
                string taxAmt = Console.ReadLine();

                _MunicipalityTaxes.MunicipalityName = muncName;
                string[] formats = CultureInfo.CurrentUICulture.DateTimeFormat.GetAllDateTimePatterns();

                _MunicipalityTaxes.StartDate = DateTime.ParseExact(stDate, formats, new CultureInfo("en-US"), DateTimeStyles.None).ToString("yyyy-MM-dd");
                _MunicipalityTaxes.EndDate = DateTime.ParseExact(endDate, formats, new CultureInfo("en-US"), DateTimeStyles.None).ToString("yyyy-MM-dd");
                _MunicipalityTaxes.TaxAmount = Convert.ToDecimal(taxAmt);
                _MunicipalityTaxes.TaxType = taxType;

                string url = "https://localhost:44363/api/MunicipalityTaxes/InsertMunicipalityTaxesDetails";

                HttpClient client = new HttpClient();
                var jsonData = new StringContent(JsonConvert.SerializeObject(_MunicipalityTaxes), Encoding.UTF8, "application/json");
                var res = client.PostAsync(url, jsonData);

                if (res.Result.IsSuccessStatusCode)
                {
                    Int16 num = Convert.ToInt16(res.Result.Content.ReadAsStringAsync().Result);
                    if (num == 1)
                        responseJSON = "Data inserted successfully";
                }
                else
                    responseJSON = "Error while inserting Tax details";
                return responseJSON;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }    
}