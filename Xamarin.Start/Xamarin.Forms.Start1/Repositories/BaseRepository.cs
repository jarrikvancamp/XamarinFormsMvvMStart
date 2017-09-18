using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Contracts.Api;

namespace Xamarin.Forms.Start1.Repositories {
	public class BaseRepository {
		protected readonly IWebApiClient ApiClient;

		public BaseRepository(IWebApiClient apiClient) {
			if(apiClient == null) throw new ArgumentNullException(nameof(apiClient));

			ApiClient = apiClient;
		}

		protected async Task ExecuteRemoteRequest(Func<Task> action) {
			await Policy
				 .Handle<WebException>(ex => { Debug.WriteLine($"{ ex.GetType().Name + " : " + ex.Message}"); return true; })
				 .WaitAndRetryAsync
				 (
					 5,
					 retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
				 )
				 .ExecuteAsync(action).ConfigureAwait(false);
		}

		protected async Task<TResult> ExecuteRemoteRequest<TResult>(Func<Task<TResult>> action) {
			var result = await Policy
				.Handle<WebException>(ex => { Debug.WriteLine($"{ ex.GetType().Name + " : " + ex.Message}"); return true; })
				.WaitAndRetryAsync
				(
					5,
					retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
				)
				.ExecuteAsync(action).ConfigureAwait(false);

			return result;
		}

	}
}
