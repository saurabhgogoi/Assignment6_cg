using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Delegates
{
    public delegate void ManagerSalary(double _sal);
    public delegate void MarketingExeSal(double _sal);

    public class MulticastDelegate
    {
        public double _Petrol;
        public double _Food;
        public double _Others;
        public double _sal;
        public double _Gross;
        public double _Netsal;
        public double Pf;
        public double TDS;

        public void ManagerSalary(double _sal)
        {
            Console.WriteLine("The Manager Salary is:{0}", _sal);

        }
        public void FoodDetails(double _sal)
        {
            _Food = _sal * 0.13;
            Console.WriteLine("The Food Allowances:"+ _Food);
        

        }
        public void PetrolDetails(double _sal)
        {
            _Petrol = _sal * 0.08;
            Console.WriteLine("The Petrol Allowances:{0}", _Petrol);

        }
        public void OtherDetails(double _sal)
        {
            _Others = _sal * 0.03;
            Console.WriteLine("The Other Allowances:{0}",_Others);
     

        }
        public void GrossSalaryDetails(double _sal)
        {
            _Gross = _sal + _Food + _Petrol + _Others;
            Console.WriteLine("The Gross Salary is:{0}", _Gross);

        }
        public void CalculateSalaryDetails(double _sal)
        {
            Pf = (_Gross * 0.10);
            TDS = (_Gross * 0.18);
            _Netsal = _Gross - (Pf + TDS);
            Console.WriteLine("The Net Salary is:{0}",_Netsal);

        }
    }
    public class MarketingExecutive
    {
        private double KM;
        private double TourAllowances;
        private double TelephoneAllowances;
        private double Netsal, Pf, TDS, Gross;
        public void MarketingExecutiveSalary(double MSal)
        {
            Console.WriteLine("The Salary of Marketing Executive is:{0}", MSal);
        }
        public void MEGrosssalary(double MSal)
        {
            Console.Write("Enter the Total Kilometers Covered:");
            KM = Convert.ToDouble(Console.ReadLine());
            TourAllowances = 5 * KM;
            TelephoneAllowances = 1000;
            Gross = MSal + TourAllowances + TelephoneAllowances;
            Console.WriteLine("The Gross Salary of Marketing Executive is:{0}", Gross);
        }

        public void MECalculateSalary(double MSal)
        {
            Pf = (Gross * 0.10);
            TDS = (Gross * 0.18);
            Netsal = Gross - (Pf + TDS);
            Console.WriteLine("The Net Salary of Marketing Executive is:{0}", Netsal);


        }
    }
    class Test
    {

        public static void Main(string[] args)
        { 
            MulticastDelegate m = new MulticastDelegate();
            ManagerSalary ms = new ManagerSalary(m.ManagerSalary);
            Console.WriteLine("Enter the salary:");
            double Sal = Convert.ToDouble(Console.ReadLine());
            ms+= new ManagerSalary(m.FoodDetails);
            ms+=new ManagerSalary(m.GrossSalaryDetails);
            ms += new ManagerSalary(m.PetrolDetails);
            ms+=new ManagerSalary(m.OtherDetails);
            ms+=new ManagerSalary(m.GrossSalaryDetails);
            ms += new ManagerSalary(m.CalculateSalaryDetails);
            ms(Sal);
            MarketingExecutive e = new MarketingExecutive();
            MarketingExeSal me = new MarketingExeSal(e.MarketingExecutiveSalary);
            Console.WriteLine("Enter the Salry:");
            me+=new MarketingExeSal(e.MEGrosssalary);
            me += new MarketingExeSal(e.MECalculateSalary);
            double MSal = Convert.ToInt32(Console.ReadLine());
            me(MSal);


        }
                

    }
    
}

