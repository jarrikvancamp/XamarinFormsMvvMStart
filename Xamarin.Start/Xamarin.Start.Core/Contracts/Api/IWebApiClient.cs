using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.Start.Core.Contracts.Api {
	public interface IWebApiClient {
		string AcceptHeader { get; set; }
		IDictionary<string, string> Headers { get; }
		IHttpContentResolver HttpContentResolver { get; set; }
		IHttpResponseResolver HttpResponseResolver { get; set; }
		Task<TResult> GetAsync<TResult>(string path, CancellationToken cancellationToken = default(CancellationToken));
		Task<HttpResponseMessage> GetAsync(string path, CancellationToken cancellationToken = default(CancellationToken));
		Task PutAsync<TContent>(string path, TContent content = default(TContent), CancellationToken cancellationToken = default(CancellationToken));
	}
}
