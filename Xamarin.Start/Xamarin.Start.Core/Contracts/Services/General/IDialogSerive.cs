using System;
using System.Threading.Tasks;

namespace Xamarin.Start.Core.Contracts.Services.General {
	public interface IDialogService {
		Task ShowErrorAsync(string message, string title, string buttonText);
		void ShowError(Exception error, string title, string buttonText, Action afterHideCallback);
		Task ShowMessageAsync(string message, string title, string buttonText = null, Action afterHideCallback = null);
	}
}
