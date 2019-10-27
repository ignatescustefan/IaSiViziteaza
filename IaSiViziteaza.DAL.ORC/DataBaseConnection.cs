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
        string conString = "User Id=stefan; Password=stefan1234; Data Source=localhost:1521; Pooling =false;";
        void Test()
        {
                OracleConnection conn = new OracleConnection(conString);  // C#
                conn.Open();
                    OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                    cmd.CommandText = "select EMPNO,ename from emp where job=\'MANAGER\' ";
                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                            Console.WriteLine(dr.GetString(1) + " " +dr.GetInt32(0));
                    }
            conn.Dispose();

        }
    }
}
