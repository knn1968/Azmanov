using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<EntityType> : IDisposable
    {
        void Add(EntityType newEntity);
        void Remove(EntityType entity);
        IQueryable<EntityType> Find(Expression<Func<EntityType, bool>> predicate);
        bool Commit();
        int GetCount();
    }
}
