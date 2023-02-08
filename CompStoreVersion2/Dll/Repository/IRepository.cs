using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        T GetValue(int id);
        IEnumerable<T> GetFromCondition(Expression<Func<T, bool>> condition);
    }
}
