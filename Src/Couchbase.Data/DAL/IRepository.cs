using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase.N1QL;
using Couchbase.Views;

namespace Couchbase.Data.DAL
{
    public interface IRepository<T> where T : IDocument<T>
    {
        void Save(T document);
        void Remove(T document);
        IEnumerable<T> Select(IQueryRequest n1qlQuery);
        IEnumerable<T> Select(IViewQuery viewQuery);
        T Find(string key);
        /**ask SaveAsync(IDocument<T> document);
        Task RemoveAysnc(IDocument<T> document);
        Task<IEnumerable<T>> SelectAsync(IEnumerable<string> keys);
        Task<IEnumerable<T>> SelectAsync(QueryRequest queryRequest);
        Task<IEnumerable<T>> SelectAsync(ViewQuery viewQuery);
        Task<IDocument<T>> FindAsync(string key);
        * */
    }
}
