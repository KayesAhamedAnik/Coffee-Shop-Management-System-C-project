using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.CoffeeShop.Repo;
using System.Windows.Forms;
using Project.CoffeeShop.Entity;

namespace Project.CoffeeShop.Gui
{
    
    public partial class Cashier : Form
    {
        User U = new User();
        public Cashier(String ID)
        {
            InitializeComponent();
            labelUserName.Text = "Welcome-"+ new UserRepo().UserName(ID);
            U.id = ID;
           
        }
        public Cashier(int i)
        {
            InitializeComponent();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                labelTimer.Text = DateTime.Now.ToString("T");
            
        }

        private void Cashier_Load(object sender, EventArgs e)
        {
            timer1.Start();
            if (!panelCashierHome.Controls.Contains(ucHome.instance))
            {
                panelCashierHome.Controls.Add(ucHome.instance);
                ucHome.instance.Dock = DockStyle.Fill;
                ucHome.instance.BringToFront();
            }
            else
                ucHome.instance.BringToFront();

        }

        private void lblLogout_MouseHover(object sender, EventArgs e)
        {
            lblLogout.Font = new Font("Calibri", 16, FontStyle.Bold);
            lblLogout.ForeColor =System.Drawing.Color.Aqua;
        }
       

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            lblLogout.Font = new Font("Calibri", 13, FontStyle.Bold);
            lblLogout.ForeColor = System.Drawing.Color.White;
        }

        private void labelUserName_MouseHover(object sender, EventArgs e)
        {
            labelUserName.Font = new Font("Calibri", 16, FontStyle.Bold);
            labelUserName.ForeColor = System.Drawing.Color.Aqua;
        }

        private void labelUserName_MouseLeave(object sender, EventArgs e)
        {
            labelUserName.Font = new Font("Calibri", 13, FontStyle.Bold);
           labelUserName.ForeColor = System.Drawing.Color.White;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (!panelCashierHome.Controls.Contains(ucHome.instance))
            {
                panelCashierHome.Controls.Add(ucHome.instance);
                ucHome.instance.Dock = DockStyle.Fill;
                ucHome.instance.BringToFront();
            }
            else
                ucHome.instance.BringToFront();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            if (!panelCashierHome.Controls.Contains(ucNewOrder.instance))
            {
                panelCashierHome.Controls.Add(ucNewOrder.instance);
                ucNewOrder.instance.Dock = DockStyle.Fill;
                ucNewOrder.instance.BringToFront();
            }
            else
                ucNewOrder.instance.BringToFront();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {

            ucPasswordChange ucChange = new ucPasswordChange(U.id);
           


            if (!panelCashierHome.Controls.Contains(ucChange))
            {
                panelCashierHome.Controls.Add(ucChange);
                ucChange.Dock = DockStyle.Fill;
                ucChange.BringToFront();
            }
            else
            { 

                ucChange.Dock = DockStyle.Fill;
                ucChange.BringToFront();
            }
               
        }

    }
}
