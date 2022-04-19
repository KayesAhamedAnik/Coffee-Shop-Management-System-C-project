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
    public partial class ucUsers : UserControl
    {
        // private static UserRepo URepo { get; set; }
        UserRepo URepo = new UserRepo();
        public ucUsers()
        {
            InitializeComponent();
         //   this.PopulateGridViewSearch(txtSearch.Text);
            this.PopulateGridView();
            

            // this. PopulateGridViewSearch(txtSearch.Text);
            //  UserStatus();

        }

        private static ucUsers _Instance;
        public static ucUsers instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ucUsers();
                return _Instance;
            }
        }
        private void PopulateGridView()
        {
            this.dgvUser.AutoGenerateColumns = false;
            this.dgvUser.DataSource = URepo.GetAllUser().ToList();
            this.dgvUser.ClearSelection();
            this.dgvUser.Refresh();

        }
        private void PopulateGridViewSearch(string txt)
        {
            this.dgvSearch.AutoGenerateColumns = false;
            this.dgvSearch.DataSource = URepo.Search(txt).ToList();
            this.dgvSearch.ClearSelection();
            this.dgvSearch.Refresh();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (txtSearch.Text == "" || txtSearch.Text == " ")
            {
                dgvSearch.Visible = false;
            }
            else
                dgvSearch.Visible = true;
            PopulateGridViewSearch(txtSearch.Text);
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.dgvSearch.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }
            labelRole.Visible = true;
            cmbRole.Visible = true;
            btnAdd.Visible = true;
            dgvSearch.Visible = false;

            
        }

        private Random _random = new Random();
        public string GenerateRandomNo()
        {
            return _random.Next(0, 9999).ToString("D4");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (this.dgvUser.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }
            if(this.dgvUser.CurrentRow.Cells["role"].Value.ToString()=="Admin")
            {
                MessageBox.Show("Admin Cannot be deleted");
                return;
            }
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string Empid = this.dgvUser.CurrentRow.Cells["id"].Value.ToString();
            bool decision = URepo.Delete(Empid);

            if (decision)
            {
                MessageBox.Show("Delete Confirmed.");
                PopulateGridView();
                txtSearch.Text = "";
            }
            else
                MessageBox.Show("Invalid Id.");
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbRole.Text == "select role")
            {
                MessageBox.Show("please select role");
            }
            else
            {
                string appid = this.dgvSearch.CurrentRow.Cells["empid"].Value.ToString();
                String pass = GenerateRandomNo();
                string role = cmbRole.Text;
                String message = "User Successfully Added. \nPassword:" + pass + "";
                bool decision = URepo.Save(appid, pass,role);
                if (decision)
                {
                    MessageBox.Show(message);
                    labelRole.Visible = false;
                    cmbRole.Visible = false;
                    btnAdd.Visible = false;
                    this.PopulateGridView();
                    this.txtSearch.Text = "";
                }
                else
                    MessageBox.Show("Invalid ");
            }
            
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvUser.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }
            string pass = URepo.ReturnPassword(this.dgvUser.CurrentRow.Cells["id"].Value.ToString());
            string message = "Password is: " + pass;
            MessageBox.Show(message);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvUser.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }
            if (this.dgvUser.CurrentRow.Cells["role"].Value.ToString() == "Admin")
            {
                MessageBox.Show("Admin Cannot be deleted");
                return;
            }
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string Empid = this.dgvUser.CurrentRow.Cells["id"].Value.ToString();
            bool decision = URepo.Delete(Empid);

            if (decision)
            {
                MessageBox.Show("Delete Confirmed.");
                PopulateGridView();
                txtSearch.Text = "";
            }
            else
                MessageBox.Show("Invalid Id.");
        }
    }
 }
    
