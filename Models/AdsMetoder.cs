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

        public List<AdsDetalj> GetAds(out string errormsg)
        {
            //skapa SQL-connection
            SqlConnection dbConnection = new SqlConnection();

            // Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = db_Annons; Integrated Security = True";

            // sqlstring för att hämta alla studenter
            String sqlstring = "SELECT * FROM [tbl_ads]";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            // Declare the SqlDataReader, which is used in
            // both the try block and the finnaly block.

            SqlDataReader reader = null;

            List<AdsDetalj> AdsLista = new List<AdsDetalj>();

            errormsg = "";

            try
            {
                // open the connection
                dbConnection.Open();

                // 1. get an instance of the SqlDataReader
                reader = dbCommand.ExecuteReader();

                // 2. read necessary columns of each block.
                while (reader.Read())
                {
                    //Läser ut data från datasetet
                    AdsDetalj ads = new AdsDetalj();

                    ads.ad_id = Convert.ToInt32(reader["ad_id"]);
                    ads.ad_varupris = Convert.ToInt32(reader["ad_varupris"]);
                    ads.ad_innehall = reader["ad_innehall"].ToString();
                    ads.ad_rubrik = reader["ad_rubrik"].ToString();
                    ads.ad_annonspris = Convert.ToInt32(reader["ad_annonspris"]);

                    AdsLista.Add(ads);
                }
                reader.Close();
                return AdsLista;
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}
