using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onboardr.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
        );

        Task<T> Get(Expression<Func<T, bool>> expression);

        Task Insert(T entity);

        void UpdateProperty(T entity, params Expression<Func<T, object>>[] properties);
    }
}
