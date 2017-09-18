using FFImageLoading.Config;
using System;
using FFImageLoading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Start.Core.Contracts.Services.General;
using Xamarin.Start.Core.Contracts.ViewModels;
using Xamarin.Start.Core.Helpers;
using Xamarin.Start.Core.Views;
using Xamarin.Forms;

namespace Xamarin.Start.Core {
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
