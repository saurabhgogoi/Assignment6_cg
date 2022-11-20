using System;
namespace Delegates
{
    public class ICICI
    {
        public delegate void DelegateEventHandler();
        public static double balance = 30000.00;

        public static void Withdraw()
        {
            if (balance<=0 )
            {
                
                Console.WriteLine("Transaction Cannot be continued as balance is insufficient");
            }
            else
            {
                Console.WriteLine("Transaction Can be done ");            }
        }
        public static event DelegateEventHandler deh;
        public static void Main(string[] args)
        {
            deh += new DelegateEventHandler(Withdraw);
            deh.Invoke();
        }
    }
}
