using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasis
{
    /// <summary>
    /// Common method for Table
    /// </summary>
    /// <typeparam name="T">table list</typeparam>
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
