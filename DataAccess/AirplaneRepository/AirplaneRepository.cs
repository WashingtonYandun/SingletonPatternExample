using SingletonPatternExample.BaseClasses;
using SingletonPatternExample.Models;

namespace SingletonPatternExample.DataAccess.PlaneRepository
{
    /// <summary>
    /// Airplane Repository with singleton pattern implemented as a BaseClase
    /// </summary>
    public class AirplaneRepository : Singleton<AirplaneRepository>, IRepository<Airplane>
    {
        private readonly AppDbContext _dbContext;

        private AirplaneRepository()
        {
            _dbContext = new AppDbContext();
        }

        #region Db CRUD Methods
        /// <summary>
        /// Find a Airplane register in the DB by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Car</returns>
        public Airplane GetById(int id)
        {
            return _dbContext.Airplanes.Find(id);
        }

        /// <summary>
        /// Add a Airplane register to DB
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Airplane entity)
        {
            _dbContext.Airplanes.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Update a Airplane register in the DB
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Airplane entity)
        {
            _dbContext.Airplanes.Update(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Delete a Airplane register in the DB
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(Airplane entity)
        {
            _dbContext.Airplanes.Remove(entity);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
