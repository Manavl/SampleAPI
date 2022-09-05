using SampleLibrary.Car.Dto;

namespace SampleLibrary.Car.Data
{
    public interface IDataAccess
    {
        List<CarDto> GetAllCars();
        CarDto InsertNewCar(string brand, string model, string price);
    }
}