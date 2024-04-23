using System.Data.SqlClient;
using System.Data;

namespace Annonssystem.Models
{
    public class AnnonsorerMetoder
    {
        public AnnonsorerMetoder() { }

        public int PostForetag(AnnonsorerDetalj ad, out string errormsg)
        {
            //skapa SQL-connection
            SqlConnection dbConnection = new SqlConnection();

            // Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db_Annons;Integrated Security=True;";

            // sqlstring och lägg till en annonsör i databasen
            String sqlstring = "INSERT INTO tbl_annonsorer (an_prenumerant, an_ads, an_foretag, an_namn, an_organisationsnummer, an_telefonnummer, an_utdelningsadress, an_postnummer, an_ort) " +
                "VALUES (0, @ads, 1, @namn, @organisationsnummer, @telefonnummer, @utdelningsadress, @postnummer, @ort)";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            //dbCommand.Parameters.Add("prenumerant", SqlDbType.Int).Value = ad.an_prenumerant;
            //dbCommand.Parameters.Add("prenumerant", SqlDbType.Bit).Value = ad.an_prenumerant ? 1 : 0;

            dbCommand.Parameters.Add("ads", SqlDbType.Int).Value = ad.an_ads;
            //dbCommand.Parameters.Add("foretag", SqlDbType.Int).Value = ad.an_foretag;
            //dbCommand.Parameters.Add("foretag", SqlDbType.Bit).Value = ad.an_foretag ? 1 : 0;

            dbCommand.Parameters.Add("namn", SqlDbType.NVarChar, 50).Value = ad.an_namn;
            dbCommand.Parameters.Add("organisationsnummer", SqlDbType.Int).Value = ad.an_organisationsnummer;
            dbCommand.Parameters.Add("telefonnummer", SqlDbType.Int).Value = ad.an_telefonnummer;
            dbCommand.Parameters.Add("utdelningsadress", SqlDbType.NVarChar, 50).Value = ad.an_utdelningsadress;
            dbCommand.Parameters.Add("postnummer", SqlDbType.Int).Value = ad.an_postnummer;
            dbCommand.Parameters.Add("ort", SqlDbType.NVarChar, 50).Value = ad.an_ort;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1) { errormsg = "Error"; }
                else { errormsg = "Det skapas inte en annonsör i databasen."; }
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
