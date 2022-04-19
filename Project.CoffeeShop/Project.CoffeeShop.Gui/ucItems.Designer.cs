namespace Project.CoffeeShop.Gui
{
    partial class ucItems
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cmsCoffee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCoffee = new System.Windows.Forms.TabPage();
            this.dgvCoffee = new System.Windows.Forms.DataGridView();
            this.tabJuice = new System.Windows.Forms.TabPage();
            this.dgvJuice = new System.Windows.Forms.DataGridView();
            this.tabPastry = new System.Windows.Forms.TabPage();
            this.dgvPastry = new System.Windows.Forms.DataGridView();
            this.juiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.juicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pastryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pastryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pastryPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coffeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coffeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coffeePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.cmsCoffee.SuspendLayout();
            this.tabCoffee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoffee)).BeginInit();
            this.tabJuice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJuice)).BeginInit();
            this.tabPastry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastry)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 64);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(816, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 34);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(915, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 34);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(717, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 34);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 476);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.cmsCoffee;
            this.tabControl1.Controls.Add(this.tabCoffee);
            this.tabControl1.Controls.Add(this.tabJuice);
            this.tabControl1.Controls.Add(this.tabPastry);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1025, 476);
            this.tabControl1.TabIndex = 0;
            // 
            // cmsCoffee
            // 
            this.cmsCoffee.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCoffee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.cmsCoffee.Name = "cmsCoffee";
            this.cmsCoffee.Size = new System.Drawing.Size(128, 100);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // tabCoffee
            // 
            this.tabCoffee.Controls.Add(this.dgvCoffee);
            this.tabCoffee.Location = new System.Drawing.Point(4, 25);
            this.tabCoffee.Name = "tabCoffee";
            this.tabCoffee.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoffee.Size = new System.Drawing.Size(1017, 447);
            this.tabCoffee.TabIndex = 0;
            this.tabCoffee.Text = "Coffee";
            this.tabCoffee.UseVisualStyleBackColor = true;
            // 
            // dgvCoffee
            // 
            this.dgvCoffee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCoffee.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCoffee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoffee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coffeeId,
            this.coffeeName,
            this.coffeePrice});
            this.dgvCoffee.ContextMenuStrip = this.cmsCoffee;
            this.dgvCoffee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCoffee.Location = new System.Drawing.Point(3, 3);
            this.dgvCoffee.Name = "dgvCoffee";
            this.dgvCoffee.RowHeadersWidth = 51;
            this.dgvCoffee.RowTemplate.Height = 24;
            this.dgvCoffee.Size = new System.Drawing.Size(1011, 441);
            this.dgvCoffee.TabIndex = 0;
            // 
            // tabJuice
            // 
            this.tabJuice.Controls.Add(this.dgvJuice);
            this.tabJuice.Location = new System.Drawing.Point(4, 25);
            this.tabJuice.Name = "tabJuice";
            this.tabJuice.Padding = new System.Windows.Forms.Padding(3);
            this.tabJuice.Size = new System.Drawing.Size(1017, 447);
            this.tabJuice.TabIndex = 1;
            this.tabJuice.Text = "Juice";
            this.tabJuice.UseVisualStyleBackColor = true;
            // 
            // dgvJuice
            // 
            this.dgvJuice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJuice.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvJuice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJuice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.juiceId,
            this.juiceName,
            this.juicePrice});
            this.dgvJuice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJuice.GridColor = System.Drawing.SystemColors.Control;
            this.dgvJuice.Location = new System.Drawing.Point(3, 3);
            this.dgvJuice.Name = "dgvJuice";
            this.dgvJuice.RowHeadersWidth = 51;
            this.dgvJuice.RowTemplate.Height = 24;
            this.dgvJuice.Size = new System.Drawing.Size(1011, 441);
            this.dgvJuice.TabIndex = 1;
            // 
            // tabPastry
            // 
            this.tabPastry.Controls.Add(this.dgvPastry);
            this.tabPastry.Location = new System.Drawing.Point(4, 25);
            this.tabPastry.Name = "tabPastry";
            this.tabPastry.Padding = new System.Windows.Forms.Padding(3);
            this.tabPastry.Size = new System.Drawing.Size(1017, 447);
            this.tabPastry.TabIndex = 2;
            this.tabPastry.Text = "Pastry";
            this.tabPastry.UseVisualStyleBackColor = true;
            // 
            // dgvPastry
            // 
            this.dgvPastry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPastry.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPastry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPastry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pastryId,
            this.pastryName,
            this.pastryPrice});
            this.dgvPastry.ContextMenuStrip = this.cmsCoffee;
            this.dgvPastry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPastry.Location = new System.Drawing.Point(3, 3);
            this.dgvPastry.Name = "dgvPastry";
            this.dgvPastry.RowHeadersWidth = 51;
            this.dgvPastry.RowTemplate.Height = 24;
            this.dgvPastry.Size = new System.Drawing.Size(1011, 441);
            this.dgvPastry.TabIndex = 1;
            // 
            // juiceId
            // 
            this.juiceId.DataPropertyName = "itemId";
            this.juiceId.HeaderText = "ID";
            this.juiceId.MinimumWidth = 6;
            this.juiceId.Name = "juiceId";
            // 
            // juiceName
            // 
            this.juiceName.DataPropertyName = "name";
            this.juiceName.HeaderText = "Name";
            this.juiceName.MinimumWidth = 6;
            this.juiceName.Name = "juiceName";
            // 
            // juicePrice
            // 
            this.juicePrice.DataPropertyName = "price";
            this.juicePrice.HeaderText = "Price";
            this.juicePrice.MinimumWidth = 6;
            this.juicePrice.Name = "juicePrice";
            // 
            // pastryId
            // 
            this.pastryId.DataPropertyName = "itemId";
            this.pastryId.HeaderText = "ID";
            this.pastryId.MinimumWidth = 6;
            this.pastryId.Name = "pastryId";
            // 
            // pastryName
            // 
            this.pastryName.DataPropertyName = "name";
            this.pastryName.HeaderText = "Name";
            this.pastryName.MinimumWidth = 6;
            this.pastryName.Name = "pastryName";
            // 
            // pastryPrice
            // 
            this.pastryPrice.DataPropertyName = "price";
            this.pastryPrice.HeaderText = "Price";
            this.pastryPrice.MinimumWidth = 6;
            this.pastryPrice.Name = "pastryPrice";
            // 
            // coffeeId
            // 
            this.coffeeId.DataPropertyName = "itemId";
            this.coffeeId.HeaderText = "ID";
            this.coffeeId.MinimumWidth = 6;
            this.coffeeId.Name = "coffeeId";
            // 
            // coffeeName
            // 
            this.coffeeName.DataPropertyName = "name";
            this.coffeeName.HeaderText = "Name";
            this.coffeeName.MinimumWidth = 6;
            this.coffeeName.Name = "coffeeName";
            // 
            // coffeePrice
            // 
            this.coffeePrice.DataPropertyName = "price";
            this.coffeePrice.HeaderText = "Price";
            this.coffeePrice.MinimumWidth = 6;
            this.coffeePrice.Name = "coffeePrice";
            // 
            // ucItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucItems";
            this.Size = new System.Drawing.Size(1025, 540);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.cmsCoffee.ResumeLayout(false);
            this.tabCoffee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoffee)).EndInit();
            this.tabJuice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJuice)).EndInit();
            this.tabPastry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCoffee;
        private System.Windows.Forms.TabPage tabJuice;
        private System.Windows.Forms.TabPage tabPastry;
        private System.Windows.Forms.DataGridView dgvCoffee;
        private System.Windows.Forms.DataGridView dgvJuice;
        private System.Windows.Forms.DataGridView dgvPastry;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip cmsCoffee;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn juiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn juiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn juicePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn pastryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn pastryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn pastryPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn coffeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn coffeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn coffeePrice;
    }
}
