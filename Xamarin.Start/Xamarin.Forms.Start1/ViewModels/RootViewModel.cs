using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Contracts.Services.General;
using Xamarin.Forms.Start1.Contracts.ViewModels;
using Xamarin.Forms.Start1.Helpers;
using Xamarin.Forms.Start1.ViewModels;

namespace Xamarin.Forms.Start1.ViewModels {
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
