using SampleLibrary.Car.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Car.Data
{
    public class SampleDataAccess : IDataAccess
    {
        private List<CarDto> cars = new();

        public SampleDataAccess()
        {
            cars.Add(new CarDto { Id = 1, Brand = "Škoda", Model = "Karoq", Price = "800 000" });
            cars.Add(new CarDto { Id = 2, Brand = "Volkswagen", Model = "Golf", Price = "650 000" });
            cars.Add(new CarDto { Id = 3, Brand = "Porsche", Model = "Taycan", Price = "5 000 000" });
        }

        public List<CarDto> GetAllCars()
        {
            Thread.Sleep(3000);
            return cars;
        }

        public CarDto InsertNewCar(string brand, string model, string price)
        {
            CarDto car = new() { Brand = brand, Model = model, Price = price };
            car.Id = cars.Max(x => x.Id) + 1;
            cars.Add(car);
            return car;
        }
    }
}
