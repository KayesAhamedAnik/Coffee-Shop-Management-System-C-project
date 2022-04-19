using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.CoffeeShop.Entity;
using Project.CoffeeShop.Repo;
using Project.CoffeeShop.Framework;
using System.Windows.Forms;

namespace Project.CoffeeShop.Gui
{
    public partial class AddNewItem : Form
    {
        ItemRepo IRepo = new ItemRepo();// { get; set; }
        Item it = new Item();
        private DelegateClassForItem.GridDelegate dg;
        public AddNewItem(DelegateClassForItem.GridDelegate dg)
        {
            InitializeComponent();
            this.dg = dg;
        }
        public AddNewItem(int a)
        {
            InitializeComponent();

        }
        public AddNewItem(Item it)
        {
            InitializeComponent();
            txtId.Text=it.itemId;
            txtName.Text=it.name;
            txtPrice.Text = it.price.ToString();
            if(it.itemId[0]=='C')
            {
                cmbType.Text = "Coffee";
            }
            else if (it.itemId[0] == 'J')
            {
                cmbType.Text = "Juice/Soft Drinks";
            }
            else if (it.itemId[0] == 'P')
            {
                cmbType.Text = "Pastry/Bakery";
            }
            txtName.ReadOnly = false;
            txtPrice.ReadOnly = false;
            btnInsert.Visible = false;
            btnUpdate.Visible = true;
        }
        private void LoadAutoAppId(String type )
        {
            int serial=0;
            String id= (++serial).ToString("d2");
            if (type == "Coffee")
            {
                serial = IRepo.IdGenerator("C-");
               id= IRepo.ID = "C-" + (++serial).ToString("d2");
            }
            else if (type == "Juice/Soft Drinks")
            {
                serial = IRepo.IdGenerator("J-");
               id= IRepo.ID = "J-" + (++serial).ToString("d2");
            }
            else if (type == "Pastry/Bakery")
            {
                serial = IRepo.IdGenerator("P-");
               id= IRepo.ID = "P-"+(++serial).ToString("d2");  
            }
            
            this.txtId.Text =id;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            bool valid=this.FillEntity();
            if (valid == true)
            {
              bool  v = IRepo.Save(it);
                if (v== true)
                {
                    MessageBox.Show("Item Added Successfully");
                    this.dg();
                    ClearFields();
                    return;
                }
                MessageBox.Show("Item couldn't add");
            }
            else
            {
                MessageBox.Show("Invalid Info");
            }
        }
        private bool FillEntity()
        {
            if (!IsValidToSave())
                return false;
            it.name = txtName.Text;
            it.itemId= txtId.Text;
            it.price = Int32.Parse(this.txtPrice.Text);
            return true;
        }
        private bool IsValidToSave()
        {
            if (Validation.IsStringValid(this.txtName.Text) && Validation.IsStringValid(this.txtId.Text) &&
                 Validation.IsIntValid(this.txtPrice.Text))
                return true;
            else
                return false;
        }
        private void cmbType_TextChanged(object sender, EventArgs e)
        {
            if (cmbType.Text == "Select Type")
            {
                txtName.ReadOnly = true; ;
                txtName.BackColor = Color.LightGray;
                txtPrice.BackColor = Color.LightGray;
                txtPrice.ReadOnly = true;
                MessageBox.Show("Please Select a Type First");

            }
            else
            {
                LoadAutoAppId(cmbType.Text);
                txtName.ReadOnly = false;
                txtName.BackColor = Color.White;
                txtPrice.BackColor = Color.White;
                txtPrice.ReadOnly = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void ClearFields()
        {
            LoadAutoAppId(cmbType.Text);
            txtPrice.Text = "";
            txtName.Text = "";
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool valid = this.FillEntity();
            if (valid == true)
            {
                valid = IRepo.Save(it);
                if (valid == true)
                {
                    MessageBox.Show("Item Updated Successfully");
                    btnInsert.Visible = true;
                    btnUpdate.Visible = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid info");
                }
                
            }
            else
            {
                MessageBox.Show("Invalid Info");
            }
        }
    }
}
