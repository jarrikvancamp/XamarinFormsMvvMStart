using Autofac;
using Xamarin.Start.Core.Contracts.ViewModels;
using Xamarin.Start.Core.Contracts.Api;
using Xamarin.Start.Core.Contracts.Messaging;
using Xamarin.Start.Core.Contracts.Services.General;
using Xamarin.Start.Core.Repositories.Client;
using Xamarin.Start.Core.Services.General;
using Xamarin.Start.Core.Views;
using Xamarin.Start.Core.ViewModels;
using Xamarin.Forms;

namespace Xamarin.Start.Core {
	public class AppModule : Module {
		protected override void Load(ContainerBuilder builder) {
			//API communication
			builder.RegisterType<WebApiClient>().As<IWebApiClient>().SingleInstance();

			//Messaging
			builder.RegisterType<Messenger.Messenger>().As<IMessenger>().SingleInstance();

			//Repositories - Mock


			//Repositories - Real
			//builder.RegisterType<HospitalRepository>().As<IHospitalRepository>().SingleInstance();

			//Data Services

			//Services
			if(Device.RuntimePlatform == Device.iOS) {
				builder.RegisterType<iOSNavigationService>().As<INavigationService>().SingleInstance();
			} else {
				builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
			}

			builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
			builder.RegisterType<ConnectionService>().As<IConnectionService>().SingleInstance();
			builder.RegisterType<InitializationService>().As<IInitializationService>();

			//View Models

			builder.RegisterType<MainViewModel>().As<IMainViewModel>();
			builder.RegisterType<LoadingViewModel>().As<ILoadingViewModel>();
			builder.RegisterType<MenuViewModel>().As<IMenuViewModel>().SingleInstance();
			builder.RegisterType<RootViewModel>().As<IRootViewModel>();

			//Views
			builder.RegisterType<MainPage>();
			builder.RegisterType<RootView>();
			builder.RegisterType<LoadingView>();
		}
	}
}
