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
        //Singleton 

        private static String constr = null; //holds tnsnames.ora statemnt



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

        /// <summary>
        /// this returns an oracle connection created using the connection string
        /// </summary>
        /// <returns>oracle connection</returns>
        public OracleConnection GetDBConnection()
        {
            try
            {
                createConnectionstring();
                conn = new OracleConnection(constr);
                conn.Open();
                Console.WriteLine("Connected");
            }
            catch (OracleException e)
            {
                Console.WriteLine("Not connected : " + e.ToString());
                Console.ReadLine();
            }

            return conn;
        }

        /// <summary>
        /// this closes the created database connection
        /// </summary>
        public void closeDBConnection()
        {
            try
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
            catch (OracleException e)
            {
                Console.WriteLine("Connection closed failed : " + e.ToString());

            }
            finally
            {
                Console.WriteLine("End..");

            }

        }

        /// <summary>
        /// Read the configurations.xml in order to create the connection string
        /// </summary>
        public static void createConnectionstring()
        {

            try
            {
                Console.WriteLine("Reading configurations.....");
                String serverName="localhost:1521",
                    username= "psbd_proiect",
                    password="parola1234";

                //give values to these variables
                //string conString = "User Id=stefan; Password=stefan1234; Data Source=localhost:1521; Pooling =false;";

                constr = "User Id=" + username +
                    "; Password=" + password +
                    "; Data Source=" + serverName +
                    "; Pooling =false;";

                Console.WriteLine("ConstrVariable created ");

            }
            catch (Exception ConstrError)
            {
                Console.WriteLine(ConstrError.Message);
            }
        }
    }
}