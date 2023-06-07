using SingletonPatternExample.DataAccess;
using SingletonPatternExample.DataAccess.CarRepository;
using SingletonPatternExample.Models;

namespace SingletonPatternExample.Services.CarService
{
    public class CarService : IService<Car>
    {
        #region Singleton and Atributes
        private static readonly Lazy<CarService> lazyInstance = new Lazy<CarService>(() => new CarService());
        private readonly IRepository<Car> _carRepository;

        private CarService()
        {
            _carRepository = CarRepository.Instance;
        }

        public static CarService Instance => lazyInstance.Value;
        #endregion

        #region Service Methods
        /// <summary>
        /// Get a car register by id with messages
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetById(int id)
        {
            Car existingCar = _carRepository.GetById(id);
            if (existingCar != null)
            {
                Console.WriteLine($"Car found - Name: {existingCar.Name}, Brand: {existingCar.Brand}, Year: {existingCar.Year}");
                return existingCar;
            }
            else
            {
                Console.WriteLine("Car not found");
            }
            return existingCar; 
        }

        /// <summary>
        /// Add a car register with printing a message
        /// </summary>
        /// <param name="car"></param>
        public void Add(Car car)
        {
            _carRepository.Add(car);
            Console.WriteLine($"Car Register added - Name: {car.Name}, Brand: {car.Brand}, Year: {car.Year}");
        }

        /// <summary>
        /// Update a car register by id with validation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedCar"></param>
        public void Update(int id, Car updatedCar)
        {
            Car existingCar = _carRepository.GetById(id);
            if (existingCar != null)
            {
                existingCar.Name = updatedCar.Name;
                existingCar.Brand = updatedCar.Brand;
                existingCar.Year = updatedCar.Year;
                existingCar.Color = updatedCar.Color;
                existingCar.Model = updatedCar.Model;

                _carRepository.Update(existingCar);
                Console.WriteLine($"Updated Car - Id: {existingCar.Id}, Name: {existingCar.Name}, Brand: {existingCar.Brand}, Year: {existingCar.Year}");
            }
            else
            {
                Console.WriteLine("Car not found");
            }
        }

        /// <summary>
        /// Delete car register by id with validation
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            Car carToDelete = _carRepository.GetById(id);
            if (carToDelete != null)
            {
                _carRepository.Delete(carToDelete);
                Console.WriteLine($"Eliminated Car - Id: {carToDelete.Id} Name: {carToDelete.Name}, Brand: {carToDelete.Brand}, Year: {carToDelete.Year}");
            }
            else
            {
                Console.WriteLine("Car not found");
            }
        }
        #endregion
    }
}
