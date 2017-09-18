using System.Net.Http;

namespace Xamarin.Start.Core.Contracts.Api {
	public interface IHttpContentResolver {
		HttpContent ResolveHttpContent<TContent>(TContent content);
	}
}
