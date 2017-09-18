using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Contracts.ViewModels;
using Xamarin.Forms.Start1.Views;
using Xamarin.Forms;

namespace Xamarin.Forms.Start1.Services.General {
	public class iOSNavigationService : NavigationService {

		protected override async Task InternalNavigateToAsync(Type viewModelType, object parameter, bool changeDetail) {
			Page page = CreateAndBindPage(viewModelType, parameter);

			if(page is RootView) {
				CurrentApplication.MainPage = page;
			} else {
				var view = CurrentApplication.MainPage as RootView;
				if(view != null) {
					var mainPage = view;
					var navigationPage = mainPage.Detail as NavigationPage;

					if(navigationPage != null && !changeDetail) {
						await navigationPage.PushAsync(page);
					} else {
						navigationPage = new NavigationPage(page);
						mainPage.Detail = navigationPage;
					}

					mainPage.IsPresented = false;
				} else {
					var navigationPage = CurrentApplication.MainPage as NavigationPage;

					if(navigationPage != null) {
						await navigationPage.PushAsync(page);
					} else {
						CurrentApplication.MainPage = new NavigationPage(page);
					}
				}

			}

			var baseViewModel = page.BindingContext as IBaseViewModel;
			if(baseViewModel != null)
				await baseViewModel.InitializeAsync(parameter);
		}
	}
}
