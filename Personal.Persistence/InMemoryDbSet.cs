using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Personal.Persistence
{
    /// <summary>
    /// Copied from https://msdn.microsoft.com/en-us/data/dn314431.aspx
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class InMemoryDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity>
        where TEntity : class
    {
        private readonly ObservableCollection<TEntity> data;
        private readonly IQueryable query;

        public InMemoryDbSet()
        {
            data = new ObservableCollection<TEntity>();
            query = data.AsQueryable();
        }

        public override TEntity Add(TEntity item)
        {
            data.Add(item);
            return item;
        }

        public override TEntity Remove(TEntity item)
        {
            data.Remove(item);
            return item;
        }

        public override TEntity Attach(TEntity item)
        {
            data.Add(item);
            return item;
        }

        public override TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override ObservableCollection<TEntity> Local
        {
            get { return data; }
        }

        Type IQueryable.ElementType
        {
            get { return query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new InMemoryDbAsyncQueryProvider<TEntity>(query.Provider); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new InMemoryDbAsyncEnumerator<TEntity>(data.GetEnumerator());
        }
    }
}