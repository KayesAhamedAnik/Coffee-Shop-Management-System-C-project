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
    public partial class ucSale : UserControl
    {
        SaleRepo SRepo = new SaleRepo();
        public ucSale()
        {
            InitializeComponent();
            PopulateGridView();
        }
        private static ucSale _Instance;
        public static ucSale instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ucSale();
                return _Instance;
            }
        }
        private void PopulateGridView()
        {
            this.dgvSale.AutoGenerateColumns = false;
            this.dgvSale.DataSource =SRepo.GetAll().ToList();
            this.dgvSale.ClearSelection();
            this.dgvSale.Refresh();

            double total = 0, vat = 0;
            foreach(DataGridViewRow row in dgvSale.Rows)
            {
                total += Convert.ToDouble(row.Cells[1].Value);
                vat += Convert.ToDouble(row.Cells[2].Value);
            }
            txtBalance.Text = total.ToString();
            txtVat.Text = vat.ToString();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvSale.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }

            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string sId = this.dgvSale.CurrentRow.Cells["id"].Value.ToString();
            bool decision = SRepo.Delete(sId);
            if (decision)
            {
                MessageBox.Show("Delete Confirmed.");
                this.PopulateGridView();
            }
            else
                MessageBox.Show("Invalid Id.");
        }


    }
}
