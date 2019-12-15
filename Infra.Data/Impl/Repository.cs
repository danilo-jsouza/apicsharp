using Domain.Interface;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infra.Data.Impl
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IAsyncEnumerable<TEntity>, IDisposable
        where TEntity : class, IModel
    {
        protected DbSet<TEntity> Entity;
        protected IQueryable<TEntity> Query;
        protected DbContext Context { get; }

        public Type ElementType => Query.ElementType;

        public Expression Expression => Query.Expression;

        public IQueryProvider Provider => Query.Provider;

        public IQueryable<TEntity> Tracking => Entity;

        public Repository(DbContext context)
        {
            Context = context;
            Entity = context.Set<TEntity>();
            Query = Entity.AsNoTracking();
        }

        public void Add(TEntity obj)
            => Entity.Add(obj);

        public void Update(TEntity obj)
        {
            Entity.Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(TEntity obj)
            => Entity.Remove(obj);

        public void Dispose()
        {
            Context.Dispose();
        }

        public IEnumerator<TEntity> GetEnumerator()
            => Query.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => (Query as IEnumerable).GetEnumerator();
        
        IAsyncEnumerator<TEntity> IAsyncEnumerable<TEntity>.GetEnumerator()
            => (Query as IAsyncEnumerable<TEntity>).GetEnumerator();
    }
}
