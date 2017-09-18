using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Contracts.Api;

namespace Xamarin.Forms.Start1.Repositories.ResponseResolvers {
	public class SimpleJsonResponseResolver : IHttpResponseResolver {
		public async Task<TResult> ResolveHttpResponseAsync<TResult>(HttpResponseMessage responseMessage) {
			if(!responseMessage.IsSuccessStatusCode) {
				return default(TResult);
			}

			var responseAsString = await responseMessage.Content.ReadAsStringAsync();

			var json = JsonConvert.DeserializeObject<TResult>(responseAsString);
			return json;
		}
	}
}
