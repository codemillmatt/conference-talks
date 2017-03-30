using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Abstractions
{
    public interface IAzureService
    {
        Task<IAzureTable<T>> GetTable<T>() where T : TableData;
		Task SyncOfflineCache();

		Task Login();

		Task RegisterForPushNotifications();
    }
}
