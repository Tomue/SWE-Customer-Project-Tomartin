using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmMain_LoginForm_PartPachler
{
    public partial class FrmEdit : Form
    {
        #region Variables
        //private reference to customerlist
        private List<Customer> customerList = new List<Customer>(); // later instead of string -> class Customer
        private int mode = 0;
        private int customerID;
        private double amount = 0;
        private string[] errormassages = new string[] { "E-Mail-Adress is valid",
            "Does not contain exactly one '@'",
            "There is no '.' after '@'",
            "The final part (after last '.') is not 2-4 characters long",
            "The final part (after last '.') does not contain only letters",
            "There is no character before the '@'",
            "There is a '.' at the start, end or next to the '@'",
            "Includes invalid characters"};

        private bool btnAddClicked = false;
        private bool btnSubClicked = false;
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
        //...?
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
        #endregion
        // Test für Git

        public FrmEdit(int mode, List<Customer> cList, int cID=0)
        {
            this.mode = mode;
            this.customerID = cID;
            this.customerList = cList;
            InitializeComponent();
        }

        private void FrmEdit_Load(object sender, EventArgs e)
        {
            switch(mode)
            {
                case 0: // Mode -> New
                    foreach (Control ctrl in gb2.Controls)
                    {
                        ctrl.Enabled = false;
                    }
                    errorProvider1.Clear();
                    break;
                case 1: // Mode -> Edit
                    foreach (Control ctrl in gb2.Controls)
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
                    foreach (Control ctrl in gb1.Controls)
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
                        errorProvider1.SetError(gb1, excep.Message);
                    }
                    break;  
            }
                           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!btnAddClicked) amount += (double)nud.Value;
            btnAddClicked = true;
        }
        private void btnSub_Click(object sender, EventArgs e)
        {
            if (!btnSubClicked) amount -= (double)nud.Value;
            btnSubClicked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnAddClicked = false;
            btnSubClicked = false;

            try
            {
                switch (mode)
                {
                    #region New
                    case 0: // Mode -> New
                        if (tbxFirstname.Text != "" && tbxLastname.Text != "" && Customer.ValidateEMailAdress(customerList, tbxEMail.Text) == 0)
                        {

                            customerList.Add(new Customer(tbxFirstname.Text, tbxLastname.Text, tbxEMail.Text));
                            errorProvider1.Clear();
                        }
                        else if ((tbxFirstname.Text == "" || tbxLastname.Text == "") && Customer.ValidateEMailAdress(customerList, tbxEMail.Text) == 0)
                        {
                            // at least one textbox is emty
                            errorProvider1.Clear();
                            errorProvider1.SetError(gb1, "At least one textbox is emty!!");

                        }
                        else if (Customer.ValidateEMailAdress(customerList, tbxEMail.Text) < 0)
                        {
                            // Send Errormassage
                            errorProvider1.Clear();
                            errorProvider1.SetError(gb1, errormassages[Math.Abs(Customer.ValidateEMailAdress(customerList, tbxEMail.Text))]);
                        }
                        break;
                    #endregion
                    #region Edit
                    case 1: // Mode -> Edit
                        if (tbxFirstname.Text != "" && tbxLastname.Text != "")
                        {
                            customerList[customerID].FirstName = tbxFirstname.Text;
                            customerList[customerID].LastName = tbxLastname.Text;
                            // = tbxEMail.Text;
                            errorProvider1.Clear();
                        }
                        else if (tbxFirstname.Text == "" || tbxLastname.Text == "")
                        {
                            // at least one textbox is emty
                            errorProvider1.Clear();
                            errorProvider1.SetError(gb1, "At least one textbox is emty!!");

                        }
                        break;
                    #endregion
                    #region Balance
                    case 2: // Mode -> Balance
                        customerList[customerID].Balancing = amount;
                        break;
                    #endregion
                    default:
                        break;
                }

            }
            catch (Exception excep)
            {
                errorProvider1.SetError(gb1, excep.Message);
            }


        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Exit
            //Application.Exit(); //Keine Gute Idee!
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



        #region Methods
        // Methode in Class Customer 
        //private int ValidateEMailAdress(List<Customer> customerList, int customer_ID, string eMailAdress)
        //{
        //    int result = -1;
        //    return result;
        //}
        private void TestGithub()
        {
        }
        #endregion

     
    }
}
