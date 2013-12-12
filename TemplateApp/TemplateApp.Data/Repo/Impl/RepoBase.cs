using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TemplateApp.Data.Repo.Impl
{
    internal abstract class RepoBase<TEntity, TDbContext> : IRepoBase<TEntity>
        where TDbContext : DbContext, new()
        where TEntity : class
    {
        #region public constructors

        protected RepoBase(UnitOfWork<TDbContext> unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Context = UnitOfWork.Context;
            DbSet = Context.Set<TEntity>();
        }

        #endregion public constructors

        #region public methods

        public virtual TEntity Get(Object id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, Boolean>> expression)
        {
            return GetAll().Where(expression);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity Create()
        {
            return DbSet.Create<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(Object id)
        {
            var entity = Get(id);
            if (entity != null) Remove(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public virtual Boolean IsExist(Expression<Func<TEntity, Boolean>> expression)
        {
            return GetAll().Any(expression);
        }

        public virtual Boolean IsUpdated(TEntity entity)
        {
            return Context.Entry(entity).State == EntityState.Modified;
        }

        #endregion public methods

        #region protected properties

        protected UnitOfWork<TDbContext> UnitOfWork { get; private set; }
        protected TDbContext Context { get; private set; }
        protected IDbSet<TEntity> DbSet { get; private set; }

        #endregion protected properties
    }
}
