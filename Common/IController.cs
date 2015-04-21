using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasis.Controllers
{
    public interface IController<T> where T:class
    {
        IEnumerable<T> Get();
        T Get(object id);
        void Post(T obj);
        void Put(T obj);
        void Put(object id, T obj);
        void Delete(object id);

    }
}
