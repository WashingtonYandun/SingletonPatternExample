using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExample.DataAccess
{
    /// <summary>
    /// Interface to interact with the Db in CRUD behavior
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
