using Acr.UserDialogs;
using System;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Contracts.Services.General;
using Xamarin.Forms;

namespace Xamarin.Forms.Start1.Services.General {
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

		public void ShowNoInternetMessage() {
			var config = new ToastConfig("No internet");
			config.SetBackgroundColor(System.Drawing.Color.LightGray);
			config.SetMessageTextColor(System.Drawing.Color.Gray);
			Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.Toast(config));

		}

	}
}
