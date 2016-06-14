namespace FrmMain_LoginForm_PartPachler
{
    partial class FrmEdit
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbxFirstname = new System.Windows.Forms.TextBox();
            this.labFistname = new System.Windows.Forms.Label();
            this.labLastname = new System.Windows.Forms.Label();
            this.tbxLastname = new System.Windows.Forms.TextBox();
            this.labEMail = new System.Windows.Forms.Label();
            this.tbxEMail = new System.Windows.Forms.TextBox();
            this.goupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nud = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.goupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxFirstname
            // 
            this.tbxFirstname.Location = new System.Drawing.Point(105, 25);
            this.tbxFirstname.Name = "tbxFirstname";
            this.tbxFirstname.Size = new System.Drawing.Size(229, 26);
            this.tbxFirstname.TabIndex = 0;
            this.tbxFirstname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labFistname
            // 
            this.labFistname.AutoSize = true;
            this.labFistname.Location = new System.Drawing.Point(6, 28);
            this.labFistname.Name = "labFistname";
            this.labFistname.Size = new System.Drawing.Size(75, 20);
            this.labFistname.TabIndex = 1;
            this.labFistname.Text = "Fistname";
            // 
            // labLastname
            // 
            this.labLastname.AutoSize = true;
            this.labLastname.Location = new System.Drawing.Point(6, 60);
            this.labLastname.Name = "labLastname";
            this.labLastname.Size = new System.Drawing.Size(80, 20);
            this.labLastname.TabIndex = 3;
            this.labLastname.Text = "Lastname";
            // 
            // tbxLastname
            // 
            this.tbxLastname.Location = new System.Drawing.Point(105, 57);
            this.tbxLastname.Name = "tbxLastname";
            this.tbxLastname.Size = new System.Drawing.Size(229, 26);
            this.tbxLastname.TabIndex = 2;
            this.tbxLastname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labEMail
            // 
            this.labEMail.AutoSize = true;
            this.labEMail.Location = new System.Drawing.Point(6, 92);
            this.labEMail.Name = "labEMail";
            this.labEMail.Size = new System.Drawing.Size(53, 20);
            this.labEMail.TabIndex = 5;
            this.labEMail.Text = "E-Mail";
            // 
            // tbxEMail
            // 
            this.tbxEMail.Location = new System.Drawing.Point(105, 89);
            this.tbxEMail.Name = "tbxEMail";
            this.tbxEMail.Size = new System.Drawing.Size(229, 26);
            this.tbxEMail.TabIndex = 4;
            this.tbxEMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // goupBox1
            // 
            this.goupBox1.Controls.Add(this.labEMail);
            this.goupBox1.Controls.Add(this.tbxEMail);
            this.goupBox1.Controls.Add(this.labLastname);
            this.goupBox1.Controls.Add(this.tbxLastname);
            this.goupBox1.Controls.Add(this.labFistname);
            this.goupBox1.Controls.Add(this.tbxFirstname);
            this.goupBox1.Location = new System.Drawing.Point(52, 12);
            this.goupBox1.Name = "goupBox1";
            this.goupBox1.Size = new System.Drawing.Size(348, 132);
            this.goupBox1.TabIndex = 6;
            this.goupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nud);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnSub);
            this.groupBox2.Location = new System.Drawing.Point(52, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 139);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // nud
            // 
            this.nud.DecimalPlaces = 2;
            this.nud.Location = new System.Drawing.Point(6, 25);
            this.nud.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud.Name = "nud";
            this.nud.Size = new System.Drawing.Size(328, 26);
            this.nud.TabIndex = 12;
            this.nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(328, 33);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Subtract money the customer paid me (-)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // btnSub
            // 
            this.btnSub.Location = new System.Drawing.Point(6, 57);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(328, 33);
            this.btnSub.TabIndex = 7;
            this.btnSub.Text = "Add money the customer owes me (+)";
            this.btnSub.UseVisualStyleBackColor = true;
            this.btnSub.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(58, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(167, 33);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(227, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(159, 33);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 348);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.goupBox1);
            this.Name = "FrmEdit";
            this.Text = "Edit Window";
            this.Load += new System.EventHandler(this.FrmEdit_Load);
            this.goupBox1.ResumeLayout(false);
            this.goupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxFirstname;
        private System.Windows.Forms.Label labFistname;
        private System.Windows.Forms.Label labLastname;
        private System.Windows.Forms.TextBox tbxLastname;
        private System.Windows.Forms.Label labEMail;
        private System.Windows.Forms.TextBox tbxEMail;
        private System.Windows.Forms.GroupBox goupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nud;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

