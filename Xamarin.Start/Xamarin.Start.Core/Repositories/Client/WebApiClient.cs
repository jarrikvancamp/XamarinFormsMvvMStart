using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Start.Core.Constants;
using Xamarin.Start.Core.Contracts.Api;
using Xamarin.Start.Core.Helpers;
using Xamarin.Start.Core.Repositories.ContentResolvers;
using Xamarin.Start.Core.Repositories.Extensions;
using Xamarin.Start.Core.Repositories.ResponseResolvers;

namespace Xamarin.Start.Core.Repositories.Client {
	public class WebApiClient : IWebApiClient {
		private IHttpContentResolver _httpContentResolver;
		private IHttpResponseResolver _httpResponseResolver;
		private bool _isDisposed;
		private Lazy<HttpClient> _client;
		private object locker = new object();

		public WebApiClient() {
			var baseUrl = new UrlBuilder(ApiConstants.BaseUrl).Append(ApiConstants.ApiUrl).ToUri();
			_client = new Lazy<HttpClient>(() => new HttpClient() { BaseAddress = baseUrl, Timeout = new TimeSpan(0, 0, 30) });
		}

		/// <summary>
		/// Gets or sets the implementation of the <see cref="IHttpContentResolver"/> interface associated with the WebApiClient.
		/// </summary>
		/// <remarks>
		/// The <see cref="IHttpContentResolver"/> implementation is responsible for serializing content which needs to be send to the server
		/// using a HTTP POST or PUT request.
		///
		/// When no other value is supplied the <see cref="WebApiClient"/> by default uses the <see cref="SimpleJsonContentResolver"/>. This resolver will
		/// try to serialize the content to a JSON message and returns the proper <see cref="System.Net.Http.HttpContent"/> instance.
		/// </remarks>
		public IHttpContentResolver HttpContentResolver {
			get { return _httpContentResolver ?? (_httpContentResolver = new SimpleJsonContentResolver()); }
			set { _httpContentResolver = value; }
		}

		/// <summary>
		/// Gets or sets the implementation of the <see cref="IHttpResponseResolver"/> interface associated with the WebApiClient.
		/// </summary>
		/// <remarks>
		/// The <see cref="IHttpResponseResolver"/> implementation is responsible for deserialising the <see cref="System.Net.Http.HttpResponseMessage"/>
		/// into the required result object.
		///
		/// When no other value is supplied the <see cref="WebApiClient"/> by default uses the <see cref="SimpleJsonResponseResolver"/>. This resolver will
		/// assumes the response is a JSON message and tries to deserialize it into the required result object.
		/// </remarks>
		public IHttpResponseResolver HttpResponseResolver {
			get { return _httpResponseResolver ?? (_httpResponseResolver = new SimpleJsonResponseResolver()); }
			set { _httpResponseResolver = value; }
		}

		/// <summary>
		/// Gets or sets the accept header of the HTTP request. Default the accept header is set to "appliction/json".
		/// </summary>
		public string AcceptHeader { get; set; } = "application/json";

		public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

		/// <summary>
		/// Sends a GET request to the API
		/// </summary>
		/// <returns>TResult</returns>
		public async Task<TResult> GetAsync<TResult>(string path, CancellationToken cancellationToken = default(CancellationToken)) {
			var httpClient = GetWebApiClient();

			SetHttpRequestHeaders(httpClient);

			var response = await httpClient.GetAsync(path, cancellationToken).ConfigureAwait(false);
			await response.EnsureSuccessStatusCodeAsync().ConfigureAwait(false);
			return await HttpResponseResolver.ResolveHttpResponseAsync<TResult>(response);
		}

		/// <summary>
		/// Sends a GET request to the API
		/// </summary>
		/// <returns>HttpResponseMessage</returns>
		public async Task<HttpResponseMessage> GetAsync(string path, CancellationToken cancellationToken = default(CancellationToken)) {
			var httpClient = GetWebApiClient();

			SetHttpRequestHeaders(httpClient);

			var response = await httpClient.GetAsync(path, cancellationToken).ConfigureAwait(false);
			await response.EnsureSuccessStatusCodeAsync().ConfigureAwait(false);

			return response;
		}

		/// <summary>
		/// Sends a PUT request to the API
		/// </summary>
		public async Task PutAsync<TContent>(string path, TContent content = default(TContent), CancellationToken cancellationToken = default(CancellationToken)) {
			var httpClient = GetWebApiClient();

			SetHttpRequestHeaders(httpClient);

			HttpContent httpContent = null;

			if(content != null)
				httpContent = HttpContentResolver.ResolveHttpContent(content);

			var response = await httpClient
				.PutAsync(path, httpContent, cancellationToken)
				.ConfigureAwait(false);

			await response.EnsureSuccessStatusCodeAsync().ConfigureAwait(false);
		}

		/// <summary>
		/// Returns the requested HttpClient with the correct priority
		/// </summary>
		private HttpClient GetWebApiClient() {
			return _client.Value;
		}

		/// <summary>
		/// Sets the RequestHeaders for the request on the HttpClient
		/// </summary>
		private void SetHttpRequestHeaders(HttpClient client) {
			lock(locker) {
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptHeader));

				client.DefaultRequestHeaders.Add("APIKEY", ApiConstants.ApiKey);

				foreach(var header in Headers)
					client.DefaultRequestHeaders.Add(header.Key, header.Value);
			}
		}

		public void Dispose() {
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing) {
			if(_isDisposed) return;

			if(disposing) {
				_client.Value?.Dispose();
			}

			_client = null;

			_isDisposed = true;
		}
	}
}
