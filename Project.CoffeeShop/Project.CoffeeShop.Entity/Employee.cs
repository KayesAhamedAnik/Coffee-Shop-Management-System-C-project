using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.CoffeeShop.Entity
{
    public class Employee
    {
       public string name
        {
            get;set;
        }
       public string phone
        {
            get;set;
        }
       public string email
        {
            get;set;
        }
        public string address
        {
            get;set;
        }
       public string designation
        {
            get;set;
        }
       public string joinningDate
        {
            get;set;
        }
        public int salary
        {
            get;set;
        }
        public string id
        {
            get; set;
        }
      /*  public Employee(string id,string name,string designation)
        {
            this.id=id;
            this.name=name;
            this.designation = designation;

        }
        public Employee() { }*/
    }
}
