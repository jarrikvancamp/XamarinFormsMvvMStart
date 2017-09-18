using System;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.ViewModels;

namespace Xamarin.Start.Core.Contracts.Services.General {
	public interface INavigationService {
		void InitializeAsync();

		Task NavigateBackAsync();

		Task NavigateToAsync<TViewModel>(bool changeDetail = false) where TViewModel : IBaseViewModel;

		Task NavigateToAsync<TViewModel>(object parameter, bool changeDetail = false) where TViewModel : IBaseViewModel;

		Task NavigateToAsync(Type viewModelType, bool changeDetail = false);

		Task NavigateToAsync(Type viewModelType, object parameter, bool changeDetail = false);

		Task PopModalAsync();

		Task PushModalAsync<TViewModel>() where TViewModel : IBaseViewModel;

		Task PushModalAsync<TViewModel>(object parameter) where TViewModel : IBaseViewModel;

		Task PushModalAsync(Type viewModelType);

		Task PushModalAsync(Type viewModelType, object parameter);

		Task RemoveLastFromBackStackAsync();
	}
}
