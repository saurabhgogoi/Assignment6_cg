using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void Notify();
    internal class Account
    {
        public int Account_Number;
        public string Customer_Name;
        public int Balance;
        public int Amount;
        public event Notify BalanceZero;
        public event Notify UnderBalance;
        public void Diposit()
        {
            Console.WriteLine("enter account number");
            Account_Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter customer name");
            Customer_Name = Console.ReadLine();
            Console.WriteLine("enter amount to disposit");
            Balance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("balance amount is" + ":" + Balance);
        }
        public virtual void WithDraw()
        {

            Console.WriteLine("enter amount to withdrawl");
            Amount = Convert.ToInt32(Console.ReadLine());
            Balance = Balance - Amount;
            if (Balance == 0)
            {
                OnZeroBalance();
            }
            if (Balance < 1000)
            {
                Onunderbalance();
            }
            else if (Balance > 1000)
            {
                Console.WriteLine("your balance is" + ":" + Balance);
            }

        }
        protected virtual void OnZeroBalance()
        {
            BalanceZero?.Invoke();
        }
        protected virtual void Onunderbalance()
        {
            UnderBalance?.Invoke();
        }

    }

    class client
    {
        public static void Main()
        {
            Account account = new Account();
            account.BalanceZero += z1_ZeroBalance;
            account.UnderBalance += z2_underbalace;
            account.Diposit();
            account.WithDraw();
            Console.ReadKey();
        }

        public static void z1_ZeroBalance()
        {
            Console.WriteLine("Balance is zero");
        }
        public static void z2_underbalace()
        {
            Console.WriteLine("Now you have Underbalance");

        }
    }
}
