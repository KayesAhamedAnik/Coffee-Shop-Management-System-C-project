using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.CoffeeShop.Entity;
using Project.CoffeeShop.Repo;
namespace Project.CoffeeShop.Gui
{
   
    public partial class Home : Form
    {
         public static String id { get; set; }
        public Home(String Username)
        {
            InitializeComponent();
            HomePage();
            id = Username;
        }
        private void HideSubMenu()  
        {
            if (panelSubMenuNew.Visible == true)
            { panelSubMenuNew.Visible = false; }

            if (panelSubMenuAll.Visible == true)
            { panelSubMenuAll.Visible = false; }

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            panelSubMenuAll.Visible = true;
            if(panelSubMenuNew.Visible==true)
            { panelSubMenuNew.Visible = false; }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            panelSubMenuNew.Visible = true;
            if(panelSubMenuAll.Visible==true)
            { panelSubMenuAll.Visible = false; }
        }
        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLogout_MouseHover(object sender, EventArgs e)
        {
            lblLogout.ForeColor = Color.Black;
        }

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            lblLogout.ForeColor = Color.White;
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            
            lblHome.Text = "Employees";
            if (!panelHome.Controls.Contains(ucEmployees.instance))
            {
                panelHome.Controls.Add(ucEmployees.instance);
                ucEmployees.instance.Dock = DockStyle.Fill;
                ucEmployees.instance.BringToFront();
            }
            else
                ucEmployees.instance.BringToFront();


        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //lblHome.Text = "Change Password";
            //if (!panelHome.Controls.Contains(ucPasswordChange.instance))
            //{
            //    panelHome.Controls.Add(ucPasswordChange.instance);
            //    ucPasswordChange.instance.Dock = DockStyle.Fill;
            //    ucPasswordChange.instance.BringToFront();
            //}
            //else
            //    ucHome.instance.BringToFront();
            ucPasswordChange ucChange = new ucPasswordChange(id);
            panelHome.Controls.Add(ucChange);

            if (!panelHome.Controls.Contains(ucChange))
            {
                panelHome.Controls.Add(ucChange);
                ucChange.Dock = DockStyle.Fill;
                ucChange.BringToFront();
            }
            else
            
                {

                    ucChange.Dock = DockStyle.Fill;
                    ucChange.BringToFront();
                }
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            HomePage();
            lblHome.Text = "Home";
        }
        public void HomePage()
        {
            if (!panelHome.Controls.Contains(ucHome.instance))
            {
                panelHome.Controls.Add(ucHome.instance);
                ucHome.instance.Dock = DockStyle.Fill;
                ucHome.instance.BringToFront();
            }
            else
                ucHome.instance.BringToFront();
        }

        private void Items_Click(object sender, EventArgs e)
        {
            lblHome.Text = "All Items";
            if (!panelHome.Controls.Contains(ucItems.instance))
            {
                panelHome.Controls.Add(ucItems.instance);
                ucItems.instance.Dock = DockStyle.Fill;
                ucItems.instance.BringToFront();
            }
            else
                ucItems.instance.BringToFront();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            lblHome.Text = "All Users";
            if (!panelHome.Controls.Contains(ucUsers.instance))
            {
                panelHome.Controls.Add(ucUsers.instance);
                ucUsers.instance.Dock = DockStyle.Fill;
                ucUsers.instance.BringToFront();
            }
            else
                ucUsers.instance.BringToFront();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
             labelTimer.Text = DateTime.Now.ToString("T");
        }

        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            int i=0;
            new AddNewEmployee(i).Visible = true;
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            lblHome.Text = "New Order";
            if (!panelHome.Controls.Contains(ucNewOrder.instance))
            {
                panelHome.Controls.Add(ucNewOrder.instance);
                ucNewOrder.instance.Dock = DockStyle.Fill;
                ucNewOrder.instance.BringToFront();
            }
            else
                ucNewOrder.instance.BringToFront();
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            int a = 0;
            new AddNewItem(a).Show();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            if (!panelHome.Controls.Contains(ucSale.instance))
            {
                panelHome.Controls.Add(ucSale.instance);
                ucSale.instance.Dock = DockStyle.Fill;
                ucSale.instance.BringToFront();
            }
            else
                ucSale.instance.BringToFront();
        }
    }
}
