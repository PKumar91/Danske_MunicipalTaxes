using AppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MunicipalityTaxesWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MunicipalityTaxesController : ControllerBase
    {
        // POST: api/MunicipalityTaxes/GetMunicipalityTaxesDetails
        /// <summary>
        /// For Fetching data from database containing MunicipalityTaxes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public decimal GetMunicipalityTaxesDetails([FromBody] MunicipalityTaxes taxes)
        {
            decimal taxAmt = 0;
            try
            {
                List<MunicipalityTaxes> municipalityTaxes = new List<MunicipalityTaxes>();
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Taxes"].ToString()))
                {
                    SqlCommand sqlComm = new SqlCommand("FetchTaxesDetails", conn);
                    sqlComm.Parameters.AddWithValue("@Action_Type", 'G');
                    sqlComm.Parameters.AddWithValue("@Munc_Name", taxes.MunicipalityName);
                    sqlComm.Parameters.AddWithValue("@date", taxes.checkDate);

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    taxAmt = (Decimal)sqlComm.ExecuteScalar();
                }
                return taxAmt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/MunicipalityTaxes/InsertMunicipalityTaxesDetails
        /// <summary>
        /// For inserting data into database containing MunicipalityTaxes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Int16 InsertMunicipalityTaxesDetails([FromBody] MunicipalityTaxes taxes)
        {
            Int16 Num = 0;
            try
            {
                List<MunicipalityTaxes> municipalityTaxes = new List<MunicipalityTaxes>();
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Taxes"].ToString()))
                {
                    SqlCommand sqlComm = new SqlCommand("FetchTaxesDetails", conn);
                    sqlComm.Parameters.AddWithValue("@Action_Type", 'I');
                    sqlComm.Parameters.AddWithValue("@Munc_Name", taxes.MunicipalityName);
                    sqlComm.Parameters.AddWithValue("@Start_Date", taxes.StartDate);
                    sqlComm.Parameters.AddWithValue("@End_Date", taxes.EndDate);
                    sqlComm.Parameters.AddWithValue("@Tax_Amt", taxes.TaxAmount);
                    sqlComm.Parameters.AddWithValue("@Tax_Type", taxes.TaxType);

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    Num = (Int16)sqlComm.ExecuteNonQuery();
                }
                return Num;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
