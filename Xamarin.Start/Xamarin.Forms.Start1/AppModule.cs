using Autofac;
using Xamarin.Forms.Start1.Contracts.ViewModels;
using Xamarin.Forms.Start1.Contracts.Api;
using Xamarin.Forms.Start1.Contracts.Messaging;
using Xamarin.Forms.Start1.Contracts.Services.General;
using Xamarin.Forms.Start1.Contracts.ViewModels;
using Xamarin.Forms.Start1.Messenger;
using Xamarin.Forms.Start1.Repositories.Client;
using Xamarin.Forms.Start1.Services.General;
using Xamarin.Forms.Start1.Views;
using Xamarin.Forms.Start1.ViewModels;
using Xamarin.Forms;

namespace Xamarin.Forms.Start1 {
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
