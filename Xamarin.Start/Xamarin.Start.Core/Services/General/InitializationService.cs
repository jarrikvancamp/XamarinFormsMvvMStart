using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.Services.General;

namespace Xamarin.Start.Core.Services.General {
	public class InitializationService : IInitializationService {

		public InitializationService() {
		}

		public async Task Initialize(bool isConnected, string lang, CancellationToken cancellationToken = default(CancellationToken)) {
			//	await Task.WhenAll(_service.GetAll(true, isConnected, lang, cancellationToken).ToTask(cancellationToken),
			//		 _service.GetAll(true, isConnected, lang, cancellationToken).ToTask(cancellationToken));
		}
	}
}
