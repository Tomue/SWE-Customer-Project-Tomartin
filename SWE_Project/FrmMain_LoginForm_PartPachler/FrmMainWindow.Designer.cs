namespace FrmMain_LoginForm_PartPachler
{
    partial class FrmMainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbxCustomer = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnBalance = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxSearch = new System.Windows.Forms.ComboBox();
            this.dtpSearch = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbxTimeToAddCus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbxCustomer
            // 
            this.lbxCustomer.FormattingEnabled = true;
            this.lbxCustomer.HorizontalScrollbar = true;
            this.lbxCustomer.ItemHeight = 20;
            this.lbxCustomer.Location = new System.Drawing.Point(18, 74);
            this.lbxCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbxCustomer.Name = "lbxCustomer";
            this.lbxCustomer.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxCustomer.Size = new System.Drawing.Size(774, 404);
            this.lbxCustomer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(802, 189);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(183, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add Customer";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(802, 249);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(183, 32);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit Customer";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnBalance
            // 
            this.btnBalance.Location = new System.Drawing.Point(802, 315);
            this.btnBalance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(183, 35);
            this.btnBalance.TabIndex = 3;
            this.btnBalance.Text = "Borrow/Lend";
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(1016, 280);
            this.tbxSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(262, 26);
            this.tbxSearch.TabIndex = 4;
            this.tbxSearch.Text = "Search";
            // 
            // Search
            // 
            this.Search.AutoSize = true;
            this.Search.Location = new System.Drawing.Point(1016, 194);
            this.Search.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(80, 20);
            this.Search.TabIndex = 5;
            this.Search.Text = "Search by";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1016, 320);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(264, 35);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search Customer";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxSearch
            // 
            this.cbxSearch.FormattingEnabled = true;
            this.cbxSearch.Items.AddRange(new object[] {
            "Name",
            "Customer Number",
            "Email Adress",
            "Date of Last Change"});
            this.cbxSearch.Location = new System.Drawing.Point(1098, 189);
            this.cbxSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSearch.Name = "cbxSearch";
            this.cbxSearch.Size = new System.Drawing.Size(180, 28);
            this.cbxSearch.TabIndex = 7;
            this.cbxSearch.SelectedIndexChanged += new System.EventHandler(this.cbxSearch_SelectedIndexChanged);
            // 
            // dtpSearch
            // 
            this.dtpSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSearch.Location = new System.Drawing.Point(1016, 231);
            this.dtpSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpSearch.Name = "dtpSearch";
            this.dtpSearch.Size = new System.Drawing.Size(262, 26);
            this.dtpSearch.TabIndex = 8;
            // 
            // tbxTimeToAddCus
            // 
            this.tbxTimeToAddCus.Location = new System.Drawing.Point(802, 155);
            this.tbxTimeToAddCus.Name = "tbxTimeToAddCus";
            this.tbxTimeToAddCus.ReadOnly = true;
            this.tbxTimeToAddCus.Size = new System.Drawing.Size(183, 26);
            this.tbxTimeToAddCus.TabIndex = 9;
            // 
            // FrmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 518);
            this.Controls.Add(this.tbxTimeToAddCus);
            this.Controls.Add(this.dtpSearch);
            this.Controls.Add(this.cbxSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.btnBalance);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxCustomer);
            this.Name = "FrmMainWindow";
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.FrmMainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label Search;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxSearch;
        private System.Windows.Forms.DateTimePicker dtpSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbxTimeToAddCus;
    }
}

