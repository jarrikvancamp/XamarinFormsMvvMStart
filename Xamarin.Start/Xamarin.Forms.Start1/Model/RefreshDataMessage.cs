using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Contracts.Messaging;

namespace Xamarin.Forms.Start1.Messenger {
	public class RefreshDataMessage : IMessage {
		public RefreshDataMessage(bool shouldRefreshData) {
			ShouldRefreshData = shouldRefreshData;
		}

		public bool ShouldRefreshData { get; private set; }
	}
}
