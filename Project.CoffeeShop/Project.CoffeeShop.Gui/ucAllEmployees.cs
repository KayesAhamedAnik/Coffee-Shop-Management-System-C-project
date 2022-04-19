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
    public partial class AllEmployees : UserControl
    {
        private EmployeeRepo EmpRepo { get; set; }
        public AllEmployees()
        {
            InitializeComponent();
            this.EmpRepo = new EmployeeRepo();
            PopulateGridView();
        }
        private static AllEmployees _instance;
        public static AllEmployees instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AllEmployees();
                return _instance;
            }

        }

        private void PopulateGridView()
        {
            this.dgvAllEmployees.AutoGenerateColumns = false;
            this.dgvAllEmployees.DataSource = EmpRepo.GetAll().ToList();
            this.dgvAllEmployees.ClearSelection();
            this.dgvAllEmployees.Refresh();
        }
        private void AllEmployees_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DelegateClassForProduct.GridDelegate delgrid = PopulateGridView;
            new AddNewEmployee(delgrid).Visible = true;

        }
    }
}
