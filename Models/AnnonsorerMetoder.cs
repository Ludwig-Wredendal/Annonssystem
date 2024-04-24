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
            String sqlstring = "INSERT INTO tbl_annonsorer (an_prenumerant, an_foretag, an_namn, an_organisationsnummer, an_telefonnummer, an_utdelningsadress, an_postnummer, an_ort) " +
                "VALUES (0, 1, @namn, @organisationsnummer, @telefonnummer, @utdelningsadress, @postnummer, @ort)";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            //dbCommand.Parameters.Add("prenumerant", SqlDbType.Int).Value = ad.an_prenumerant;
            //dbCommand.Parameters.Add("prenumerant", SqlDbType.Bit).Value = ad.an_prenumerant ? 1 : 0;

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

        public AnnonsorerDetalj GetForetag(int annonsor_id, out string errormsg)
        {
            errormsg = "";

            try
            {
                // Connection string
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db_Annons;Integrated Security=True";

                // SQL query with parameter
                string sqlQuery = "SELECT * FROM [tbl_annonsorer] WHERE an_id = @id";

                using (SqlConnection dbConnection = new SqlConnection(connectionString))
                {
                    // Create command with parameter
                    SqlCommand dbCommand = new SqlCommand(sqlQuery, dbConnection);
                    dbCommand.Parameters.Add("@id", SqlDbType.Int).Value = annonsor_id;

                    dbConnection.Open();

                    using (SqlDataReader reader = dbCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            AnnonsorerDetalj pd = new AnnonsorerDetalj
                            {
                                an_id = Convert.ToInt32(reader["an_id"]),
                                an_prenumerant = Convert.ToBoolean(reader["an_prenumerant"]),
                                an_foretag = Convert.ToBoolean(reader["an_foretag"]),
                                an_namn = reader["an_namn"].ToString(),
                                an_organisationsnummer = Convert.ToInt32(reader["an_organisationsnummer"]),
                                an_telefonnummer = Convert.ToInt32(reader["an_telefonnummer"]),
                                an_utdelningsadress = reader["an_utdelningsadress"].ToString(),
                                an_postnummer = Convert.ToInt32(reader["an_postnummer"]),
                                an_ort = reader["an_ort"].ToString(),
                        };

                            return pd;
                        }
                        else
                        {
                            errormsg = "Det hämtas ingen annonsör.";
                            return null;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
        }

        public List<AnnonsorerDetalj> GetForetag(out string errormsg)
        {
            //skapa SQL-connection
            SqlConnection dbConnection = new SqlConnection();

            // Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = db_Annons; Integrated Security = True";

            // sqlstring för att hämta alla studenter
            String sqlstring = "SELECT * FROM [tbl_annonsorer]";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            // Declare the SqlDataReader, which is used in
            // both the try block and the finnaly block.

            SqlDataReader reader = null;

            List<AnnonsorerDetalj> foretaglista = new List<AnnonsorerDetalj>();

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
                     AnnonsorerDetalj pd = new AnnonsorerDetalj
                    {
                        an_id = Convert.ToInt32(reader["an_id"]),
                        an_prenumerant = Convert.ToBoolean(reader["an_prenumerant"]),
                        an_foretag = Convert.ToBoolean(reader["an_foretag"]),
                        an_namn = reader["an_namn"].ToString(),
                        an_organisationsnummer = Convert.ToInt32(reader["an_organisationsnummer"]),
                        an_telefonnummer = Convert.ToInt32(reader["an_telefonnummer"]),
                        an_utdelningsadress = reader["an_utdelningsadress"].ToString(),
                        an_postnummer = Convert.ToInt32(reader["an_postnummer"]),
                        an_ort = reader["an_ort"].ToString(),
                    };
                    foretaglista.Add(pd);
                }
                reader.Close();
                return foretaglista;
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
