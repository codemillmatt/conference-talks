using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
namespace Foodie
{
	public interface ILoginProvider
	{
		Task Login(MobileServiceClient client);
	}
}
