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
using Project.CoffeeShop.Entity;

namespace Project.CoffeeShop.Gui
{
    public partial class ucItems : UserControl
    {
        private ItemRepo IRepo
        {
            get;set;
        }
        private Item it{ get; set; }
        public ucItems()
        {
            InitializeComponent();
            this.IRepo = new ItemRepo();
            this.it = new Item();
            PopulateGridView();
        }
        private static ucItems _instance;
        public static ucItems instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucItems();
                return _instance;
            }

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }
        public void PopulateGridView()
            {
                this.dgvCoffee.AutoGenerateColumns = false;
                this.dgvCoffee.DataSource = IRepo.GetAllCoffee().ToList();
                this.dgvCoffee.ClearSelection();
                this.dgvCoffee.Refresh();

            this.dgvJuice.AutoGenerateColumns = false;
            this.dgvJuice.DataSource = IRepo.GetAllJuice().ToList();
            this.dgvJuice.ClearSelection();
            this.dgvJuice.Refresh();

            this.dgvPastry.AutoGenerateColumns = false;
            this.dgvPastry.DataSource = IRepo.GetAllPastry().ToList();
            this.dgvPastry.ClearSelection();
            this.dgvPastry.Refresh();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) //coffee table
        {
            if (this.dgvCoffee.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }

            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string itemId = this.dgvCoffee.CurrentRow.Cells["coffeeId"].Value.ToString();
            bool decision = IRepo.Delete(itemId);

            if (decision)
            {
                MessageBox.Show("Delete Confirmed.");
                this.PopulateGridView();
            }
            else
                MessageBox.Show("Invalid Id.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab==tabCoffee)
            {
                if (this.dgvCoffee.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Please Select A Row First");
                    return;
                }

                if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                string itemId = this.dgvCoffee.CurrentRow.Cells["coffeeId"].Value.ToString();
                bool decision = IRepo.Delete(itemId);

                if (decision)
                {
                    MessageBox.Show("Delete Confirmed.");
                    this.PopulateGridView();
                }
                else
                    MessageBox.Show("Invalid Id.");
            }
            if (tabControl1.SelectedTab==tabJuice)
            {
                if (this.dgvJuice.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Please Select A Row First");
                    return;
                }

                if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                string itemId = this.dgvJuice.CurrentRow.Cells["juiceId"].Value.ToString();
                bool decision = IRepo.Delete(itemId);

                if (decision)
                {
                    MessageBox.Show("Delete Confirmed.");
                    this.PopulateGridView();
                }
                else
                    MessageBox.Show("Invalid Id.");
            }
            if (tabControl1.SelectedTab==tabPastry)
            {
                if (this.dgvPastry.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Please Select A Row First");
                    return;
                }

                if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                string itemId = this.dgvPastry.CurrentRow.Cells["pastryId"].Value.ToString();
                bool decision = IRepo.Delete(itemId);

                if (decision)
                {
                    MessageBox.Show("Delete Confirmed.");
                    this.PopulateGridView();
                }
                else
                    MessageBox.Show("Invalid Id.");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DelegateClassForItem.GridDelegate delgrid = PopulateGridView;
            new AddNewItem(delgrid).Visible = true;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab==tabCoffee)
            {
                it.name = this.dgvCoffee.CurrentRow.Cells["coffeeName"].Value.ToString();
                it.itemId = this.dgvCoffee.CurrentRow.Cells["coffeeId"].Value.ToString();
                it.price = int.Parse(this.dgvCoffee.CurrentRow.Cells["coffeePrice"].Value.ToString());

            }
            else if (tabControl1.SelectedTab ==tabJuice)
            {
                it.name = this.dgvJuice.CurrentRow.Cells["juiceName"].Value.ToString();
                it.itemId = this.dgvJuice.CurrentRow.Cells["juiceId"].Value.ToString();
                it.price = int.Parse(this.dgvJuice.CurrentRow.Cells["juicePrice"].Value.ToString());
            }
           else if(tabControl1.SelectedTab == tabPastry)
            {
                it.name = this.dgvPastry.CurrentRow.Cells["pastryName"].Value.ToString();
                it.itemId = this.dgvPastry.CurrentRow.Cells["pastryId"].Value.ToString();
                it.price = int.Parse(this.dgvPastry.CurrentRow.Cells["pastryPrice"].Value.ToString());
            }
            else { }
            new AddNewItem(it).Show();
            PopulateGridView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //it.itemId = txtID.Text;
            //it.name = txtName.Text;
            //it.price = int.Parse(txtPrice.Text);
            //bool decision = IRepo.Save(it);
            //if(decision)
            //{
            //    MessageBox.Show("Item Updated");
            //    panelUpdateItem.Visible = true;
            }
        }

    }

