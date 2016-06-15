using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FrmMain_LoginForm_PartPachler
{
    public partial class FrmEdit : Form
    {
        #region Membervariables, Variables and Constants

        private List<Customer> customerList = new List<Customer>(); 
        private int mode = 0;
        private int customerID;

        private double amount = 0;
        private int eMailErrorCode = 0;
        private bool btnAddClicked = false;
        private bool btnSubClicked = false;
        private string[] errormassages = new string[] { "E-Mail-Adress is valid",
            "Does not contain exactly one '@'",
            "There is no '.' after '@'",
            "The final part (after last '.') is not 2-4 characters long",
            "The final part (after last '.') does not contain only letters",
            "There is no character before the '@'",
            "There is a '.' at the start, end or next to the '@'",
            "Includes invalid characters"};

        Stopwatch timeForNewCusEDITload = new Stopwatch();
        Stopwatch timeForNewCusEDITsave = new Stopwatch();
        #endregion

        #region Properties

        public TextBox TbxFirstname
        {
            get
            {
                return (tbxFirstname);
            }
            set
            {
                this.tbxFirstname = value;
            }
        }
        public int Mode
        {
            get
            {
                return (Mode);
            }
            set
            {
                this.mode = value;
            }
        }
        public int Customer_ID
        {
            get
            {
                return (customerID);
            }
            set
            {
                this.customerID = value;
            }
        }
        public Stopwatch TimeForNewCusEDITload
        {
            get
            {
                return (timeForNewCusEDITload);
            }
        }
        public Stopwatch TimeForNewCusEDITsave
        {
            get
            {
                return (timeForNewCusEDITsave);
            }
        }
        #endregion

        #region Constructor

        public FrmEdit(int mode, List<Customer> cList, int cID=0)
        {
            this.mode = mode;
            this.customerID = cID;
            this.customerList = cList;
            InitializeComponent();
        }
        #endregion

        #region Load Event

        /// <summary>
        /// Loads data from DB and enables groupBoxes, depending on whitch operation 
        /// was chosen in the FrmMainWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEdit_Load(object sender, EventArgs e)
        {
            switch(mode)
            {
                case 0: // Mode -> New
                    TimeForNewCusEDITload.Reset();
                    TimeForNewCusEDITload.Start(); // Start Zeitlauf

                    foreach (Control ctrl in groupBox2.Controls)
                    {
                        ctrl.Enabled = false;
                    }
                    errorProvider1.Clear();

                    TimeForNewCusEDITload.Stop(); // Ende Zeitlauf
                                                  //TimeSpan timeSpan = timeForNewCusEDIT.Elapsed;
                    break;
                case 1: // Mode -> Edit
                    foreach (Control ctrl in groupBox2.Controls)
                    {
                        ctrl.Enabled = false;
                    }
                    tbxFirstname.Text = customerList[Customer_ID].FirstName;
                    tbxLastname.Text = customerList[Customer_ID].LastName;
                    tbxEMail.Text = customerList[Customer_ID].EMailAdress;
                    tbxEMail.Enabled = false;
                    errorProvider1.Clear();
                    break;
                case 2: // Mode -> Balance
                    foreach (Control ctrl in goupBox1.Controls)
                    {
                        ctrl.Enabled = false;
                    }
                    errorProvider1.Clear();
                    tbxFirstname.Text = customerList[Customer_ID].FirstName;
                    tbxLastname.Text = customerList[Customer_ID].LastName;
                    tbxEMail.Text = customerList[Customer_ID].EMailAdress;
                    // load data from customerList
                    amount = customerList[customerID].Balancing;
                    break;
                default:
                    try
                    {
                        Exception exept = new Exception("Mode does not exist!");
                        throw exept;
                    }
                    catch (Exception excep)
                    {
                        errorProvider1.SetError(goupBox1, excep.Message);
                    }
                    break;  
            }
                           
        }
        #endregion

        #region Click- Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!btnAddClicked)
            {
                amount += (double)nud.Value;
            }
            btnAddClicked = true;
        }
        private void btnSub_Click(object sender, EventArgs e)
        {
            if (!btnSubClicked)
            {
                amount -= (double)nud.Value;
            }
            btnSubClicked = true;
        }

        /// <summary>
        /// Before the changed data is saved the email adress will be checked with the function ValidateEMailAdress from the class Customer.
        /// The possible errorcodes are shown in an errorprovider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnAddClicked = false;
            btnSubClicked = false;

            try
            {
                switch (mode)
                {
                    #region New Customer
                    case 0: // Mode -> New
                        TimeForNewCusEDITsave.Reset();
                        TimeForNewCusEDITsave.Start(); // Start Zeitlauf

                        eMailErrorCode = Customer.ValidateEMailAdress(customerList, tbxEMail.Text);


                        if (tbxFirstname.Text != "" && tbxLastname.Text != "" && eMailErrorCode == 0)
                        {

                            customerList.Add(new Customer(tbxFirstname.Text, tbxLastname.Text, tbxEMail.Text));
                            errorProvider1.Clear();
                            this.DialogResult = DialogResult.OK;
                        }
                        else if ((tbxFirstname.Text == "" || tbxLastname.Text == "") && eMailErrorCode == 0)
                        {
                            // at least one textbox is emty
                            errorProvider1.Clear();
                            errorProvider1.SetError(goupBox1, "At least one textbox is emty!!");

                        }
                        else if (Customer.ValidateEMailAdress(customerList, tbxEMail.Text) < 0) // wenn errorcodes neg sind nur hier > zu < ändern!!!!!!!!
                        {
                            // Send Errormassage
                            errorProvider1.Clear();
                            errorProvider1.SetError(goupBox1,"Error Code: " + eMailErrorCode + 
                                                             " -> " + errormassages[Math.Abs(eMailErrorCode)]);
                        }

                        TimeForNewCusEDITsave.Stop(); // Ende Zeitlauf
                        //TimeSpan timeSpan = timeForNewCusEDIT.Elapsed;
                        break;
                    #endregion
                    #region Edit Customer
                    case 1: // Mode -> Edit
                        if (tbxFirstname.Text != "" && tbxLastname.Text != "")
                        {
                            customerList[customerID].FirstName = tbxFirstname.Text;
                            customerList[customerID].LastName = tbxLastname.Text;
                            errorProvider1.Clear();
                            this.DialogResult = DialogResult.OK;
                        }
                        else if (tbxFirstname.Text == "" || tbxLastname.Text == "")
                        {
                            // at least one textbox is emty
                            errorProvider1.Clear();
                            errorProvider1.SetError(goupBox1, "At least one textbox is emty!!");

                        }
                        break;
                    #endregion
                    #region Balance Customer
                    case 2: // Mode -> Balance
                        customerList[customerID].Balancing = amount;
                        this.DialogResult = DialogResult.OK;
                        break;
                    #endregion
                    default:
                        break;
                }
            }
            // catches exceptions form class Customer
            catch (Exception excep)
            {
                errorProvider1.SetError(goupBox1, excep.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Exit
            //Application.Exit(); //Keine Gute Idee!
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}
