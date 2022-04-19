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
using Project.CoffeeShop.Repo;

namespace Project.CoffeeShop.Gui
{
    public partial class ucEmployees : UserControl
    {
        private EmployeeRepo ERepo { get; set; }
        private UserRepo URepo { get; set; }
        private Employee emp { get; set; }
        public ucEmployees()
        {
            InitializeComponent();
            this.ERepo = new EmployeeRepo();
            this.URepo = new UserRepo();
            this.emp = new Employee();
            PopulateGridView();
        }
        private static ucEmployees _Instance;
        public static ucEmployees instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ucEmployees();
                return _Instance;
            }
        }
        private void PopulateGridView()
        {
            this.dgvEmployees.AutoGenerateColumns = false;
            this.dgvEmployees.DataSource = ERepo.GetAll().ToList();
            this.dgvEmployees.ClearSelection();
            this.dgvEmployees.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelegateClassForItem.GridDelegate delgrid = PopulateGridView;
            new AddNewEmployee(delgrid).Visible = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)//delete
        {
            if (this.dgvEmployees.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }

            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string Empid = this.dgvEmployees.CurrentRow.Cells["id"].Value.ToString();
            bool decision = ERepo.Delete(Empid);
            bool decision2 = URepo.Delete(Empid);
            if (decision || decision2)
            {
                MessageBox.Show("Delete Confirmed.");
                this.PopulateGridView();
            }
            else
                MessageBox.Show("Invalid Id.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvEmployees.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }

            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string Empid = this.dgvEmployees.CurrentRow.Cells["id"].Value.ToString();
            bool decision = ERepo.Delete(Empid);
            bool decision2 = URepo.Delete(Empid);
            if (decision || decision2)
            {
                MessageBox.Show("Delete Confirmed.");
                this.PopulateGridView();
            }
            else
                MessageBox.Show("Invalid Id.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DelegateClassForItem.GridDelegate delgrid = PopulateGridView;
            new AddNewEmployee(delgrid).Visible = true;
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (this.dgvEmployees.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }
            else
            {
                emp.id = this.dgvEmployees.CurrentRow.Cells["id"].Value.ToString();
                emp.name = this.dgvEmployees.CurrentRow.Cells["name"].Value.ToString();
                emp.designation = this.dgvEmployees.CurrentRow.Cells["designation"].Value.ToString();
                emp.joinningDate = (this.dgvEmployees.CurrentRow.Cells["joinningDate"].Value.ToString());
                emp.phone = this.dgvEmployees.CurrentRow.Cells["phone"].Value.ToString();
                emp.email = this.dgvEmployees.CurrentRow.Cells["email"].Value.ToString();
                emp.address = this.dgvEmployees.CurrentRow.Cells["address"].Value.ToString();
                emp.salary = int.Parse(this.dgvEmployees.CurrentRow.Cells["salary"].Value.ToString());
                new AddNewEmployee(emp).Show();
                PopulateGridView();
            }
        }
    }
}
