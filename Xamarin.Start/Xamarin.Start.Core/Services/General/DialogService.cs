using Acr.UserDialogs;
using System;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.Services.General;
using Xamarin.Forms;

namespace Xamarin.Start.Core.Services.General {
	public class DialogService : IDialogService {

		public DialogService() {
		}

		public async Task ShowErrorAsync(string message, string title, string buttonText) {
			await UserDialogs.Instance.AlertAsync(message, title, buttonText);
		}

		public void ShowError(Exception error, string title, string buttonText, Action afterHideCallback) {
			UserDialogs.Instance.ShowError(error.Message);
		}

		public async Task ShowMessageAsync(string message, string title, string buttonText = null, Action afterHideCallback = null) {
			var config = new AlertConfig() {
				Message = message,
				Title = title,
				OkText = buttonText ?? "Ok",
				OnAction = afterHideCallback
			};

			await UserDialogs.Instance.AlertAsync(config);
		}
	}
}
