using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Municipality.Tests
{
    [TestClass]
    public class TestMunicipalityTaxesController
    {
        [TestMethod]
        public void GetMunicipalityTaxesDetails()
        {
            string taxAmt = TaxAmount();
            var controller = new MunicipalityTaxesController();

            var result = controller.GetMunicipalityTaxesDetails() as string;
            Assert.AreEqual(taxAmt, result);
        }

        private string TaxAmount()
        {         

            return testProducts;
        }
    }
}