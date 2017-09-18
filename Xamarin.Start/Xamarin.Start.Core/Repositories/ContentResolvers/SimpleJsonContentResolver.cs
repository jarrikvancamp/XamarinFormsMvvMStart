using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.Api;

namespace Xamarin.Start.Core.Repositories.ContentResolvers {
	public class SimpleJsonContentResolver : IHttpContentResolver {
		public HttpContent ResolveHttpContent<TContent>(TContent content) {
			var serializedContent = JsonConvert.SerializeObject(content);

			return new StringContent(serializedContent, Encoding.UTF8, "application/json");
		}
	}
}
