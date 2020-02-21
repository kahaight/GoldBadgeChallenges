using GreenPlanClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanConsoleApp.UI
{
    public class ProgramUI
    {
        private int _userInput;
        private bool _exitMenu;
        private ICarRepository _carRepository = new ICarRepository();
        public void Run()
        {
            SeedContent();
            _exitMenu = false;
            while (!_exitMenu)
            {
                RunMenu();
            }
        }

        public void RunMenu()
        {
            Console.WriteLine("What would you like to do?\n" +
                "1. See All Cars\n" +
                "2. See All Electric Cars\n" +
                "3. See All Hybrid Cars\n" +
                "4. See All Gas Cars\n" +
                "5. Add A Car\n" +
                "6. Remove A Car\n" +
                "7. Update A Car\n" +
                "8. Exit");

            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                switch (_userInput)
                {
                    case 1:
                        SeeAllCars();
                        break;
                    case 2:
                        SeeAllElectricCars();
                        break;
                    case 3:
                        SeeAllHybridCars();
                        break;
                    case 4:
                        SeeAllGasCars();
                        break;
                    case 5:
                        AddACar();
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        _exitMenu = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid response\n" +
                    "Press any key to try again");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void SeeAllCars()
        {

            List<ICar> cars = _carRepository.GetAllCars();
            foreach (ICar car in cars)
            {
                Console.Write(String.Format("|{0,-10}|{1,-10}|{2,-15}|{3,-10}|{4,-10}|{5,-10}\n", car.Id, car.Make, car.Model, car.Year, car.Mileage, car.Type));
            }
        }
        public void SeedContent()
        {
            ICar eCarOne = new ElectricCar(101, "Tesla", "Model S", 2019, 5000.05);
            _carRepository.AddCarToList(eCarOne);
            ICar eCarTwo = new ElectricCar(102, "Tesla", "Model 3", 2019, 4500.05);
            _carRepository.AddCarToList(eCarTwo);
            ICar gCarOne = new GasCar(201, "Toyota", "Yaris", 2007, 175000);
            _carRepository.AddCarToList(gCarOne);
            ICar gCarTwo = new GasCar(202, "Chrysler", "Town & Country", 2012, 105000);
            _carRepository.AddCarToList(gCarTwo);
            ICar hCarOne = new HybridCar(301, "Toyota", "Prius C", 2014, 65000.50);
            _carRepository.AddCarToList(hCarOne);
            ICar hCarTwo = new HybridCar(302, "Toyota", "Prius L", 2019, 6874);
            _carRepository.AddCarToList(hCarTwo);
        }
        public void SeeAllElectricCars()
        {
            List<ICar> eCars = _carRepository.GetAllElectricCars();
            foreach (ICar car in eCars)
            {
                Console.Write(String.Format("|{0,-10}|{1,-10}|{2,-15}|{3,-10}|{4,-10}|{5,-10}\n", car.Id, car.Make, car.Model, car.Year, car.Mileage, car.Type));
            }
        }
        public void SeeAllHybridCars()
        {
            List<ICar> hCars = _carRepository.GetAllHybridCars();
            foreach (ICar car in hCars)
            {
                Console.Write(String.Format("|{0,-10}|{1,-10}|{2,-15}|{3,-10}|{4,-10}|{5,-10}\n", car.Id, car.Make, car.Model, car.Year, car.Mileage, car.Type));
            }
        }
        public void SeeAllGasCars()
        {
            List<ICar> gCars = _carRepository.GetAllGasCars();
            foreach (ICar car in gCars)
            {
                Console.Write(String.Format("|{0,-10}|{1,-10}|{2,-15}|{3,-10}|{4,-10}|{5,-10}\n", car.Id, car.Make, car.Model, car.Year, car.Mileage, car.Type));
            }
        }
        public void AddACar()
        {
            Console.WriteLine("What kind of car would you like to add?\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n");
            if(Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                switch (_userInput)
                {
                    case 1:

                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid response.\n" +
                    "Press any key to try again.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
