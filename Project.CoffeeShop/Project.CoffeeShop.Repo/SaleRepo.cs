using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Project.CoffeeShop.Entity;
using Project.CoffeeShop.Data;

namespace Project.CoffeeShop.Repo
{
   public class SaleRepo
    {
        public List<Sale> GetAll()
        {
            var SaleList = new List<Sale>();
            var sql = "select * from Balance;";
            var dt = DataAccess.GetDataTable(sql);

            for (int index = 0; index < dt.Rows.Count; index++)
            {
                Sale S= ConvertToEntity(dt.Rows[index]);
                SaleList.Add(S);
            }
            return SaleList;
        }
        public Sale ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }
            var S = new Sale();
            S.bill =float.Parse( row["bill"].ToString());
            S.vat=float.Parse( row["vat"].ToString());
            S.id = int.Parse(row["id"].ToString());
            S.time =row["time"].ToString();
            S.details =row["details"].ToString();
            return S;
        }
        public int IdGenerator()
        {
            var dt = DataAccess.GetDataTable("select * from Balance;");
            int value = Convert.ToInt32(dt.Rows[dt.Rows.Count -1]["id"].ToString());
            return value;
        }
        public bool Save(Sale S)
        {
            try
            {
                string query = "select * from Balance where id = '" +S.id+ "'";
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    query = "Insert into Balance values ('" + S.id+ "','" +S.bill+ "','" + S.vat + "','"+System.DateTime.Now.ToString()+"','"+S.details+"');";
                }
                else
                {
                    query = "Update Balance set bill= '" +S.bill+ "',vat='" +S.vat+ "','"+S.details+"' where id = '" +S.id + "'";
                }

                int count = DataAccess.ExecuteUpdateQuery(query);

                if (count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            string query = "select * from Balance where id= '" + id + "'";
            var dt = DataAccess.GetDataTable(query);

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            query = "delete from Balance where id = '" + id + "'";
            int count = DataAccess.ExecuteUpdateQuery(query);
            if (count == 1)
                return true;
            else
                return false;
        }
    }
}
