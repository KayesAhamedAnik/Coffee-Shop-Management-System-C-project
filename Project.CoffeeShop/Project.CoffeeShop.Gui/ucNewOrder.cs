using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.CoffeeShop.Repo;
using System.Windows.Forms;
using Project.CoffeeShop.Entity;
using Project.CoffeeShop.Framework;

namespace Project.CoffeeShop.Gui
{

    public partial class ucNewOrder : UserControl
    {
        ItemRepo IRepo { get; set; }
        //Order or { get; set; }
        //OrderRepo oREpo = new OrderRepo();
        Sale S { get; set; }
        SaleRepo sRepo { get; set; }
        public ucNewOrder()
        {
            InitializeComponent();

            this.IRepo = new ItemRepo();
            this.sRepo= new SaleRepo();
            this.S = new Sale();
            PopulateGridView();
            LoadAutoAppId();
        }

        private static ucNewOrder _Instance;

        public static ucNewOrder instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ucNewOrder();
                return _Instance;
            }
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

        private void dgvCoffee_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool valid = Convert.ToBoolean(Convert.ToString(this.dgvCoffee.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                if (valid == true)
                {
                    this.dgvCoffee.Rows[e.RowIndex].Cells[3].ReadOnly = false;
                }
                else if (valid == false)
                {
                    this.dgvCoffee.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                    this.dgvCoffee.Rows[e.RowIndex].Cells[3].Value = "";

                }

            }
        }
        private void dgvJuice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool valid = Convert.ToBoolean(Convert.ToString(this.dgvJuice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                if (valid == true)
                {
                    this.dgvJuice.Rows[e.RowIndex].Cells[3].ReadOnly = false;
                }
                else if (valid == false)
                {
                    this.dgvJuice.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                    this.dgvJuice.Rows[e.RowIndex].Cells[3].Value = "";

                }

            }
        }
        private void dgvPastry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool valid = Convert.ToBoolean(Convert.ToString(this.dgvPastry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                if (valid == true)
                {
                    this.dgvPastry.Rows[e.RowIndex].Cells[3].ReadOnly = false;
                }
                else if (valid == false)
                {
                    this.dgvPastry.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                    this.dgvPastry.Rows[e.RowIndex].Cells[3].Value = "";

                }

            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {

        }
        private void brnRrefresh_Click(object sender, EventArgs e)
        {
            PopulateGridView();
            txtReceipt.Text = "";
            txtSubTotal.Text = "00";
            txtTotal.Text = "00";
            LoadAutoAppId();
            txtReceipt.ReadOnly = false;
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            txtReceipt.Copy();
        }
        private void tsbPaste_Click(object sender, EventArgs e)
        {
            txtReceipt.Paste();
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "Notepad Text";
            saveFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtReceipt.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            txtReceipt.Clear();
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtReceipt.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtReceipt.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, 120, 120);
        }

        private void tsbCut_Click(object sender, EventArgs e)
        {
            txtReceipt.Cut();
        }
        private void LoadAutoAppId()
        {
            int value= sRepo.IdGenerator();
            S.id = ++value;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtTotal.Text)==0)
            {
                return;
            }
            S.bill = (float)Convert.ToDouble(txtTotal.Text.ToString());
            S.vat = (float)Convert.ToDouble(txtVat.Text.ToString());
            S.details = txtReceipt.Text.ToString();
            LoadAutoAppId();
            bool valid=sRepo.Save(S);
            if(!valid)
            {
                MessageBox.Show("Invalid");      
            }
            
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            txtReceipt.ReadOnly = false;
            btnConfirm.Enabled = true;
            txtReceipt.Text = "";
            string cost, name = "item";
            int price = 00, quantity = 00;
            double totalCost = 00, vat = 0, serviceCharge = 0;
            txtReceipt.AppendText("-----------------------------------------------------------------------------------------" + Environment.NewLine);
            txtReceipt.AppendText("\t\t\t" + "Coffee House \t\t" + System.DateTime.Now.ToString() + Environment.NewLine);
            txtReceipt.AppendText("-----------------------------------------------------------------------------------------" + Environment.NewLine);
            foreach (DataGridViewRow row in dgvPastry.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value))

                {
                    if (row.Cells[3].Value != null)
                    {
                        bool valid = Validation.IsIntValid(row.Cells[3].Value.ToString());
                        if (valid)
                        {

                            quantity = Convert.ToInt32(row.Cells[3].Value.ToString());
                            name = row.Cells[1].Value.ToString();
                            price = Convert.ToInt32(row.Cells[2].Value);
                            cost = quantity.ToString() + "X" + price.ToString();
                            if (quantity > 0)
                            {

                                totalCost = totalCost + (price * quantity);
                                txtReceipt.AppendText(name + "\t\t\t" + cost + Environment.NewLine);

                            }
                        }
                    }
                }
            }
            foreach (DataGridViewRow row in dgvJuice.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value))

                {
                    if (row.Cells[3].Value != null)
                    {
                        bool valid = Validation.IsIntValid(row.Cells[3].Value.ToString());
                        if (valid)
                        {

                            quantity = Convert.ToInt32(row.Cells[3].Value.ToString());
                            name = row.Cells[1].Value.ToString();
                            price = Convert.ToInt32(row.Cells[2].Value);
                            cost = quantity.ToString() + "X" + price.ToString();
                            if (quantity > 0)
                            {

                                totalCost = totalCost + (price * quantity);
                                txtReceipt.AppendText(name + "\t\t\t" + cost + Environment.NewLine);

                            }
                        }
                    }
                }
            }
            foreach (DataGridViewRow row in dgvCoffee.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))

                {
                    if (row.Cells[3].Value != null)
                    {
                        bool valid = Validation.IsIntValid(row.Cells[3].Value.ToString());
                        if (valid)
                        {

                            quantity = Convert.ToInt32(row.Cells[3].Value.ToString());
                            name = row.Cells[1].Value.ToString();
                            price = Convert.ToInt32(row.Cells[2].Value);
                            cost = quantity.ToString() + "X" + price.ToString();
                            if (quantity > 0)
                            {

                                totalCost = totalCost + (price * quantity);
                                txtReceipt.AppendText(name + "\t\t\t" + cost + Environment.NewLine);

                            }
                        }
                    }
                }
            }
        
        txtSubTotal.Text = totalCost.ToString();  
            vat = ((totalCost / 100) * 15);
            txtVat.Text = vat.ToString();
            txtServiceCharge.Text = "2%";
            serviceCharge = ((totalCost / 100) * 2);
            txtServiceCharge.Text = serviceCharge.ToString();            
            cost = (((totalCost / 100) * 15) + ((totalCost / 100) * 2) + totalCost).ToString();
        txtTotal.Text = cost;

            txtReceipt.AppendText("--------------------------------------------------------------------------------------------" + Environment.NewLine);
            txtReceipt.AppendText("Sub Total \t\t" +totalCost+ Environment.NewLine);
            txtReceipt.AppendText("-------------------------------------------------------------------------------------------" + Environment.NewLine);
            txtReceipt.AppendText("Vat 15% \t\t\t" + vat + Environment.NewLine);
            txtReceipt.AppendText("ServiceCharge 2% \t\t" + serviceCharge + Environment.NewLine);
            txtReceipt.AppendText("Total Cost \t\t\t" + cost + Environment.NewLine);
            txtReceipt.AppendText("-------------------------------------------------------------------------------------------" + Environment.NewLine);
            txtReceipt.ReadOnly = true;   
        }
    }
    }


