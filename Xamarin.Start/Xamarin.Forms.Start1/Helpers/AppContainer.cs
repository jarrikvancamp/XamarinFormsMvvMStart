using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Start1.Helpers {
	public static class AppContainer {
		private static IContainer _container;
		private static readonly List<Module> _extraModules = new List<Module>();

		public static T Resolve<T>() {

			if(_container == null) {
				_container = CreateIocContainer();
			}
			return _container.Resolve<T>();
		}

		public static object Resolve(Type type) {
			if(_container == null) {
				_container = CreateIocContainer();
			}
			return _container.Resolve(type);
		}

		public static T Resolve<T>(object objectToPass) {
			if(_container == null) {
				_container = CreateIocContainer();
			}
			return _container.Resolve<T>(new NamedParameter("objectToPass", objectToPass));
		}

		public static void AddExtraModule(Module registerCallBack) {
			_extraModules.Add(registerCallBack);
		}

		private static IContainer CreateIocContainer() {
			var containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterModule<AppModule>();
			foreach(var extraModule in _extraModules) {
				containerBuilder.RegisterModule(extraModule);
			}
			var container = containerBuilder.Build();
			return container;
		}

		public static void RefreshContainer() {
			_container = null;
		}
	}
}
