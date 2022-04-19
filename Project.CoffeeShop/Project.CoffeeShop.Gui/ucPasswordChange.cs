using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.CoffeeShop.Repo;

namespace Project.CoffeeShop.Gui
{
    public partial class ucPasswordChange : UserControl
    {
        UserRepo URepo { get; set; }
        public ucPasswordChange()
        {
            InitializeComponent();
            this.URepo = new UserRepo();
        }
        string UserId;
        public ucPasswordChange(string id)
        {
            InitializeComponent();
            this.URepo = new UserRepo();
            UserId = id;
        }
        //private static ucPasswordChange _instance;
        //public static ucPasswordChange instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new ucPasswordChange(id);
        //        return _instance;
        //    }

        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtPreviousPassword.ForeColor = Color.Black;
            txtRetypeNewPassword.ForeColor = Color.Black;
            if (txtPreviousPassword.Text==URepo.ReturnPassword(UserId))
            {
                if (txtNewPassword.Text == txtRetypeNewPassword.Text)
                {
                    bool valid = URepo.Save(UserId, txtNewPassword.Text,"n");
                    if (valid)
                    {
                        MessageBox.Show("Password Changed");
                        txtNewPassword.Text = "";
                        txtPreviousPassword.Text = "";
                        txtRetypeNewPassword.Text = "";
                        return;
                    }

                }
                else
                    txtRetypeNewPassword.ForeColor = Color.Red;

            }
            else
            { txtShow.Visible = true;
            
               //txtPreviousPassword.ForeColor = Color.Red;
                MessageBox.Show("Password doesnt Match");
            }
        }

        private void txtShow_Click(object sender, EventArgs e)
        {
            if(txtShow.Text=="Show")
            {
                txtShow.Text = "Hide";
                txtNewPassword.UseSystemPasswordChar = false;
                txtRetypeNewPassword.UseSystemPasswordChar = false;

            }
           else if (txtShow.Text == "Hide")
            {
                txtShow.Text = "Show";
                txtNewPassword.UseSystemPasswordChar = true;
                txtRetypeNewPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
