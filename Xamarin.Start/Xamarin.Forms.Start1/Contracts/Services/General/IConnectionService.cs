using Plugin.Connectivity.Abstractions;
using System.Threading.Tasks;

namespace Xamarin.Forms.Start1.Contracts.Services.General {
	public interface IConnectionService {
		bool IsConnected();
		Task<bool> IsReachable(string host);
		event ConnectivityChangedEventHandler ConnectivityChanged;
	}
}
