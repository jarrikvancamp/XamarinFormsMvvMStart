using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.Forms.Start1.Contracts.Services.General {
	public interface IInitializationService {
		Task Initialize(bool isConnected, string lang, CancellationToken cancellationToken = default(CancellationToken));
	}
}
