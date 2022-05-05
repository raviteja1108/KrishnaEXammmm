using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;



namespace MedicalBillingSytem
{
    class DBHandler
    {
        public SqlConnection GetConnection()
        {
            SqlConnection con = null;
            string connection = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            con = new SqlConnection(connection);
            return con;
        }
    }
}
