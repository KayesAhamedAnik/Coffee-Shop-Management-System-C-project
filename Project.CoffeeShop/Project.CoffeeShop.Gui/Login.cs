using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Project.CoffeeShop.Repo;
namespace Project.CoffeeShop.Gui
{
    public partial class Login: MetroForm
    {
        private UserRepo userRp { get; set; }
        public Login()
        {
            InitializeComponent();
            this.userRp = new UserRepo();
        }
        private void lblForgotPassword_MouseEnter(object sender, EventArgs e)
        {
            lblForgotPassword.ForeColor = Color.Blue;
        }

        private void lblForgotPassword_MouseLeave(object sender, EventArgs e)
        {
            lblForgotPassword.ForeColor = Color.Black;
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Contact Admin");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool verify = userRp.Login(txtUserame.Text, txtPassword.Text);
            if (verify)
            {
                string role = userRp.Role(txtUserame.Text);
                if(role== "Adminstrator" || role=="Manager")
                {
                    MessageBox.Show("Login Successfull");
                    this.Hide();
                    Home home = new Home(txtUserame.Text);
                    home.ShowDialog();
                    this.Show();
                    txtUserame.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Login Successfull");
                    this.Hide();
                    Cashier cash=new Cashier(txtUserame.Text);
                    cash.ShowDialog();
                    this.Show();
                    txtUserame.Text = "";
                    txtPassword.Text = "";
                }


            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                lblForgotPassword.Visible = true;

            }
        }

    }
}
