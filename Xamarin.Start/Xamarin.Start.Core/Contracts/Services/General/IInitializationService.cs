using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.Start.Core.Contracts.Services.General {
	public interface IInitializationService {
		Task Initialize(bool isConnected, string lang, CancellationToken cancellationToken = default(CancellationToken));
	}
}
