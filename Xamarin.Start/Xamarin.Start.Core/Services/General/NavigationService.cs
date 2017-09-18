using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.Services.General;
using Xamarin.Start.Core.Contracts.ViewModels;
using Xamarin.Start.Core.Helpers;
using Xamarin.Start.Core.Views;
using Xamarin.Forms;

namespace Xamarin.Start.Core.Services.General {
	public class NavigationService : INavigationService {
		protected readonly Dictionary<Type, Type> Mappings;

		public NavigationService() {
			Mappings = new Dictionary<Type, Type>();
			CreatePageViewModelMappings();
		}

		protected Application CurrentApplication => Application.Current;

		public void InitializeAsync() {
			Page page = CreateAndBindPage(typeof(ILoadingViewModel), null);
			Application.Current.MainPage = new NavigationPage(page) {
				BarBackgroundColor = Color.FromHex("#FFF")
			};
		}

		public async Task NavigateBackAsync() {
			var view = CurrentApplication.MainPage as RootView;
			if(view != null) {
				var mainPage = view;
				await mainPage.Detail.Navigation.PopAsync();
			} else if(CurrentApplication.MainPage != null) {
				await CurrentApplication.MainPage.Navigation.PopAsync();
			}
		}

		public Task NavigateToAsync<TViewModel>(bool changeDetail = false) where TViewModel : IBaseViewModel {
			return InternalNavigateToAsync(typeof(TViewModel), null, changeDetail);
		}

		public Task NavigateToAsync<TViewModel>(object parameter, bool changeDetail = false) where TViewModel : IBaseViewModel {
			return InternalNavigateToAsync(typeof(TViewModel), parameter, changeDetail);
		}

		public Task NavigateToAsync(Type viewModelType, bool changeDetail = false) {
			return InternalNavigateToAsync(viewModelType, null, changeDetail);
		}

		public Task NavigateToAsync(Type viewModelType, object parameter, bool changeDetail = false) {
			return InternalNavigateToAsync(viewModelType, parameter, changeDetail);
		}

		public Task PopModalAsync() {
			return CurrentApplication.MainPage.Navigation.PopModalAsync();
		}

		public Task PushModalAsync<TViewModel>() where TViewModel : IBaseViewModel {
			return InternalNavigateToModalAsync(typeof(TViewModel), null);
		}

		public Task PushModalAsync<TViewModel>(object parameter) where TViewModel : IBaseViewModel {
			return InternalNavigateToModalAsync(typeof(TViewModel), parameter);
		}

		public Task PushModalAsync(Type viewModelType) {
			return InternalNavigateToModalAsync(viewModelType, null);
		}

		public Task PushModalAsync(Type viewModelType, object parameter) {
			return InternalNavigateToModalAsync(viewModelType, parameter);
		}

		public virtual Task RemoveLastFromBackStackAsync() {
			var mainPage = CurrentApplication.MainPage as RootView;

			mainPage?.Detail.Navigation.RemovePage(
				mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);

			return Task.FromResult(true);
		}

		protected Page CreateAndBindPage(Type viewModelType, object parameter) {
			Type pageType = GetPageTypeForViewModel(viewModelType);

			if(pageType == null) {
				throw new Exception($"Mapping type for {viewModelType} is not a page");
			}

			Page page = Activator.CreateInstance(pageType) as Page;
			IBaseViewModel viewModel = AppContainer.Resolve(viewModelType) as IBaseViewModel;
			page.BindingContext = viewModel;

			return page;
		}

		protected Type GetPageTypeForViewModel(Type viewModelType) {
			if(!Mappings.ContainsKey(viewModelType)) {
				throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
			}

			return Mappings[viewModelType];
		}

		protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter, bool changeDetail) {
			var page = CreateAndBindPage(viewModelType, parameter);

			if(page is RootView) {
				try {
					CurrentApplication.MainPage = page;

				} catch(Exception e) {
					string a = e.Message;
				}
			} else {
				var view = CurrentApplication.MainPage as RootView;
				if(view != null) {
					var mainPage = view;
					var navigationPage = mainPage.Detail as NavigationPage;

					if(navigationPage != null) {

						await navigationPage.PushAsync(page);
						if(changeDetail)
							await RemoveLastFromBackStackAsync();
					} else {
						navigationPage = new NavigationPage(page) {


						};
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

		protected virtual async Task InternalNavigateToModalAsync(Type viewModelType, object parameter) {
			Page page = CreateAndBindPage(viewModelType, parameter);

			await CurrentApplication.MainPage.Navigation.PushModalAsync(page);
			var baseViewModel = page.BindingContext as IBaseViewModel;
			if(baseViewModel != null)
				await baseViewModel.InitializeAsync(parameter);
		}

		private void CreatePageViewModelMappings() {
			Mappings.Add(typeof(IMainViewModel), typeof(MainPage));
			Mappings.Add(typeof(ILoadingViewModel), typeof(LoadingView));
			Mappings.Add(typeof(IRootViewModel), typeof(RootView));
		}
	}
}
