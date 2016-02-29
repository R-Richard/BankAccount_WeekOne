using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace BankAccount_Week8_ProjectDay
{
    class Program
    {
        static void Main(string[] args)
        {

            Clients clientName = new Clients();

            StringBuilder act = new StringBuilder();
            Random rand = new Random();
            for (int i = 1; i <= 10; i++)
            {
                act.Append(rand.Next(9));
            }
            string x = (act.ToString());
            double y = Convert.ToDouble(x);

            Account accountNbr = new Account(y, new Clients());

            StreamWriter writer = new StreamWriter("AccountSummary.txt");
            using (writer)
            {
                writer.WriteLine(accountNbr.AccountType + " Account Summary");
                writer.WriteLine("Client Name: " + clientName.GetFullName());
                writer.WriteLine("Client Account Number: " + accountNbr.GetAccountNbr());
                writer.WriteLine("KEY: (SB=Start Balance) (TT=Trans Type) (TA=Trans Amt) (EB=End Balance)\r\n");
            }
                bool restart = true;
            {
                while (restart == true)
                {
                   Header();
                    {
                        Console.WriteLine("\nEnter Menu Item Number");
                        string menuItem = Console.ReadLine();

                        int userInput;
                        userInput = NumberCheck(menuItem);
                        int caseRestart = 0;
                        while (caseRestart == 0)
                        {
                            switch (userInput)
                            {
                                case 1: //View Client Information
                                    do
                                    {
                                        Console.Clear();
                                        Header();
                                      
                                        Console.WriteLine("Client Information:\n");
                                        
                                        Console.Write("Client Full Name: ");
                                        Console.WriteLine(clientName.GetFullName());
                                        Console.Write("Client First Name: ");
                                        Console.WriteLine(clientName.ClientFirstName);
                                        Console.WriteLine("Client Last Name: " + clientName.ClientLastName);
                                        Console.WriteLine("Client Phone: " + clientName.ClientContactPhone);
                                  
                                        userInput = DoNext(menuItem);

                                        Console.Clear();
                                        Header();
                                        continue;

                                    }
                                    while (userInput == 1);
                                    break;

                                case 2: //View Account Balance
                                    do
                                    {
                                    Console.Clear();
                                    Header();
                                        Console.WriteLine("Account Type: " + accountNbr.AccountType);
                                         Console.WriteLine("Account Nbr: " + accountNbr.GetAccountNbr());
                           
                                        string AccountAsCurrency = string.Format("${0:n}", accountNbr.GetAccountBalance());
                                        Console.WriteLine("Account Balance: " + AccountAsCurrency);

                                        userInput = DoNext(menuItem);

                                        Console.Clear();
                                        Header();
                                        continue;
                                    }
                                    while (userInput == 2);
                                    break;

                                case 3://Deposit Funds
                                    do
                                    {
                                        Console.Clear();
                                        Header();
                                        Console.WriteLine("Client Full Name: " + (clientName.GetFullName()));
                                        Console.WriteLine("Account Type: " + accountNbr.AccountType);
                                        Console.WriteLine("Account Nbr: " + accountNbr.GetAccountNbr());

                                        string AccountAsCurrency = string.Format("${0:n}", accountNbr.GetAccountBalance());
                                        Console.WriteLine("Account Balance: " + AccountAsCurrency);


                                        Console.WriteLine("\nHow Much Money Would You Like To Deposit?");

                                        string userinput = Console.ReadLine();
                                        NullOrWhiteSpace(userinput);
                                        decimal usercheck = NumberCheckDec(userinput);

                                        decimal deposit = Convert.ToDecimal(usercheck);

                                        accountNbr.TransactionAmount = deposit;
                                        string depositAsCurrency = string.Format("${0:n}", deposit);
                                        accountNbr.Deposit();
                                        Console.WriteLine("\nThe Completed Transaction Has Been Printed To Your Account Summary");
                                        Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", accountNbr.GetAccountBalance()));

                                        File.AppendAllText("AccountSummary.txt","\r\n" + DateTime.Now);
                                        File.AppendAllText("AccountSummary.txt","  SB: " + string.Format("${0:n}", (accountNbr.Balance - deposit)));
                                        File.AppendAllText("AccountSummary.txt", "  TT: (+)  ");
                                        File.AppendAllText("AccountSummary.txt",  "  TA: " + depositAsCurrency );
                                        File.AppendAllText("AccountSummary.txt", "  EB: " + string.Format("${0:n}", accountNbr.GetAccountBalance()) + "\r\n");
                                        writer.Close();
                                 

                                        userInput = DoNext(menuItem);
                                        Console.Clear();
                                        Header();
                                        continue;
                                    }
                                    while (userInput == 3);
                                    break;
                                case 4:// Withdraw Funds
                                    do
                                    {
                                        Console.Clear();
                                        Header();
                                        Console.WriteLine("Client Full Name: " + (clientName.GetFullName()));
                                        Console.WriteLine("Account Type: " + accountNbr.AccountType);
                                        Console.WriteLine("Account Nbr: " + accountNbr.GetAccountNbr());

                                        string AccountAsCurrency = string.Format("${0:n}", accountNbr.GetAccountBalance());
                                        Console.WriteLine("Account Balance: " + AccountAsCurrency);

                                        Console.WriteLine("\nHow Much Money Would You Like To Withdraw?");
                                        string userinput = Console.ReadLine();
                                        NullOrWhiteSpace(userinput);
                                       decimal usercheck = NumberCheckDec(userinput);
                                       
                                        decimal deposit = Convert.ToDecimal(usercheck);

                                        accountNbr.TransactionAmount = deposit;
                                        string depositAsCurrency = string.Format("${0:n}", deposit);
                                        if (accountNbr.Balance >= deposit)
                                        {
                                            accountNbr.Withdraw();
                                            Console.WriteLine("\nThe Completed Transaction Has Been Printed To Your Account Summary");
                                            Console.WriteLine("Current Account Balance: " + string.Format("${0:n}", accountNbr.GetAccountBalance()));
                        
                                            File.AppendAllText("AccountSummary.txt", "\r\n" + DateTime.Now);
                                            File.AppendAllText("AccountSummary.txt", "  SB: " + string.Format("${0:n}", (accountNbr.Balance + deposit)));
                                            File.AppendAllText("AccountSummary.txt", "  TT: (-)  ");
                                            File.AppendAllText("AccountSummary.txt", "  TA: " + depositAsCurrency);
                                            File.AppendAllText("AccountSummary.txt", "  EB: " + string.Format("${0:n}", accountNbr.GetAccountBalance()) + "\r\n");
                                            writer.Close();
                                            userInput = DoNext(menuItem);
                                            Console.Clear();
                                            Header();
                                            continue;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nYou Do Not Have The Funds To Complete This Transaction");
                                            userInput = DoNext(menuItem);
                                            Console.Clear();
                                            Header();
                                            continue;
                                        }
                                    }
                                    while (userInput == 4);
                                    break;


                                case 5:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nFile Export Preview\n");
                                        using (StreamReader sr = File.OpenText("AccountSummary.txt"))
                                        {
                                            string s = "";
                                            while ((s = sr.ReadLine()) != null)
                                            {
                                            Console.WriteLine(s);
                                            }

                                            Header();
                                            userInput = DoNext(menuItem);
                                            continue;
                                        }
                                    }
                                    while (userInput == 5);
                                    break;

                                case 6://Exit
                                    {
                                        Console.WriteLine("\nAre you sure you want to exit? \nPress \"N\" to restart program\nPress any other key to exit");

                                        string restartAsString = Console.ReadLine();

                                        userInput = NumberCheck(menuItem);

                                        if (restartAsString.Equals("n", StringComparison.CurrentCultureIgnoreCase))
                                        {

                                            caseRestart++;
                                            Console.Clear();
                                            Header();
                                            break;
                                        }
                                        else
                                        {

                                            Console.Clear();
                                            Console.WriteLine("GoodBye");
                                            Thread.Sleep(1000);
                                            Environment.Exit(0);
                                        }
                                        break;

                                    }
                                default:
                                    {
                                        Console.WriteLine("\nThat is not a Valid Entry");
                                        userInput = DoNext(menuItem);
                                        Console.Clear();
                                        Header();

                                        break;
                                    }
                            }
                        }

                    }
                }
            }
        }


        /// //////////////////////////////////////////////////////////Null or WhiteSpace
 

        static void NullOrWhiteSpace(string stringInput)
        {
            bool a;

            a = string.IsNullOrWhiteSpace(stringInput);

            if (a == true)
            {
                Console.WriteLine("Error: Request Unavailable");

            }

        }

        ///////////////////////////////////////////////////////////////////Number Check Method///////////////////////////////////////////

        static int NumberCheck(string input)
        {
            int menuItem;

            do
            {

                bool numVer = int.TryParse(input, out menuItem);
                if ((menuItem != 0))
                {
                    return menuItem;
                }
                else if (menuItem == 0)
                {
                    Console.WriteLine("That is not a valid entry, pleae enter a number");
                    input = Console.ReadLine();
                }
            }
            while (menuItem == 0);
            return menuItem;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////HEADER METHOD/////////////////////////////////////////////////////////////////
        static void Header()
        {
            // Console.Clear();
            StringBldrLine();
            string title = "Banking Account";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title + "\n\n", Console.Title);

            Console.WriteLine("Main Menu");
            Console.WriteLine("1: View Client Information");
            Console.WriteLine("2: View Account Balance");
            Console.WriteLine("3: Deposit Funds");
            Console.WriteLine("4: Withdraw Funds");
            Console.WriteLine("5: View Transaction History");
            Console.WriteLine("6: Exit");
            StringBldrLine();
        }
        //////////////////////////////////////////Do Next METHOD/////////////////////////////////////////////////////////////////
        static int DoNext(string menuItem)

        {
            int userInput;
            Console.WriteLine("\nWhat would you like to do next? Enter a menu number:");
            menuItem = Console.ReadLine();

            userInput = NumberCheck(menuItem);

            return userInput;

        }

        //////////////////////////////////////////StringBldrLine METHOD/////////////////////////////////////////////////////////////////
        static void StringBldrLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("*");
            for (int i = 1; i <= 79; i++)
            {
                sb.Append("*");
            }
            Console.WriteLine(sb);
        }


        ///////////////////////////////////////////////////////////////////Number Check Method - Decimal///////////////////////////////////////////

        static decimal NumberCheckDec(string input)
        {
           
            decimal userinput;
            do
            {

                bool numVer = decimal.TryParse(input, out userinput);
                if ((userinput != 0))
                {
                    return userinput;
                }
                else if (userinput == 0)
                {
                    Console.WriteLine("That is not a valid entry, please enter a dollar amount");
                    input = Console.ReadLine();
                }
            }
            while (userinput == 0);
            return userinput;
        }


    }  
}
        
    

    


