using SingletonPatternExample.BaseClasses;
using SingletonPatternExample.DataAccess.PlaneRepository;
using SingletonPatternExample.Models;

namespace SingletonPatternExample.Services.AirplaneService
{
    public class AirplaneService : Singleton<AirplaneService>, IService<Airplane>
    {
        private readonly AirplaneRepository _airplaneRepository;

        private AirplaneService()
        {
            _airplaneRepository = AirplaneRepository.Instance;
        }

        #region Service Methods
        /// <summary>
        /// Get a airplane register by id with messages
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Airplane GetById(int id)
        {
            var existingAirplane = _airplaneRepository.GetById(id);
            if (existingAirplane != null)
            {
                Console.WriteLine($"Airplane found - Name: {existingAirplane.Name}, Brand: {existingAirplane.Brand}, Year: {existingAirplane.Year}");
                return existingAirplane;
            }
            else
            {
                Console.WriteLine("Airplane not found");
            }
            return existingAirplane;
        }

        /// <summary>
        /// Add a Airplane register with printing a message
        /// </summary>
        /// <param name="airplane"></param>
        public void Add(Airplane airplane)
        {
            _airplaneRepository.Add(airplane);
            Console.WriteLine($"Airplane Register added - Name: {airplane.Name}, Brand: {airplane.Brand}, Year: {airplane.Year}");
        }

        /// <summary>
        /// Update a Airplane register by id with validation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedAirplane"></param>
        public void Update(int id, Airplane updatedAirplane)
        {
            var existingAirplane = _airplaneRepository.GetById(id);
            if (existingAirplane != null)
            {
                existingAirplane.Name = updatedAirplane.Name;
                existingAirplane.Brand = updatedAirplane.Brand;
                existingAirplane.Year = updatedAirplane.Year;
                existingAirplane.Color = updatedAirplane.Color;
                existingAirplane.Model = updatedAirplane.Model;

                _airplaneRepository.Update(existingAirplane);
                Console.WriteLine($"Updated Airplane - Id: {existingAirplane.Id}, Name: {existingAirplane.Name}, Brand: {existingAirplane.Brand}, Year: {existingAirplane.Year}");
            }
            else
            {
                Console.WriteLine("Airplane not found");
            }
        }

        /// <summary>
        /// Delete Airplane register by id with validation
        /// </summary>
        /// <param name="id">int</param>
        public void Delete(int id)
        {
            var airplaneToDelete = _airplaneRepository.GetById(id);
            if (airplaneToDelete != null)
            {
                _airplaneRepository.Delete(airplaneToDelete);
                Console.WriteLine($"Eliminated Airplane - Id: {airplaneToDelete.Id} Name: {airplaneToDelete.Name}, Brand: {airplaneToDelete.Brand}, Year: {airplaneToDelete.Year}");
            }
            else
            {
                Console.WriteLine("Airplane not found");
            }
        }
        #endregion
    }
}
