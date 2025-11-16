using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Globalization;
using System.ComponentModel.Design;

namespace AceRentals
{
    class Car
    {
        public string Brand;
        public string Model;
        public double DailyRate; 

        public Car(string brand, string model, double dailyRate)
        {
            Brand = brand;
            Model = model;
            DailyRate = dailyRate;

            Console.WriteLine("Record created for: "+Brand+"|"+Model+"|N"+DailyRate);
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("Model: " + Model);
            Console.WriteLine("Daily Rate:" + DailyRate); 
        }
    }

    class ElectricCar : Car
    {
        public double BatteryCapacity;

        public ElectricCar(String brand, string model, double dailyRate, double batteryCapacity) : base(brand, model, dailyRate)
        {
            BatteryCapacity = batteryCapacity;

            Console.WriteLine("Electric Car Record created for:" + Brand + "|" + Model + " " + BatteryCapacity + "KWH|N" + DailyRate);
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Battery Capacity:" + BatteryCapacity + "kwh");
        }

        //Overloaded method CalculateRent
        public double CalculateRent(int days)
        {
            return days * DailyRate;
        }

        public double CalculateRent(int days, double discount)
        {
            double cost = days * DailyRate;
            return cost - (cost * discount / 100);
        }
    }

    class SUV: Car
    {
        public bool Has4WD;

        public SUV(string brand, string model, double dailyRate, bool has4wd): base(brand, model, dailyRate) { Has4WD = has4wd;
            Console.WriteLine("SUV Car record created for: " + Brand + " | " + Model + "|4WD:" + Has4WD);
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("4WD Enabled:" + Has4WD);
        }
    }

    sealed class LuxuryCar
    {
        public string Brand;
        public double DailyRate;

        public LuxuryCar(string brand, double dailyRate)
        {
            Brand = brand;
            DailyRate = dailyRate;
            Console.WriteLine("Luxury Car Record Created for : " + Brand + "|" + DailyRate);
        }

        public void DisplayLuxuryInfo()
        {
            Console.WriteLine("Luxury Car Details: "+Brand+"\nDaily Rate:"+DailyRate);
        }
    }

    class Customer
    {
        public string Name;
        public int Age;
        public string CarRented;
        public int Days;

        public Customer(string name, int age, string carRented, int days)
        {
            Name = name;
            Age = age;
            CarRented = carRented;
            Days = days;
        }

        public void PrintCustomerDetails()
        {
            Console.WriteLine("Customers Name:" + Name);
            Console.WriteLine("Customers Age:" +Age);
            Console.WriteLine("Car Rented:"+ CarRented);
            Console.WriteLine("Days for Rent: " + Days);
        }
    }

    static class Company
    {
        public static string CompanyName = "Ace Car Rentals";
        public static string Location = "Jakande, Lekki, Lagos";

        public static void WelcomeMessage()
        {
            Console.WriteLine("***************************Welcome to" + CompanyName + "***************************");
            Console.WriteLine("\t\t\t\t\t[" + Location + "Branch]\n");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Company.WelcomeMessage();

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n Select the type of Car you want to rent: 1: SUV 2: Electric Car");
            Console.Write("Enter a choice (1 or 2): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Car selectedCar = null;

            SUV objSUV = new SUV("Toyota", "4Runner", 100000, true);
            ElectricCar objEC = new ElectricCar("Tesla", "Model 3", 1500000, 100);
            LuxuryCar objLC = new LuxuryCar("Mercedes Maybach", 300000);

            switch (choice)
            {
                case 1:
                    selectedCar = objSUV;
                    break;
                case 2:
                    selectedCar = objEC;
                    break;
                default:
                    Console.WriteLine("Invalid Choice! Default car selected: SUV");
                    selectedCar = objSUV;
                    break;
            }

            Console.Write("\nEnter the number of days to rent:");
            int days = Convert.ToInt32(Console.ReadLine());

            double totalcost = 0; 

            if (selectedCar is ElectricCar electric)
            {
                Console.WriteLine("Do you have a discount code? [yes/no]"); 
                string response = Console.ReadLine();

                if (response == "yes")
                {
                    Console.WriteLine("Enter discount percentage"); 
                    double discount = Convert.ToDouble(Console.ReadLine());
                    totalcost = electric.CalculateRent(days, discount);
                }
                else
                {
                    totalcost = electric.CalculateRent(days);
                }
            }else if(selectedCar is SUV suvCar)
            {
                totalcost = suvCar.DailyRate * days;
            }

            Customer customer = new Customer(name, age, selectedCar.Model, days);

            Console.WriteLine("\n******* Rental Details **********");
            selectedCar.DisplayDetails();
            customer.PrintCustomerDetails();
            Console.WriteLine("Total Cost for Rental:" + totalcost);

            if (totalcost > 30000)
            {
                Console.WriteLine("This is a Preminum Rent\n");
            }
            else
            {
                Console.WriteLine("This is a Standard Rent\n");
            }

            //Displaying Luxury Car information

            Console.WriteLine("***************Luxury Car Available*********************");
            objLC.DisplayLuxuryInfo();

            selectedCar = null;
            objSUV = null;
            objLC = null;
            objEC = null;


            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("********************Thank you For Using" + Company.CompanyName + "****************");

        }
    }
}
