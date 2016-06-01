using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Security.Cryptography;


namespace FrmMain_LoginForm_PartPachler
{
    public partial class FrmMainWindow : Form
    {
        private const string Passphrase = "HalloLeute";                   
        #region Membervariables and Constants
        private const string pathDB = @"..\..\cDB.csv"; //cDB...Customer Database
        public List<Customer> customers = new List<Customer>();
        
        #endregion

        public FrmMainWindow()
        {
            InitializeComponent();
            #region Tooltips:
            toolTip1.SetToolTip(lbxCustomer, "Represents the list of customers -- click on a customer to select it");
            toolTip1.SetToolTip(tbxSearch, "Type here what you want to search");
            toolTip1.SetToolTip(cbxSearch, "Select the field for what you want to search");
            toolTip1.SetToolTip(dtpSearch, "Select the date you want to seach for");
            toolTip1.SetToolTip(btnSearch, "Click to search for a customer");
            toolTip1.SetToolTip(btnEdit, "Click to edit the selected customer");
            toolTip1.SetToolTip(btnAdd, "Click to add a customer");
            toolTip1.SetToolTip(btnBalance, "Click to change balance of the selected customer (borrow/lend)");
            #endregion
            this.cbxSearch.SelectedIndex = 0;
            this.dtpSearch.Enabled = false;

            
        }

        private void FrmMainWindow_Load(object sender, EventArgs e)
        {
            FrmLogIn loginForm = new FrmLogIn();
            DialogResult res = loginForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                MessageBox.Show("Enabled!!");
                this.InitializeForm();
            }
            else
            {
                this.Close(); //The main application is closed, when the user
                //does not enter the right password but instead 
                //presses cancel! A different action does not make
                //sense.
            }
        }
        private bool InitializeForm()
        {
            bool initOK = true;
            //Check if File exists:
            bool dbExists = File.Exists(pathDB);
            try
            {
                if (dbExists)
                {
                    this.customers = ReadCustomerDB();
                    MessageBox.Show("Customers loaded successfully");
                    this.UpdateView();
                }
                else
                {
                    this.customers = new List<Customer>();
                    this.UpdateView();
                }
            }
            catch (Exception ex)
            {
                initOK = false;
                MessageBox.Show("Error occured: " + ex.Message);
                this.Close();
            }

            return initOK;
        }

        private void UpdateView()
        {
            this.lbxCustomer.Items.Clear();
            if (this.customers.Count > 0)
            {
                this.btnBalance.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnSearch.Enabled = true;
                this.btnBalance.Enabled = true;
                this.lbxCustomer.Enabled = true;
                foreach (Customer c in this.customers)
                {
                    this.lbxCustomer.Items.Add(c.ToVisualString());
                }
                this.lbxCustomer.SelectedIndex = 0;
            }
            else
            {
                this.btnBalance.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnSearch.Enabled = false;
                this.btnBalance.Enabled = false;
                this.lbxCustomer.Enabled = false;
                this.lbxCustomer.Items.Add("No Customer stored! Click -Add Customer-");
            }
        }

        //Encryption must be implemented!!!!
        #region Security Encrypt-Decrypt 
        private string EncryptDB()
        {
            string dbEncrypted = "";
            foreach( Customer cus in this.customers)
            {
                dbEncrypted += cus.ToString() + "\n";
            }

            return dbEncrypted;
        }

        //Should work! -- Not tested yet
        //private static string EncryptCustomer (Customer cus)
        //{
        //    string customerEncrypted = "";
        //    string[] fields = new string[] {
        //        cus.CustomerNumber.ToString(),
        //        cus.FirstName,
        //        cus.LastName,
        //        cus.EMailAdress,
        //        cus.DateLastChange.ToString(),
        //        cus.Balancing.ToString()
        //    };

        //    foreach (string field in fields)
        //    {
        //        #region Old Method:
        //        //foreach(char c in field)
        //        //{
        //        //    char newChar = (char)((c + 2 )%123);
        //        //    customerEncrypted += newChar;
        //        //    // A = 65, z = 122
        //        //}
        //        #endregion

        //        #region New Method:
        //        customerEncrypted += StringCipher.Encrypt(field, Passphrase);
        //        #endregion

        //        customerEncrypted += ";";
        //    }
        //    return customerEncrypted;
        //}

        //Should work!! not tested yet
        private static Customer DecryptCustomer(string input)
        {
            string customerDecrypted = "";
            string[] fields = input.Split(';');
            #region Old Method:
            foreach (char c in input)
            {
                if (c != ';')
                {
                    customerDecrypted += (char)((c - 2 + 123) % (123));
                }
                else
                {
                    customerDecrypted += ';';
                }
            }
            #endregion

            customerDecrypted = input;

            return GetCustomerFromInput(customerDecrypted);
        }
        #endregion

