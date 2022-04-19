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
    public class EmployeeRepo
    {
        public List<Employee> GetAll()
        {
            var EmployeeList = new List<Employee>();
            var sql = "select * from employees;";
            var dt = DataAccess.GetDataTable(sql);

            for (int index = 0; index < dt.Rows.Count; index++)
            {
                Employee E = ConvertToEntity(dt.Rows[index]);
                EmployeeList.Add(E);
            }
            return EmployeeList;
        }
        public Employee ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }
            var E = new Employee();
            E.id = row["id"].ToString();
            E.name = row["name"].ToString();
            E.designation = row["designation"].ToString();
            E.joinningDate = row["joinningDate"].ToString();
            E.address = row["address"].ToString();
            E.phone = row["phone"].ToString();
            E.email = row["email"].ToString(); 
            E.salary = int.Parse(row["salary"].ToString());

            return E;
        }
        public bool Save(Employee emp)
        {
            try
            {
                string query = "select * from employees where id = '" +emp.id+ "'";
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    query = "Insert into employees values ('" +emp.id+ "','" +emp.name+ "','" +emp.designation+ "','" +emp.joinningDate+ "','" + emp.address+ "','" + emp.phone+ "','" + emp.email + "','"+emp.salary+"');";
                }
                else
                {
                    query = "Update employees set name = '" + emp.name+ "',designation= '" +emp.designation+ "',joinningDate= '"+emp.joinningDate+ "',address= '" + emp.address + "',phone= '" + emp.phone+ "',email= '" + emp.email + "',salary='"+emp.salary+"' where id = '" + emp.id + "'";
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
            string query = "select * from employees where id= '" + id + "'";
            var dt = DataAccess.GetDataTable(query);

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            query = "delete from employees where id = '" + id + "'";
            int count = DataAccess.ExecuteUpdateQuery(query);
            if (count == 1)
                return true;
            else
                return false;
        }
        private string empID;
        public string Id
        {
            get { return empID; }
            set { this.empID = "A-" + value; }
        }
        public int IdGenerator()
        {
            var dt = DataAccess.GetDataTable("select * from employees;");
            string value = dt.Rows[dt.Rows.Count - 1]["id"].ToString();

            string[] id = value.Split('-');
            int number = Convert.ToInt32(id[1]);
            return number;
        }
          public Employee SearchEmployee(String ID)
          {
            var sql = "select *from employees where id='" + ID + "';";
            var ds = DataAccess.GetDataTable(sql);
            Employee E = ConvertToEntity(ds.Rows[0]);
            return E;
          }
    } 
}
