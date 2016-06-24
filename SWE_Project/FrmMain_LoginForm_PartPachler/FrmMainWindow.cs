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
        #region Membervariables and Constants

        private const string PATH_DB = @"..\Database\cDB.csv"; //cDB...Customer Database
        public List<Customer> customers = new List<Customer>();

        #endregion

        #region Constructor, Load-Event and Initialization
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

        /// <summary>
        /// Loads the Login-Form and enables the Main-Form if the password is correct.
        /// Otherwise it closes the Form.
        /// </summary>
        /// <param name="sender">Form that is loaded</param>
        /// <param name="e">Form loaded event</param>
        private void FrmMainWindow_Load(object sender, EventArgs e)
        {
            //Fürs Testen kann die Passwortabfrage auskommentiert werden!!
            //this.InitializeForm();
            FrmLogIn loginForm = new FrmLogIn();
            DialogResult res = loginForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                MessageBox.Show("Enabled!!");
                this.InitializeForm();
                loginForm.Dispose();
                GC.Collect();
            }
            else
            {
                this.Close(); //The main application is closed, when the user
                //does not enter the right password but instead 
                //presses cancel! A different action does not make
                //sense.
            }
        }

        /// <summary>
        /// Initializes the Form, therefore checks if the database exists
        /// and loads the customers into the memory. If an error Occurs this 
        /// Method closes the form!
        /// </summary>
        /// <returns></returns>
        private bool InitializeForm()
        {
            bool initOK = true;
            //Check if File exists:
            bool dbExists = File.Exists(PATH_DB);
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
        #endregion



        #region Security Encrypt-Decrypt
        private string EncryptDB()
        {
            string dbEncrypted = "";
            foreach (Customer cus in this.customers)
            {
                dbEncrypted += EncryptCustomer(cus) + "\n";
            }

            return dbEncrypted;
        }
        /// <summary>
        /// Encrypts a customer with the method of Cäsar
        /// </summary>
        /// <param name="cus">Object of class Customer not null!</param>
        /// <returns>Encrypted customer string</returns>
        private static string EncryptCustomer(Customer cus)
        {
            string customerEncrypted = "";
            if (cus != null)
            {
                string sAlphabet =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#$%&'*+-/=?^_`{|}~.ÄäöÖüÜ@";
                int nSizeAlphabet = sAlphabet.Length;
                int nIndexChar = 0;
                //string[] fields = new string[] {
                //    cus.CustomerNumber.ToString(),
                //    cus.FirstName,
                //    cus.LastName,
                //    cus.EMailAdress,
                //    cus.DateLastChange.ToString(),
                //    cus.Balancing.ToString()
                //};

                //==================Version: Optimized Memory
                #region Customer Number:
                for (int i = 0; i < cus.CustomerNumber.ToString().Length; i++)
                {
                    nIndexChar = sAlphabet.IndexOf( cus.CustomerNumber.ToString()[i]);
                    if (nIndexChar >= 0)
                    {
                        //Buchstabe/Zeichen enthalten!
                        customerEncrypted += sAlphabet[(nIndexChar + 3) % nSizeAlphabet];
                        // der Neue Buchstabe ist einfach um 3 Buchstaben versetzt.
                        // Wird das Ende des Alphabets erreicht wird von vorne wieder begonnen.
                    }
                    else
                    {
                        //Buchstabe/Zeichen nicht enthalten
                        customerEncrypted += cus.CustomerNumber.ToString()[i];
                    }
                }
                #endregion
                customerEncrypted += ";";
                #region First Name:
                for (int i = 0; i < cus.FirstName.Length; i++)
                {
                    nIndexChar = sAlphabet.IndexOf(cus.FirstName[i]);
                    if (nIndexChar >= 0)
                    {
                        //Buchstabe/Zeichen enthalten!
                        customerEncrypted += sAlphabet[(nIndexChar + 3) % nSizeAlphabet];
                        // der Neue Buchstabe ist einfach um 3 Buchstaben versetzt.
                        // Wird das Ende des Alphabets erreicht wird von vorne wieder begonnen.
                    }
                    else
                    {
                        //Buchstabe/Zeichen nicht enthalten
                        customerEncrypted += cus.FirstName[i];
                    }
                }
                #endregion
                customerEncrypted += ";";
                #region Last Name:
                for (int i = 0; i < cus.LastName.Length; i++)
                {
                    nIndexChar = sAlphabet.IndexOf(cus.LastName[i]);
                    if (nIndexChar >= 0)
                    {
                        //Buchstabe/Zeichen enthalten!
                        customerEncrypted += sAlphabet[(nIndexChar + 3) % nSizeAlphabet];
                        // der Neue Buchstabe ist einfach um 3 Buchstaben versetzt.
                        // Wird das Ende des Alphabets erreicht wird von vorne wieder begonnen.
                    }
                    else
                    {
                        //Buchstabe/Zeichen nicht enthalten
                        customerEncrypted += cus.LastName[i];
                    }
                }
                #endregion
                customerEncrypted += ";";
                #region EMailAdress:
                for (int i = 0; i < cus.EMailAdress.Length; i++)
                {
                    nIndexChar = sAlphabet.IndexOf(cus.EMailAdress[i]);
                    if (nIndexChar >= 0)
                    {
                        //Buchstabe/Zeichen enthalten!
                        customerEncrypted += sAlphabet[(nIndexChar + 3) % nSizeAlphabet];
                        // der Neue Buchstabe ist einfach um 3 Buchstaben versetzt.
                        // Wird das Ende des Alphabets erreicht wird von vorne wieder begonnen.
                    }
                    else
                    {
                        //Buchstabe/Zeichen nicht enthalten
                        customerEncrypted += cus.EMailAdress[i];
                    }
                }
                #endregion
                customerEncrypted += ";";
                #region DateLastChange:
                for (int i = 0; i < cus.DateLastChange.ToString().Length; i++)
                {
                    nIndexChar = sAlphabet.IndexOf(cus.DateLastChange.ToString()[i]);
                    if (nIndexChar >= 0)
                    {
                        //Buchstabe/Zeichen enthalten!
                        customerEncrypted += sAlphabet[(nIndexChar + 3) % nSizeAlphabet];
                        // der Neue Buchstabe ist einfach um 3 Buchstaben versetzt.
                        // Wird das Ende des Alphabets erreicht wird von vorne wieder begonnen.
                    }
                    else
                    {
                        //Buchstabe/Zeichen nicht enthalten
                        customerEncrypted += cus.DateLastChange.ToString()[i];
                    }
                }
                #endregion
                customerEncrypted += ";";
                #region Balancing:
                for (int i = 0; i < cus.Balancing.ToString().Length; i++)
                {
                    nIndexChar = sAlphabet.IndexOf(cus.Balancing.ToString()[i]);
                    if (nIndexChar >= 0)
                    {
                        //Buchstabe/Zeichen enthalten!
                        customerEncrypted += sAlphabet[(nIndexChar + 3) % nSizeAlphabet];
                        // der Neue Buchstabe ist einfach um 3 Buchstaben versetzt.
                        // Wird das Ende des Alphabets erreicht wird von vorne wieder begonnen.
                    }
                    else
                    {
                        //Buchstabe/Zeichen nicht enthalten
                        customerEncrypted += cus.Balancing.ToString()[i];
                    }
                }
                #endregion
                customerEncrypted += ";";
                //===================End====================

                //foreach (string field in fields)
                //{
                //    foreach (char c in field)
                //    {
                //        nIndexChar = sAlphabet.IndexOf(c);
                //        if (nIndexChar >= 0)
                //        {
                //            //Buchstabe/Zeichen enthalten!
                //            customerEncrypted += sAlphabet[(nIndexChar + 3) % nSizeAlphabet];
                //            // der Neue Buchstabe ist einfach um 3 Buchstaben versetzt.
                //            // Wird das Ende des Alphabets erreicht wird von vorne wieder begonnen.
                //        }
                //        else
                //        {
                //            //Buchstabe/Zeichen nicht enthalten
                //            customerEncrypted += c;
                //        }
                //    }

                //    customerEncrypted += ";";
                //}
            }
            return customerEncrypted;
        }

        /// <summary>
        /// Decrypts a customer string and generates a new customer with the data
        /// </summary>
        /// <param name="input">string that was created by the encrypt customer method</param>
        /// <returns>Customer restored from the string</returns>
        private static Customer DecryptCustomer(string input)
        {
            string sAlphabet =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#$%&'*+-/=?^_`{|}~.ÄäöÖüÜ@";
            int nSizeAlphabet = sAlphabet.Length;
            int nIndexChar = 0;
            string sDecryptCustomerString = "";

            for (int i = 0; i < input.Length; i++)
            {
                nIndexChar = sAlphabet.IndexOf(input[i]);
                if (nIndexChar >= 0)
                {
                    sDecryptCustomerString += sAlphabet[(nIndexChar - 3 + nSizeAlphabet) % nSizeAlphabet];
                }
                else
                {
                    sDecryptCustomerString += input[i];
                }
            }
            return GetCustomerFromInput(sDecryptCustomerString);
        }
        #endregion

        #region Read and Write Customer DB
        /// <summary>
        /// Writes all Customers from the actual list
        /// to a encrypted .csv file
        /// </summary>
        private void WriteCustomerDB()
        {
            StreamWriter file = new StreamWriter(PATH_DB);
            try
            {
                file.Write(this.EncryptDB());
                file.Close();

            }
            catch
            {
                MessageBox.Show("Error: Writing not possible!");
                file.Close();
            }
            finally
            {
                file.Dispose();
                GC.Collect();
            }
        }

        /// <summary>
        /// Reads the list of customers from the encrypted csv-file with
        /// the path specified in PATH_DB
        /// </summary>
        /// <returns>List of Customers restored from file</returns>
        private List<Customer> ReadCustomerDB()
        {
            StreamReader file = new StreamReader(PATH_DB);
            string line = "";
            List<Customer> cList = new List<Customer>();
            while (file.Peek() > -1)
            {
                line = file.ReadLine();
                cList.Add(DecryptCustomer(line));
            }
            file.Close();
            file.Dispose();
            GC.Collect();
            return cList;
        }

        /// <summary>
        /// Generates a new Cutstomer out of a special string
        /// </summary>
        /// <param name="input">string that follows the convention:
        ///                     'CustomerNumber';'FirstName';'LastName';'EmailAdress';'DateLastChanged';'Balancing'</param>
        /// <returns></returns>
        private static Customer GetCustomerFromInput(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                //string[] fields = input.Split(';');
                //int CustomerNumber = Convert.ToInt32(fields[0]);
                //string rFirstName = fields[1];
                //string rLastName = fields[2];
                //string rEmailAdress = fields[3];
                //DateTime rDateLastChanged = Convert.ToDateTime(fields[4]);
                //double rBalancing = Convert.ToDouble(fields[5]);
                //return new Customer(rFirstName, rLastName, rEmailAdress, rDateLastChanged, rBalancing);

                //==========Method of optimized memory:
                string[] fields = input.Split(';');
                return new Customer(fields[1], fields[2], fields[3], Convert.ToDateTime(fields[4]), Convert.ToDouble(fields[5]));
                //================End===========
            }
            else
            {
                throw new ArgumentException("Falsches Datenformat bei input in GetCustomerFromInput(input)");
            }
        }
        #endregion



        #region Click- Events:
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if ((tbxSearch.Text != null && tbxSearch.Text.Length > 0) || lbxCustomer.SelectedIndex == 3) // Index 3 = Search for DateLastChanged
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
                            if (fullName1.ToLower() == tbxSearch.Text.ToLower() || fullName2.ToLower() == tbxSearch.Text.ToLower())
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
            form.Dispose();
            GC.Collect();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.lbxCustomer.SelectedIndices.Count > 1)
            {
                this.lbxCustomer.SelectedIndex = this.lbxCustomer.SelectedIndices[0];
            }
            FrmEdit editForm = new FrmEdit(1, this.customers, lbxCustomer.SelectedIndex);
            DialogResult res = editForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                this.WriteCustomerDB();
                this.UpdateView();
            }
            editForm.Dispose();
            GC.Collect();
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
            editForm.Dispose();
            GC.Collect();
        }
        #endregion

        #region Other Form Events and Methods
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
        #endregion
    }
}
