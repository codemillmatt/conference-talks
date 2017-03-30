using Foodie.Abstractions;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.DataService
{
    public class AzureTable<T> : IAzureTable<T> where T : TableData
    {
        MobileServiceClient client;
        IMobileServiceSyncTable<T> table;

        public AzureTable(MobileServiceClient client)
        {
            this.client = client;
            this.table = this.client.GetSyncTable<T>();
        }

		public async Task Delete(T item) => await table.DeleteAsync(item);

        public async Task<ICollection<T>> GetAll() => await table.ToListAsync(); // This will only get as many as the server is willing to return

		public async Task<ICollection<T>> GetItems(int start, int end) => await table.Skip(start).Take(end).ToListAsync();

		public async Task<T> GetSingle(string id) => await table.LookupAsync(id);

        public async Task<T> Insert(T item)
        {
			await table.InsertAsync(item);

            return item;
        }

        public async Task Pull()
        {
            // having the query name enables an incremental pull
            string pullQueryName = $"sync_{typeof(T)}.Name";
			await table.PullAsync(pullQueryName, table.CreateQuery());
        }

        public async Task<T> Update(T item)
        {
			await table.UpdateAsync(item);

            return item;
        }
    }
}
