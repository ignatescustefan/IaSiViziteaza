using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IaSiViziteaza.DAL.ORC
{
    public class DataBaseConnection
    {

        private static string constr = null;



        private static DataBaseConnection dbInstance;
        private OracleConnection conn;

        private DataBaseConnection()
        {
        }


        public static DataBaseConnection getDbInstance()
        {
            if (dbInstance == null)
            {

                dbInstance = new DataBaseConnection();
            }
            return dbInstance;
        }

        public OracleConnection GetDBConnection()
        {
            try
            {
                createConnectionstring();
                conn = new OracleConnection(constr);
                conn.Open();
                System.Diagnostics.Debug.WriteLine("Connected");
            }
            catch (OracleException e)
            {
                System.Diagnostics.Debug.WriteLine("Not connected : " + e.ToString());
            }

            return conn;
        }

        public void closeDBConnection()
        {
            try
            {
                conn.Close();
                System.Diagnostics.Debug.WriteLine("Connection closed");
            }
            catch (OracleException e)
            {
                System.Diagnostics.Debug.WriteLine("Connection closed failed : " + e.ToString());

            }
            finally
            {
                System.Diagnostics.Debug.WriteLine("End..");

            }

        }

        public static void createConnectionstring()
        {

            try
            {
                System.Diagnostics.Debug.WriteLine("Reading configurations.....");
                String serverName="localhost:1521",
                    username= "psbd_proiect",
                    password="parola1234";

                //give values to these variables
                //string conString = "User Id=stefan; Password=stefan1234; Data Source=localhost:1521; Pooling =false;";

                constr = "User Id=" + username +
                    "; Password=" + password +
                    "; Data Source=" + serverName +
                    "; Pooling =false;";

                System.Diagnostics.Debug.WriteLine("ConstrVariable created ");
            }
            catch (Exception ConstrError)
            {
                System.Diagnostics.Debug.WriteLine(ConstrError.Message);
            }
        }
    }
}