using SingletonPatternExample.Models;

namespace SingletonPatternExample.DataAccess.CarRepository
{
    /// <summary>
    /// Repository for accessing to Car registers in a CRUD behavior
    /// </summary>
    public class CarRepository : IRepository<Car>
    {
        #region Singleton and Atributes
        private readonly AppDbContext _dbContext;

        private static readonly Lazy<CarRepository> _lazyInstance = new Lazy<CarRepository>(
            () => new CarRepository()
            );

        private CarRepository()
        {
            _dbContext = new AppDbContext();
        }

        public static CarRepository Instance => _lazyInstance.Value;
        #endregion

        #region Db CRUD Methods
        /// <summary>
        /// Find a Car register in the DB by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Car</returns>
        public Car GetById(int id)
        {
            return _dbContext.Cars.Find(id);
        }

        /// <summary>
        /// Add a Car register to DB
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Car entity)
        {
            _dbContext.Cars.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Update a Car register in the DB
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Car entity)
        {
            _dbContext.Cars.Update(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Delete a Car register in the DB
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(Car entity)
        {
            _dbContext.Cars.Remove(entity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
