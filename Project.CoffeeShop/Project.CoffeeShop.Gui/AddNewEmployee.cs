using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Project.CoffeeShop.Entity;
using Project.CoffeeShop.Repo;
using Project.CoffeeShop.Framework;

namespace Project.CoffeeShop.Gui
{
    public partial class AddNewEmployee : Form
    {
        private EmployeeRepo EmpRepo = new EmployeeRepo();
        Employee emp= new Employee();
        Validation V = new Validation();
        private DelegateClassForItem.GridDelegate dg;
        public AddNewEmployee(DelegateClassForItem.GridDelegate dg)
        {
            InitializeComponent();
            this.dg = dg;
            this.LoadAutoAppId();
        }
        public AddNewEmployee(int i)
        {
            InitializeComponent();
            LoadAutoAppId();
        }
        public AddNewEmployee(Employee em)
        {
            InitializeComponent();
            txtId.Text = em.id;
            txtName.Text = em.name;
            txtEmail.Text = em.email;
            txtPhone.Text = em.phone;
            txtSalary.Text = em.salary.ToString();
            CmbDesignation.Text = em.designation;
            txtAddress.Text = em.address;
            dtpJoinningDate.Value =Convert.ToDateTime(em.joinningDate.ToString());
            btnInsert.Visible = false;
            btnUpdate.Visible = true;
        }
        private void LoadAutoAppId()
        {
            int serial = EmpRepo.IdGenerator();
            EmpRepo.Id = (++serial).ToString("d2");
            this.txtId.Text = EmpRepo.Id;
        }
        private void InvalidTextField(TextBox text)
        {
            text.ForeColor = Color.Red;

        }
        private void ValidTextField(TextBox text)
        {
            text.ForeColor = Color.Black;

        }
        bool validDesignation()
        {
            if (CmbDesignation.Text == "Admin")
            { return true; }
            else if (CmbDesignation.Text == "Cashier")
            { return true; }
            else if (CmbDesignation.Text == "Barista")
            { return true; }
            else if (CmbDesignation.Text == "Waiter")
            { return true; }
            else if (CmbDesignation.Text == "Clerk")
            { return true; }
            else if (CmbDesignation.Text == "Manager")
            { return true; }
            else
                return false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            bool valid = this.FillEntity();
            bool validEmail = IsValidEmail(txtEmail.Text);
            bool validPhone = IsPhoneNumber(txtPhone.Text);
            if (!validEmail)
            {
                MessageBox.Show("Please Enter a valid Email.");
                InvalidTextField(txtEmail);
                ValidTextField(txtPhone);
    
            }
            else if (!validPhone)
            {
                MessageBox.Show("Please Enter a valid phone Number \n Phone number containing only digits.");
                InvalidTextField(txtPhone);
                ValidTextField(txtEmail);
            }
            else if (validDesignation() == false)
            {
                MessageBox.Show("Please select a valid designation");

            }
            else if (!valid)
            {
                MessageBox.Show("Please Enter Correct information");
            }
            else
            {
                bool d = EmpRepo.Save(emp);
                if (d == true)
                {
                    MessageBox.Show("Insert Successful");
                    this.dg();
                    ClearFields();
                }
                else
                    MessageBox.Show("Insert Not Done", " \n Please Enter Correct Data");

            }

        }

        private bool FillEntity()
        {
            if (!IsValidToSave())
                return false;
            emp.name = txtName.Text;
            emp.id = txtId.Text;
            emp.joinningDate = dtpJoinningDate.Text;
            emp.phone = txtPhone.Text;
            emp.email = txtEmail.Text;

            emp.designation = CmbDesignation.Text;
            emp.address = txtAddress.Text;
            emp.salary = Int32.Parse(this.txtSalary.Text);
            return true;
        }
        private bool IsValidToSave()
        {
            if (Validation.IsStringValid(this.txtName.Text) && Validation.IsStringValid(this.txtId.Text) &&
                Validation.IsStringValid(this.txtAddress.Text) && Validation.IsStringValid(this.txtPhone.Text) &&
                Validation.IsStringValid(this.txtEmail.Text) && Validation.IsStringValid(this.CmbDesignation.Text) &&
                Validation.IsDateTimeValid(this.dtpJoinningDate.Text) && Validation.IsIntValid(this.txtSalary.Text))
                return true;
            else
                return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void ClearFields()
        {
            LoadAutoAppId();
            txtName.Text = "";
            CmbDesignation.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtSalary.Text = "";
            dtpJoinningDate.ResetText();
        }

        private bool EmailValid()
        {
            if (txtEmail.Text.Contains('@') && txtEmail.Text.Contains('.'))
            {
                return true;
            }
            else
                return false;
        }
        public static bool IsPhoneNumber(string number)
        {
            int test;
            return int.TryParse(number, out test);
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (email.Contains(".") && addr.Address == email)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool valid = this.FillEntity();
            bool validEmail = IsValidEmail(txtEmail.Text);
            bool validPhone = IsPhoneNumber(txtPhone.Text);
            if (!validEmail)
            {
                MessageBox.Show("Please Enter a valid Email.");
                InvalidTextField(txtEmail);
            }
            else if (!validPhone)
            {
                MessageBox.Show("Please Enter a valid phone Number \n Phone number containing only digits.");
                InvalidTextField(txtPhone);
            }
            else if (validDesignation() == false)
            {
                MessageBox.Show("Please select a valid designation");

            }
            else if (!valid)
            {
                MessageBox.Show("Please Enter Correct information");
            }
            else
            {
                bool d = EmpRepo.Save(emp);
                if (d == true)
                {
                    MessageBox.Show("Update Successful");
                    btnInsert.Visible = true;
                    btnUpdate.Visible = false;
                    this.Close();
                }
                else
                    MessageBox.Show("Insert Not Done", " \n Please Enter Correct Data");
            }

        }
    }
}
