using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project.CoffeeShop.Data
{
    public class DataAccess
    {
        private static SqlConnection sqlCon;

        public static SqlConnection SqlCon
        {
            get
            {
                try
                {
                    if (sqlCon == null)
                    {
                        sqlCon = new SqlConnection(@"Data Source=KAYES-LAPTOP\SQLEXPRESS;Initial Catalog=TheCoffeeShop;Persist Security Info=True;User ID=sa;Password=1234");
                    }
                    else if (sqlCon.State != ConnectionState.Open)
                    {
                        sqlCon.Open();
                    }
                    return sqlCon;
                }
              catch (Exception ex) { return null; }
            }
        }

        public static DataSet GetDataSet(string query)
        {
       
            
                SqlCommand sqcom = new SqlCommand(query, SqlCon);
                SqlDataAdapter sda = new SqlDataAdapter(sqcom);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;

        }

            public static DataTable GetDataTable(string query)
        {
            var ds = GetDataSet(query);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static int ExecuteUpdateQuery(string query)
        {
            SqlCommand sqcom = new SqlCommand(query, SqlCon);
            return sqcom.ExecuteNonQuery();
        }
    }
}
