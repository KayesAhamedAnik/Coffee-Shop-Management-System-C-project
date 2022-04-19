using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.CoffeeShop.Entity;

namespace Project.CoffeeShop.Gui
{
    public partial class ucUpdateEmployee : UserControl
    {
        public ucUpdateEmployee() { }
        public ucUpdateEmployee(Employee emp)
        {
            InitializeComponent();
            emp = new Employee();
            FilltextFields(emp);
        }
        private static ucUpdateEmployee _Instance;
        public static ucUpdateEmployee instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ucUpdateEmployee();
                return _Instance;
            }
        }
        void FilltextFields(Employee emp)
        {
            txtId.Text = emp.id.ToString();
            txtName.Text = emp.name.ToString();
            txtPhone.Text = emp.phone.ToString();
            txtEmail.Text = emp.email.ToString();
            txtAddress.Text = emp.address.ToString();
            txtSalary.Text = emp.salary.ToString();
            CmbDesignation.Text = emp.designation.ToString();
            dtpJoinningDate.Value= Convert.ToDateTime(joinningDate);
        }
        
    }
}
