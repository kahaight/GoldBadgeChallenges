using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanClasses
{
    public class ICarRepository
    {
        private List<ICar> _cars = new List<ICar>();

        public void AddCarToList(ICar car)
        {
            _cars.Add(car);
        }
        public void RemoveCarFromList(ICar car)
        {
            _cars.Remove(car);
        }

        public List<ICar> GetAllCars()
        {
            return _cars;
        }

        public List<ICar> GetAllElectricCars()
        {
            List<ICar> cars = new List<ICar>();
            foreach (ICar car in _cars)
            {
                if(car is ElectricCar)
                {
                    cars.Add(car);
                }
            }
            return cars;
        }
        public List<ICar> GetAllHybridCars()
        {
            List<ICar> cars = new List<ICar>();
            foreach (ICar car in _cars)
            {
                if (car is HybridCar)
                {
                    cars.Add(car);
                }
            }
            return cars;
        }
        public List<ICar> GetAllGasCars()
        {
            List<ICar> cars = new List<ICar>();
            foreach (ICar car in _cars)
            {
                if (car is GasCar)
                {
                    cars.Add(car);
                }
            }
            return cars;
        }
        public ICar GetCarById(int id)
        {
            foreach(ICar car in _cars)
            {
                if (car.Id == id)
                {
                    return car;
                }
            }
            return null;
        }

        public bool UpdateCar(int id, ICar newCar)
        {
            ICar oldCar = GetCarById(id);
            if (oldCar != null)
            {
                oldCar.Id = newCar.Id;
                oldCar.Make = newCar.Model;
                oldCar.Model = newCar.Model;
                oldCar.Year = newCar.Year;
                oldCar.Mileage = newCar.Mileage;
                return true;
            }
            return false;
        }
    }
}
