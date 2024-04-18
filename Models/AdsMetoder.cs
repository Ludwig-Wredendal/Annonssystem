using System.Data.SqlClient;
using System.Data;
using String = System.String;
using Elfie.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System;

namespace Annonssystem.Models
{
    public class AdsMetoder
    {
        public AdsMetoder() { }

        public int PostAds(AdsDetalj ad, out string errormsg)
        {
            //skapa SQL-connection
            SqlConnection dbConnection = new SqlConnection();

            // Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = db_Annons; Integrated Security = True";

            // sqlstring och lägg till en student i databasen
            String sqlstring = "INSERT INTO tbl_ads (ad_varupris, ad_innehall, ad_rubrik, ad_annonspris)" +
            "VALUES (@varupris, @innehall, @rubrik, @annonspris)";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("varupris", SqlDbType.Int).Value = ad.ad_varupris;
            dbCommand.Parameters.Add("innehall", SqlDbType.NVarChar, 50).Value = ad.ad_innehall;
            dbCommand.Parameters.Add("rubrik", SqlDbType.NVarChar, 50).Value = ad.ad_rubrik;
            dbCommand.Parameters.Add("annonspris", SqlDbType.Int).Value = ad.ad_annonspris;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1) { errormsg = "Error"; }
                else { errormsg = "Det skapas inte en annons i databasen."; }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbCommand.Connection.Close();
            }
        }
    }
}
