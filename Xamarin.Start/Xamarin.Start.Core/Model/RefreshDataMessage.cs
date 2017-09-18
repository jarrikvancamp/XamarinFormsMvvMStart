using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.Messaging;

namespace Xamarin.Start.Core.Messenger {
	public class RefreshDataMessage : IMessage {
		public RefreshDataMessage(bool shouldRefreshData) {
			ShouldRefreshData = shouldRefreshData;
		}

		public bool ShouldRefreshData { get; private set; }
	}
}
