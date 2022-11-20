using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Delegates
{
    public delegate double ManagerSal(double _sal);
    public delegate double Food(double _Food);
    public delegate double Petrol(double _Petrol);
    public delegate double Others(double _Others);
    public delegate double Gross(double _Gross);
    public delegate double Netsal(double _Netsal);
    public class EmployeeDelegate
    {
        public double _Petrol;
        public double _Food;
        public double _Others;
        public double _sal;
        public double _Gross;
        public double _Netsal;
        public double Pf;
        public double TDS;

        public double ManagerSalary(double _sal)
        {
            return _sal;
        }
        public double FoodDetails(double _sal)
        {
            _Food = _sal * 0.13;
            return _Food;

        }
        public double PetrolDetails(double _sal)
        {
            _Petrol = _sal * 0.08;
            return _Petrol;
        }
        public double OtherDetails(double Sal)
        {
            _Others = Sal * 0.03;
            return _Others;

        }
        public double GrossSalaryDetails(double _sal)
        {
            _Gross = _sal + _Food + _Petrol + _Others;
            return _Gross;

        }
        public double CalculateSalaryDetails(double _sal)
        {
            Pf = (_Gross * 0.10);
            TDS = (_Gross * 0.18);
            _Netsal = _Gross - (Pf + TDS);
            return _Netsal;
        }
    }
    class program
    {

        public static void Main(string[] args)
        {
            EmployeeDelegate m = new EmployeeDelegate();
            ManagerSal ms = new ManagerSal(m.ManagerSalary);
            Console.WriteLine("Enter the salary:");
            double Sal = Convert.ToDouble(Console.ReadLine());
            ms(Sal);
            Console.WriteLine("The Salary is:{0}",Sal);
            Food f = new Food(m.FoodDetails);
            double FoodCost = f(Sal);
            Console.WriteLine("The Food Allowances:{0}",FoodCost);
            Petrol p = new Petrol(m.PetrolDetails);
            double PetrolCost = p(Sal);
            Console.WriteLine("The Petrol Allowances:{0}",PetrolCost);
            Others o = new Others(m.OtherDetails);
            double OthersCost = o(Sal);
            Console.WriteLine("The Other Allowances:{0}",OthersCost);
            Gross g = new Gross(m.GrossSalaryDetails);
            double GrossSalary = g(Sal);
            Console.WriteLine("The Gross Salary is:{0}",GrossSalary);

            Netsal n = new Netsal(m.CalculateSalaryDetails);
            double NetSalary = n(Sal);
            Console.WriteLine("The Net Salary is:{0}",NetSalary);
        }
    }
}

