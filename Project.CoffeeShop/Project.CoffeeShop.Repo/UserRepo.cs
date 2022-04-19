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
    public class UserRepo
    {
        public bool Login(String id, string password)
        {
            try
            {
                String query = "select * from users where userId = '" + id + "' and password = '" + password + "';";
                var ds = DataAccess.GetDataSet(query);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public String UserName(String id)
        {
            var dt = DataAccess.GetDataTable("select name from employees where id='"+id+"';");
            string value = dt.Rows[dt.Rows.Count - 1]["name"].ToString();

            return value;
        }
        public string Role(string id)
        {
            var sql = "select * from users where userId like '" +id+ "%'";
            var dt = DataAccess.GetDataTable(sql);

            string role = dt.Rows[dt.Rows.Count-1]["role"].ToString();

            return role;
        }
        public List<User> GetAllUser()
        {
            var UserList = new List<User>();
            var sql = @"SELECT emp.id,emp.name,emp.designation,u.role
                       FROM employees as emp
                       inner join users as u
                         on  emp.id=u.userId;";
            var dt = DataAccess.GetDataTable(sql);

            for (int index = 0; index < dt.Rows.Count; index++)
            {
                User U = ConvertToEntity(dt.Rows[index]);
                UserList.Add(U);
            }
            return UserList;
        }
        public List<User> Search(String text)
        {
            var UserList = new List<User>();
            var sql = "select * from employees where name like '" + text + "%'";
            var dt = DataAccess.GetDataTable(sql);

            for (int index = 0; index < dt.Rows.Count; index++)
            {
                User U = SearchUser(dt.Rows[index]);
                UserList.Add(U);
            }
            return UserList;
        }
        private User SearchUser(DataRow row)
        {
            if (row == null)
            {
                return null;
            }
            var U = new User();

            U.id = row["id"].ToString();
            U.name = row["name"].ToString();
            U.designation = row["designation"].ToString();


            return U;
        }

        
        private User ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }
            var U = new User();
            U.id = row["id"].ToString();
            U.name= row["name"].ToString();
            U.designation = row["designation"].ToString();
            U.role = row["role"].ToString();


            return U;
        }
        public string ReturnPassword(string id)
        {
            try
            {
                String query = "select *from users where userId='" + id + "';";
                var dt = DataAccess.GetDataTable(query);

                if (dt.Rows.Count == 0 || dt == null)
                {
                    return null;
                }
                else
                {
                    String sql = "select password  from users where userId='" + id + "';";
                    var dT = DataAccess.GetDataTable(sql);
                    string pass = dt.Rows[dt.Rows.Count-1]["password"].ToString();
                    return pass;
                }
               
            }
            catch (Exception ex)
            {
                return null;
            }
            }
        public bool Save(String uid, String pass,string role)
        {
            try
            {
                string query = "select * from users where userId = '" +uid + "'";
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    query = "Insert into users values ('" +uid+ "','" +pass+ "','"+role+"');";
                }
                else
                {
                    query = "Update users set password= '" +pass+ "' where userId = '" +uid+ "'";
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
            string query = "select * from users where userId= '" + id + "'";
            var dt = DataAccess.GetDataTable(query);

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            query = "delete from users where userId = '" + id + "'";
            int count = DataAccess.ExecuteUpdateQuery(query);
            if (count == 1)
                return true;
            else
                return false;
        }

    }
}
