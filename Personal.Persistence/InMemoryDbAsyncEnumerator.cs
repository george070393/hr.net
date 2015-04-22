using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Personal.Persistence
{
    internal class InMemoryDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> inner;

        public InMemoryDbAsyncEnumerator(IEnumerator<T> inner)
        {
            this.inner = inner;
        }

        public void Dispose()
        {
            inner.Dispose();
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(inner.MoveNext());
        }

        public T Current
        {
            get { return inner.Current; }
        }

        object IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }
}