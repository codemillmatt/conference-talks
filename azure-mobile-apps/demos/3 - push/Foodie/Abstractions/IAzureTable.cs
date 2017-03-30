using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Abstractions
{
    public interface IAzureTable<T> where T : TableData
    {
        Task<T> Insert(T item);
        Task<T> GetSingle(string id);
        Task<T> Update(T item);
        Task Delete(T item);
        Task<ICollection<T>> GetAll();
        Task<ICollection<T>> GetItems(int start, int end);
        Task Pull();
    }
}
