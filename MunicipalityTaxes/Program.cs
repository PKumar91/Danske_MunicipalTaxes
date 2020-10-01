using System;

namespace MunicipalityTaxes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("App Start");
            MunicipalityTax objMunicipalityTaxes = new MunicipalityTax();

            Console.WriteLine("Press 'G' for fetching tax details or press 'I' for insert tax details");            
            string type = Console.ReadLine();
            if(type.ToUpper() == "G")
                objMunicipalityTaxes.FetchTaxesDetails();
            else if (type.ToUpper() == "I")
                objMunicipalityTaxes.InsertTaxesDetails();
            Console.WriteLine("App End");
            Console.ReadLine();

        }


    }
}