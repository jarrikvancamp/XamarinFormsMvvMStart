using System.Net.Http;
using System.Threading.Tasks;

namespace Xamarin.Start.Core.Contracts.Api {
	public interface IHttpResponseResolver {
		Task<TResult> ResolveHttpResponseAsync<TResult>(HttpResponseMessage responseMessage);

	}
}
