using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Data.Interfaces
{
    public interface IRepository<TEntity> : IQueryable<TEntity> 
        where TEntity : IModel
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        IQueryable<TEntity> Tracking { get; }
    }
}
