using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanClasses
{
    public class ElectricCar : ICar
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Mileage { get; set; }
        public string Type
        {
            get
            {
                return "Electric";
            }
        }
        public ElectricCar() { }
        public ElectricCar(int id, string make, string model, int year, double mileage)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Mileage = mileage;
        }
    }

    public class HybridCar : ICar
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Mileage { get; set; }
        public string Type { get
            {
                return "Hybrid";
            } 
        }


        public HybridCar() { }
        public HybridCar(int id, string make, string model, int year, double mileage)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Mileage = mileage;
        }
    }

    public class GasCar : ICar
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Mileage { get; set; }
        public string Type
        {
            get
            {
                return "Gas";
            }
        }
        public GasCar() { }
        public GasCar(int id, string make, string model, int year, double mileage)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Mileage = mileage;
        }
    }
}
