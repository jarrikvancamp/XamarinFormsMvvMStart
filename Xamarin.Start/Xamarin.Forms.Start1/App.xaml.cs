using FFImageLoading.Config;
using System;
using FFImageLoading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Start1.Contracts.Services.General;
using Xamarin.Forms.Start1.Contracts.ViewModels;
using Xamarin.Forms.Start1.Helpers;
using Xamarin.Forms.Start1.Views;
using Xamarin.Forms;

namespace Xamarin.Forms.Start1 {
	public partial class App : Application {
		public App() {
			InitNavigation();
		}

		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			base.OnResume();
			var rootView = MainPage as RootView;
			if(rootView != null) {
				var navigationPage = rootView.Detail as NavigationPage;
				if(navigationPage != null) {
				}
			}
		}

		private void InitNavigation() {
			var navigationService = AppContainer.Resolve<INavigationService>();
			navigationService.InitializeAsync();
		}
	}
}
