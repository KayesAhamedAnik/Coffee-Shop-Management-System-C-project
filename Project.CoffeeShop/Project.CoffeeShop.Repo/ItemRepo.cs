using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Project.CoffeeShop.Data;
using Project.CoffeeShop.Entity;

namespace Project.CoffeeShop.Repo
{
   public  class ItemRepo
    {
        public List<Item> GetAllCoffee()
        {
            var ItemList = new List<Item>();
            var sql = "select * from item where itemId like 'C%%';";
            var dt = DataAccess.GetDataTable(sql);

            for (int index = 0; index < dt.Rows.Count; index++)
            {
                Item I =ConvertToEntity(dt.Rows[index]);
                ItemList.Add(I);
            }
            return ItemList;
        }
       public List<Item> GetAllJuice()
        {
            var ItemList = new List<Item>();
            var sql = "select * from item where itemId like 'J%%';";
            var dt = DataAccess.GetDataTable(sql);

            for (int index = 0; index < dt.Rows.Count; index++)
            {
                Item I = ConvertToEntity(dt.Rows[index]);
                ItemList.Add(I);
            }
            return ItemList;
        }
        public List<Item> GetAllPastry()
        {
            var ItemList = new List<Item>();
            var sql = "select * from item where itemId like 'P%%';";
            var dt = DataAccess.GetDataTable(sql);

            for (int index = 0; index < dt.Rows.Count; index++)
            {
                Item I = ConvertToEntity(dt.Rows[index]);
                ItemList.Add(I);
            }
            return ItemList;
        }
        private Item ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }
            var I = new Item();
            I.itemId=row["itemId"].ToString();
            I.name = row["name"].ToString();
            I.price = int.Parse(row["price"].ToString());
            return I;
        }
        public bool Delete(string id)
        {
            string query = "select * from item where itemId= '" + id + "';";
            var dt = DataAccess.GetDataTable(query);

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }
            query = "delete from item where itemId = '" + id + "';";
            int count = DataAccess.ExecuteUpdateQuery(query);
            if (count == 1)
                return true;
            else
                return false;
        }
        private  string _ID;
        public string ID
        {
            get { return _ID; }
            set { this._ID =value; }
        }
        public int IdGenerator(String type)
        {
            var dt = DataAccess.GetDataTable("select * from item where itemId like '"+type+"%';");
            string value = dt.Rows[dt.Rows.Count - 1]["itemId"].ToString();

            string[] id = value.Split('-');
            int number = Convert.ToInt32(id[1]);
            return number;
        }

        public bool Save(Item it)
        {
            try
            {
                string query = "select * from item where itemId = '" +it.itemId + "';";
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    query = "Insert into item values ('" +it.itemId+ "','" +it.name + "','" +it.price+ "');";
                }
                else
                {
                    query = "Update item set name = '" +it.name + "',price= '" + it.price + "' where itemId = '" + it.itemId + "';";
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
    }    
}
