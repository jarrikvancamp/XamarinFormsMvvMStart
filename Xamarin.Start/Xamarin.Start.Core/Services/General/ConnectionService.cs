using System;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Start.Core.Contracts.Services.General;

namespace Xamarin.Start.Core.Services.General {
	public class ConnectionService : IConnectionService {
		private readonly IConnectivity _connection;

		public ConnectionService() {
			_connection = CrossConnectivity.Current;
			_connection.ConnectivityChanged += OnConnectivityChanged;
		}

		private void OnConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e) {
			ConnectivityChanged?.Invoke(this, new Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs() { IsConnected = e.IsConnected });
		}

		public bool IsConnected() {
			return _connection.IsConnected;
		}

		public async Task<bool> IsReachable(string host) {
			return await _connection.IsReachable(host);
		}

		public event Plugin.Connectivity.Abstractions.ConnectivityChangedEventHandler ConnectivityChanged;
	}

	public class ConnectivityChangedEventArgs : EventArgs {
		/// <summary>
		/// Gets if there is an active internet connection
		/// </summary>
		public bool IsConnected { get; set; }
	}

	/// <summary>
	/// Connectivity changed event handlers
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void ConnectivityChangedEventHandler(object sender, ConnectivityChangedEventArgs e);
}
