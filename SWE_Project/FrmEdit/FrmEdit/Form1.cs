using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmEdit
{
    public partial class FrmEdit : Form
    {
        #region Variables
        //private reference to customerlist
        private List<Customer> customerList = new List<Customer>(); // later instead of string -> class Customer
        private int mode = 0;
        private int customer_ID = 0;
        private double amount = 0;
        private string[] errormassages = new string[] { "E-Mail-Adress is valid",
            "Does not contain exactly one '@'",
            "There is no '.' after '@'",
            "The final part (after last '.') is not 2-4 characters long",
            "The final part (after last '.') does not contain only letters",
            "There is no character before the '@'",
            "There is a '.' at the start, end or next to the '@'",
            "Includes invalid characters"};
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
                return (customer_ID);
            }
            set
            {
                this.customer_ID = value;
            }
        }
        #endregion

        public FrmEdit()
        {
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
                    tbxEMail.Enabled = false;
                    errorProvider1.Clear();
                    break;
                case 2: // Mode -> Balance
                    foreach (Control ctrl in gb1.Controls)
                    {
                        ctrl.Enabled = false;
                    }
                    errorProvider1.Clear();
                    // load data from customerList
                    amount = customerList[customer_ID].Balancing;
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
            amount += (double)nud.Value;
        }
        private void btnSub_Click(object sender, EventArgs e)
        {
            amount -= (double)nud.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (mode)
                {
                    case 0: // Mode -> New
                        if (tbxFirstname.Text != "" && tbxLastname.Text != "" && Customer.ValidateEMailAdress(customerList, tbxEMail.Text) == 0)
                        {

                            customerList.Add(new Customer(tbxFirstname.Text, tbxLastname.Text, tbxEMail.Text, customer_ID));
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

                    case 1: // Mode -> Edit
                        if (tbxFirstname.Text != "" && tbxLastname.Text != "")
                        {
                            customerList[customer_ID].FirstName = tbxFirstname.Text;
                            customerList[customer_ID].LastName = tbxLastname.Text;
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

                    case 2: // Mode -> Balance
                        customerList[customer_ID].Balancing = amount;
                        break;
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
            Application.Exit();
        }



        #region Methods
        // Methode in Class Customer 
        //private int ValidateEMailAdress(List<Customer> customerList, int customer_ID, string eMailAdress)
        //{
        //    int result = -1;
        //    return result;
        //}
        #endregion

     
    }
}