        #region Read and Write Customer DB
        private void WriteCustomerDB()
        {
            try
            {
                StreamWriter file = new StreamWriter(pathDB);
                file.Write(this.EncryptDB());
                file.Close();
            }
            catch
            {
                MessageBox.Show("Error: Writing not possible!");
            }
        }
        private List<Customer> ReadCustomerDB()
        {
            StreamReader file = new StreamReader(pathDB);
            string line = "";
            List<Customer> cList = new List<Customer>();
            while(file.Peek()>-1)
            {
                line = file.ReadLine();
                //line = StringCipher.Decrypt(line, Passphrase);
                cList.Add(DecryptCustomer(line));
            }
            file.Close();
            return cList; 
        }
#endregion

        private static Customer GetCustomerFromInput(string input)
        {
            string[] fields = input.Split(';');
            int CustomerNumber = Convert.ToInt32(fields[0]);
            string rFirstName = fields[1];
            string rLastName = fields[2];
            string rEmailAdress = fields[3];
            DateTime rDateLastChanged = Convert.ToDateTime(fields[5]);
            double rBalancing = Convert.ToDouble(fields[4]);
            return new Customer(rFirstName, rLastName, rEmailAdress, rDateLastChanged, rBalancing);
        }

        #region Click- Events:
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if((tbxSearch.Text != null && tbxSearch.Text.Length >0) || lbxCustomer.SelectedIndex == 3)
            {
                bool found = false;
                this.lbxCustomer.SelectedIndices.Clear();
                #region Searching:
                switch (this.cbxSearch.SelectedIndex)
                {
                        //Customer Number
                        //Email Adress
                        //Date of Last Change
                    case 0:
                        for (int i = 0; i < this.customers.Count; i++)
                        {
                            string fullName1 = customers[i].FirstName + " " + customers[i].LastName;
                            string fullName2 = customers[i].LastName + " " + customers[i].FirstName;
                            if (fullName1 == tbxSearch.Text || fullName2 == tbxSearch.Text)
                            {
                                this.lbxCustomer.SelectedIndices.Clear();
                                this.lbxCustomer.SelectedIndices.Add(i);
                                found = true;
                                break;
                            }
                            if (customers[i].FirstName.Contains(tbxSearch.Text) || customers[i].LastName.Contains(tbxSearch.Text))
                            {
                                this.lbxCustomer.SelectedIndices.Add(i);
                                found = true;
                            }
                        }
                        break;

                    case 1:
                        try
                        {
                            for (int i = 0; i < this.customers.Count; i++)
                            {

                                if (customers[i].CustomerNumber == Convert.ToInt32(tbxSearch.Text))
                                {
                                    this.lbxCustomer.SelectedIndices.Clear();
                                    this.lbxCustomer.SelectedIndices.Add(i);
                                    found = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error occured: " + ex.Message);
                        }
                        break;

                    case 2:
                        for (int i = 0; i < this.customers.Count; i++)
                        {
                            if (customers[i].EMailAdress == tbxSearch.Text)
                            {
                                this.lbxCustomer.SelectedIndices.Clear();
                                this.lbxCustomer.SelectedIndices.Add(i);
                                found = true;
                                break;
                            }
                            if (customers[i].EMailAdress.Contains(tbxSearch.Text))
                            {
                                this.lbxCustomer.SelectedIndices.Add(i);
                                found = true;
                            }
                        }
                        break;

                    case 3:
                       
                        for (int i = 0; i < this.customers.Count; i++)
                        {
                            if (customers[i].DateLastChange.Date == dtpSearch.Value.Date)
                            {
                                this.lbxCustomer.SelectedIndices.Add(i);
                                found = true;
                            }
                        }
                        break;

                    default:
                        MessageBox.Show("Error occured");
                        break;
                }
                #endregion
                if (!found)
                {
                    MessageBox.Show("Sorry, not found in database!");
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmEdit form = new FrmEdit(0, this.customers);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                this.UpdateView();
                this.WriteCustomerDB();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.lbxCustomer.SelectedIndices.Count > 1)
            {
                this.lbxCustomer.SelectedIndex = this.lbxCustomer.SelectedIndices[0];
            }
            FrmEdit editForm = new FrmEdit(1, this.customers, lbxCustomer.SelectedIndex);
            DialogResult res = editForm.ShowDialog();
            if(res == DialogResult.OK)
            {
                this.WriteCustomerDB();
                this.UpdateView();
            }
        }
        private void btnBalance_Click(object sender, EventArgs e)
        {
            if (this.lbxCustomer.SelectedIndices.Count > 1)
            {
                this.lbxCustomer.SelectedIndex = this.lbxCustomer.SelectedIndices[0];
            }
            FrmEdit editForm = new FrmEdit(2, this.customers, lbxCustomer.SelectedIndex);
            DialogResult res = editForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                this.WriteCustomerDB();
                this.UpdateView();
            }
        }
        #endregion

        private void cbxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSearch.SelectedIndex == 3)
            {
                this.dtpSearch.Enabled = true;
                this.tbxSearch.Enabled = false;
            }
            else
            {
                this.dtpSearch.Enabled = false;
                this.tbxSearch.Enabled = true;
            }
        }



        


       
    }
}
