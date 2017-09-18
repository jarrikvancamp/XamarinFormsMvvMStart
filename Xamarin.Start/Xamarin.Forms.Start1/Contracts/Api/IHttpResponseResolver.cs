using System.Net.Http;
using System.Threading.Tasks;

namespace Xamarin.Forms.Start1.Contracts.Api {
	public interface IHttpResponseResolver {
		Task<TResult> ResolveHttpResponseAsync<TResult>(HttpResponseMessage responseMessage);

	}
}
