using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.Messaging;
using Xamarin.Forms;

namespace Xamarin.Start.Core.Messenger {
	public class Messenger : IMessenger {
		public void Send<TMessage>(TMessage message, object sender = null) where TMessage : IMessage {
			if(sender == null)
				sender = new object();

			MessagingCenter.Send(sender, typeof(TMessage).FullName, message);
		}

		public void Subscribe<TMessage>(object subscriber, Action<object, TMessage> callback) where TMessage : IMessage {
			MessagingCenter.Subscribe(subscriber, typeof(TMessage).FullName, callback);
		}

		public void Unsubscribe<TMessage>(object subscriber) where TMessage : IMessage {
			MessagingCenter.Unsubscribe<object, TMessage>(subscriber, typeof(TMessage).FullName);
		}
	}
}
