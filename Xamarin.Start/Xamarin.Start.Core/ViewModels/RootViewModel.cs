using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.Services.General;
using Xamarin.Start.Core.Contracts.ViewModels;
using Xamarin.Start.Core.Helpers;
using Xamarin.Start.Core.ViewModels;

namespace Xamarin.Start.Core.ViewModels {
	public class RootViewModel : ObservableObject, IRootViewModel {
		private readonly INavigationService _navigationService;
		private IMenuViewModel _menuViewModel;

		public RootViewModel(INavigationService navigationService, IMenuViewModel menuViewModel) {
			_navigationService = navigationService;
			_menuViewModel = menuViewModel;
		}

		public IMenuViewModel MenuViewModel {
			get { return _menuViewModel; }
			set { SetProperty(ref _menuViewModel, value); }
		}

		public async Task InitializeAsync(object navigationData) {
			await _navigationService.NavigateToAsync<IMainViewModel>();
		}
	}
}
