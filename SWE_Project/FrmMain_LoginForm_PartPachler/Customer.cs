using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmMain_LoginForm_PartPachler
{
    public class Customer
    {
        #region Membervariables, Variables and Constants
        private static int runningCustomerNumber = 0;

        private int customerNumber;
        private string firstName;
        private string lastName;
        private string eMailAdress;
        private double balancing;
        private DateTime dateLastChange;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor which is used to create a Customer Object which is not already in the database.
        /// The date of the last change is initialized to Datetime.Now and balancing is initialized to 0.0 which are the default values.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="eMailAdress"></param>
        public Customer(string firstName,
                        string lastName,
                        string eMailAdress)
        {
            this.CustomerNumber = runningCustomerNumber;
            runningCustomerNumber++;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EMailAdress = eMailAdress;
            this.Balancing = 0.0;
            this.DateLastChange = DateTime.Now;
        }

        /// <summary>
        /// Special Constructor to create a Customer Object out of already existing data.
        /// The date of date last change and the balancing are not initialized by default values.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="eMailAdress"></param>
        /// <param name="dateLastChanged"></param>
        /// <param name="balance"></param>
        public Customer(string firstName,
                        string lastName,
                        string eMailAdress,
                        DateTime dateLastChanged,
                        double balance)
        {
            this.CustomerNumber = runningCustomerNumber;
            runningCustomerNumber++;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EMailAdress = eMailAdress;
            this.Balancing = balance;
            this.dateLastChange = dateLastChanged; //there is no actual date of the last change so it do not need to be checked by the property
        }
        #endregion

        #region Properties
        public int CustomerNumber
        {
            get
            {
                return (this.customerNumber);
            }
            private set
            {
                this.customerNumber = value;
            }
        }

        /// <summary>
        /// This Property does not allow empty strings as input.
        /// </summary>
        /// <exception cref="ArgumentException">Exception is thrown if an empty string is written on the property.</exception>
        public string FirstName
        {
            get
            {
                return (this.firstName);
            }
            set
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException("FirstName does not allow empty string");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }

        /// <summary>
        /// This Property does not allow empty strings as input.
        /// </summary>
        /// <exception cref="ArgumentException">Exception is thrown if an empty string is written on the property.</exception>
        public string LastName
        {
            get
            {
                return (this.lastName);
            }
            set
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException("LastName does not allow empty string");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        /// <summary>
        /// This Property does not allow empty strings as input.
        /// </summary>
        /// <exception cref="ArgumentException">Exception is thrown if an empty string is written on the property.</exception>
        public string EMailAdress
        {
            get
            {
                return (this.eMailAdress);
            }
            set
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException("EMailAdress does not allow empty string");
                }
                else
                {
                    this.eMailAdress = value;
                }
            }
        }

        /// <summary>
        /// Changes in Balancing cause automatically an update of the date of the last change.
        /// </summary>
        public double Balancing
        {
            get
            {
                return (this.balancing);
            }
            set
            {
                this.balancing = value;
                this.DateLastChange = DateTime.Now;
            }
        }

        /// <summary>
        /// It is not allowed to change the date of the last change to an older one
        /// </summary>
        /// <exception cref="ArgumentException">Exception is thrown if the date of the last change should be changed to an older one</exception>
        public DateTime DateLastChange
        {
            get
            {
                return (this.dateLastChange);
            }
            set
            {
                if (DateTime.Compare(value, this.dateLastChange) >= 0)
                {
                    this.dateLastChange = value;
                }
                else
                {
                    throw new ArgumentException("Date is older than date of actual last change");
                }
            }
        }
        #endregion

        #region static Methods
        /// <summary>
        /// Validates the E-Mail Adress. There must be only one @ (Violation causes Errorcode -1). There must be at least one dot after the @.
        /// (Violation causes Errorcode -2). The part after the final dot must be at a length between 2 and 4.(Violation causes Errorcode -3)
        /// The final part must contain only letters. (Violation causes Errorcode -4). There must be at least one Character before the @.
        /// (Violation causes Errorcode -5). There is no dot at the start, end of next to the @. (Violation causes Errorcode -6).
        /// There must be no invalid Symbols. Valid Symbols are letters, digits and the following special symbols: 
        /// ".","!","#","$","%","&","'","*","+","-","/","=","?","^"," ","`","{","|","}","~","_","@". (Violations causes Errorcode -7).
        /// The E-Mail Adress must not be already listed in the system. (Violation causes Errorcode -8). A valid E-Mail Adress causes Errorcode 0.
        /// </summary>
        /// <param name="customerList"></param>
        /// <param name="eMailAdress"></param>
        /// <returns>Errorcode</returns>
        public static int ValidateEMailAdress(List<Customer> customerList, string eMailAdress)
        {
            int errorCode = 0;

            if (EMailAdressContainsExactlyOneAt(eMailAdress))
            {
                if (ContainsDotAfterAt(eMailAdress))
                {
                    if (LengthOfFinalPart(eMailAdress) >= 2
                        && LengthOfFinalPart(eMailAdress) <= 4)
                    {
                        if (FinalPartsContainsOnlyLetters(eMailAdress))
                        {
                            if (ContainsCharacterBeforeAt(eMailAdress))
                            {
                                if (NoDotsAtInvalidPosition(eMailAdress))
                                {
                                    if (NoInvalidSymbols(eMailAdress))
                                    {
                                        //Adress is valid
                                        if (EMailAdressNotListedYet(customerList, eMailAdress))
                                        {
                                            //Adress is new in List
                                            errorCode = 0;
                                        }
                                        else
                                        {
                                            //Adress is Listed
                                            errorCode = -8;
                                        }
                                    }
                                    else
                                    {
                                        errorCode = -7;
                                    }
                                }
                                else
                                {
                                    errorCode = -6;
                                }
                            }
                            else
                            {
                                errorCode = -5;
                            }
                        }
                        else
                        {
                            errorCode = -4;
                        }
                    }
                    else
                    {
                        errorCode = -3;
                    }
                }
                else
                {
                    errorCode = -2;
                }
            }
            else
            {
                errorCode = -1;
            }


            return (errorCode);
        }
        
        /// <summary>
        /// Checks if eMailAdress contains exactly one @
        /// </summary>
        /// <param name="eMailAdress"></param>
        /// <returns>true if there is only one @</returns>
        private static bool EMailAdressContainsExactlyOneAt(string eMailAdress)
        {
            bool result = true;

            if (eMailAdress.IndexOf('@') < 0)
            {
                result = false;
            }
            else
            {
                if (eMailAdress.IndexOf('@') != eMailAdress.LastIndexOf('@'))
                {
                    result = false;
                }
            }

            return (result);
        }

        /// <summary>
        /// Checks if there is a '.' in the part after the @
        /// </summary>
        /// <param name="eMailAdress"></param>
        /// <returns>true if there is a dot after the @</returns>
        private static bool ContainsDotAfterAt(string eMailAdress)
        {
            bool result = true;

            if (eMailAdress.IndexOf('@') > eMailAdress.LastIndexOf('.'))
            {
                result = false;
            }

            return (result);
        }

        /// <summary>
        /// Returns the number of characters after the last '.'
        /// </summary>
        /// <param name="eMailAdress"></param>
        /// <returns>lenght of the final part</returns>
        private static int LengthOfFinalPart(string eMailAdress)
        {
            int lastindex = (eMailAdress.LastIndexOf('.') + 1);
            return (eMailAdress.Length - (lastindex));
        }

        /// <summary>
        /// Checks if there are only Letters in the Part after the last '.'
        /// </summary>
        /// <param name="eMailAdress"></param>
        /// <returns>true if there are only letters in the final part</returns>
        private static bool FinalPartsContainsOnlyLetters(string eMailAdress)
        {
            bool result = true;
            char[] temp = eMailAdress.ToCharArray(eMailAdress.LastIndexOf('.') + 1,
                                                   LengthOfFinalPart(eMailAdress));

            for (int i = 0; i < temp.Length; i++)
            {
                if (!char.IsLetter(temp[i]))
                {
                    result = false;
                }
            }

            return (result);
        }

        /// <summary>
        /// Checks if there is a charakter before the @
        /// </summary>
        /// <param name="eMailAdress"></param>
        /// <returns>true if there is at least one character before the @</returns>
        private static bool ContainsCharacterBeforeAt(string eMailAdress)
        {
            bool result = false;

            if (eMailAdress.IndexOf('@') > 0)
            {
                char[] temp = eMailAdress.ToCharArray(0,
                                       eMailAdress.IndexOf('@'));

                for (int i = 0; i < temp.Length; i++)
                {
                    if (char.IsLetter(temp[i]))
                    {
                        result = true;
                    }
                }
            }

            return (result);
        }

        /// <summary>
        /// Check if there is no '.' at the start, end of next to the @
        /// </summary>
        /// <param name="eMailAdress"></param>
        /// <returns>true if there are no dots in invalid positions</returns>
        private static bool NoDotsAtInvalidPosition(string eMailAdress)
        {
            bool result = true;

            if (eMailAdress.IndexOf('.') == 0)
            {
                result = false;
            }
            else
            {
                if (eMailAdress.LastIndexOf('.') == eMailAdress.Length - 1)
                {
                    result = false;
                }
                else
                {
                    string[] temp = eMailAdress.Split('@');
                    if (temp[0].LastIndexOf('.') == temp[0].Length - 1
                        ||
                        temp[1].IndexOf('.') == 0)
                    {
                        result = false;
                    }
                }
            }

            return (result);
        }

        /// <summary>
        /// Checks if there are no invalid symbols
        /// </summary>
        /// <param name="eMailAdress"></param>
        /// <returns>true if there are only valid symbols</returns>
        private static bool NoInvalidSymbols(string eMailAdress)
        {
            bool result = true;
            string[] validSpecialSymbols = new string[]{".","!","#","$",
                                                        "%","&","'","*",
                                                        "+","-","/","=",
                                                        "?","^"," ","`",
                                                        "{","|","}","~","_","@"};
            char[] temp = eMailAdress.ToCharArray();

            for (int i = 0; i < temp.Length; i++)
            {
                if (!char.IsLetterOrDigit(temp[i])
                    && !validSpecialSymbols.Contains(temp[i].ToString()))
                {
                    result = false;
                }
            }

            return (result);
        }

        /// <summary>
        /// Checks if the E-Mail-Adress is already listed in the Customerlist
        /// </summary>
        /// <param name="customerList"></param>
        /// <param name="eMailAdress"></param>
        /// <returns>true if the E-Mail-Adress is not listed yet</returns>
        private static bool EMailAdressNotListedYet(List<Customer> customerList, string eMailAdress)
        {
            bool result = true;

            foreach (Customer customer in customerList)
            {
                if (customer.EMailAdress == eMailAdress)
                {
                    result = false;
                }
            }

            return (result);
        }
        #endregion

        #region dynamic Methods
        /// <summary>
        /// Creates a string which contains the data of one Customer Object for Output on GUI.
        /// </summary>
        /// <returns>GUI outputstring</returns>
        public string ToVisualString()
        {
            string result = String.Format(
                "{0,3} | {1,16} | {2,16} | {3,16} | {4,16:C2} | {5:d}",
                this.CustomerNumber, this.FirstName, this.LastName, this.EMailAdress,
                this.Balancing, this.DateLastChange
                );
            return (result);
        }

        /// <summary>
        /// Creates a string which contains the data of one Customer Object for storage in a .csv file.
        /// </summary>
        /// <returns>.csv outputstring</returns>
        public override string ToString()
        {
            string result =
                this.CustomerNumber.ToString() + ";"
                + this.FirstName + ";"
                + this.LastName + ";"
                + this.EMailAdress + ";"
                + this.Balancing.ToString() + ";"
                + this.DateLastChange.ToString("D");

            return (result);
        }
        #endregion

    }
}
