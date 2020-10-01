using AppLibrary;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MunicipalityTaxes
{
    public class MunicipalityTax
    {

        #region "PROPERTY"
        private IServiceProvider _serviceProvider { get; set; }
        #endregion

        /// <summary>
        /// This method is main method used for fetching data via web API and calculating MunicipalityTaxes
        /// </summary>
        public void FetchTaxesDetails()
        {
            _serviceProvider = new ServiceCollection()
                  .AddTransient<IMunicipalityTaxesService, MunicipalityTaxesService>()
                  .AddTransient<IMunicipalityTaxesRepository, MunicipalityTaxesRepository>()
                  .BuildServiceProvider();
            var MunicipalityTaxesService = _serviceProvider.GetRequiredService<IMunicipalityTaxesService>();
            string taxAmt = MunicipalityTaxesService.GetMunicipalityTaxesDetails();
            Console.WriteLine("Tax Amount is "+ taxAmt);
            Console.ReadLine();
        }

        /// <summary>
        /// This method is main method used for Inserting MunicipalityTaxes
        /// </summary>
        public void InsertTaxesDetails()
        {
            _serviceProvider = new ServiceCollection()
                  .AddTransient<IMunicipalityTaxesService, MunicipalityTaxesService>()
                  .AddTransient<IMunicipalityTaxesRepository, MunicipalityTaxesRepository>()
                  .BuildServiceProvider();
            var MunicipalityTaxesService = _serviceProvider.GetRequiredService<IMunicipalityTaxesService>();
            string msg = MunicipalityTaxesService.InsertMunicipalityTaxesDetails();
            Console.WriteLine(msg);
            Console.ReadLine();
        }
    }
}
