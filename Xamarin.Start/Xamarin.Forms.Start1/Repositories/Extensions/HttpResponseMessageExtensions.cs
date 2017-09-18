using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Start1.Repositories.Extensions {
	public static class HttpResponseMessageExtensions {
		public static async Task EnsureSuccessStatusCodeAsync(this HttpResponseMessage response) {
			if(response.IsSuccessStatusCode) {
				return;
			}

			var content = await response.Content.ReadAsStringAsync();

			response.Content?.Dispose();

			throw new HttpResponseException(response.StatusCode, response.ReasonPhrase, content);
		}
	}

	public class HttpResponseException : Exception {
		public HttpStatusCode StatusCode { get; private set; }
		public string Content { get; private set; }

		public HttpResponseException(HttpStatusCode statusCode, string reasonPhrase, string content) : base(reasonPhrase) {
			StatusCode = statusCode;
			Content = content;
		}
	}
}
