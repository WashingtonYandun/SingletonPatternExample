using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExample.Services
{
    /// <summary>
    /// Interface to implement CRUD behavior on Sevices
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T>
    {
        T GetById(int id);
        void Add(T entity);
        void Update(int id, T updatedEntity);
        void Delete(int id);
    }
}
