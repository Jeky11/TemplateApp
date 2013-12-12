using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TemplateApp.Data.Repo
{
    public interface IRepoBase<TEntity>
        where TEntity : class
    {
        TEntity Get(Object id);

        IQueryable<TEntity> Get(Expression<Func<TEntity, Boolean>> expression);

        IQueryable<TEntity> GetAll();

        TEntity Create();

        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(Object id);

        void Remove(TEntity entity);

        void Remove(IEnumerable<TEntity> entities);

        Boolean IsExist(Expression<Func<TEntity, Boolean>> expression);

        Boolean IsUpdated(TEntity entity);
    }
}
