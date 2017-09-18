using System.Net.Http;

namespace Xamarin.Forms.Start1.Contracts.Api {
	public interface IHttpContentResolver {
		HttpContent ResolveHttpContent<TContent>(TContent content);
	}
}
