using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount_Week8_ProjectDay
{
   class Account
    {//instance variables - private modifier - store component of AccountsClass
        private decimal balance;
        private string accountType;
        private double accountNbr;
        private decimal transactionAmount;

        public Account(double accountNbr, Clients clients)
        {
           Clients = clients;
           Balance = 0m;
           TransactionAmount = transactionAmount;
           AccountNbr = accountNbr;
           accountType = "Savings";


        }

        //Properties
        public Clients Clients { get; set; }

        public decimal TransactionAmount
        {
            get
            {
                return transactionAmount;
            }
            set
            {
                transactionAmount = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        
        public string AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                accountType = value;

            }
        }



        public double AccountNbr
        {
            get
            {
                return accountNbr;
            }
            private set
            {
                accountNbr = value;
            }
        }


        //Methods

        public decimal GetAccountBalance()
        {
            return balance;
        }


        public double GetAccountNbr()
        {
            return accountNbr;
        }

        public decimal Withdraw()
        {
            if (balance >= transactionAmount)
            balance = balance - transactionAmount;
            return balance;
            
        }

        public decimal Deposit()
        {
            balance = balance + transactionAmount;
            return balance;

        }

    }

}
