using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CoffeeShop.Entity
{
    public class User : Employee
    {
        public string password
        {
            get;set;
        }
        public string role
        { get; set; }
      /*  internal User(string id,string password,bool status,string name,string designation):base(id,name,designation)
        {
            base.id = id;
            base.name = name;
            base.designation = designation;
            this.password = password;
        
        }
        public User()
        {
            //jk
        }
        */
    }
}
