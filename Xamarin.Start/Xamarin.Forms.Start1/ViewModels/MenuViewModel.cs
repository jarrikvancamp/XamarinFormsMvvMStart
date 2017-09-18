using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Contracts.Helpers;
using Xamarin.Forms.Start1.Contracts.Services.General;
using Xamarin.Forms.Start1.Contracts.ViewModels;
using Xamarin.Forms.Start1.Helpers;
using Xamarin.Forms.Start1.Model.App;
using Xamarin.Forms.Start1.Model.Enums;
using Xamarin.Forms.Start1.ViewModels;

namespace Xamarin.Forms.Start1.ViewModels {
	public class MenuViewModel : BaseViewModel, IMenuViewModel {
		private IAsyncCommand<HomeMenuItem> _navigateToCommand;
		private HomeMenuItem _selectedHomeMenuItem;

		public MenuViewModel(INavigationService navigationService,
			IConnectionService connectionService,
			IDialogService dialogService)
			: base(navigationService, connectionService, dialogService) {
			MenuItems = new List<HomeMenuItem>
			{
				new HomeMenuItem("First", "ic_first", MenuType.First),
				new HomeMenuItem("Scecond", "ic_second", MenuType.Second),
				new HomeMenuItem("Third", "ic_third", MenuType.Third)
				 };
			SelectedHomeMenuItem = MenuItems[0];
		}

		public IList<HomeMenuItem> MenuItems { get; set; }
		public IAsyncCommand<HomeMenuItem> NavigateToCommand => _navigateToCommand ?? (_navigateToCommand = new AsyncCommand<HomeMenuItem>(NavigateTo));

		public HomeMenuItem SelectedHomeMenuItem {
			get { return _selectedHomeMenuItem; }
			set { SetProperty(ref _selectedHomeMenuItem, value); }
		}

		private async Task NavigateTo(HomeMenuItem homeMenuItem) {
			Type viewModel;
			switch(homeMenuItem.MenuType) {
				case MenuType.First:
					viewModel = typeof(IMainViewModel); //todo: ordersvm
					break;

				case MenuType.Second:
					viewModel = typeof(IMainViewModel);
					break;

				case MenuType.Third:
					viewModel = typeof(IMainViewModel);
					break;

				default:
					throw new ArgumentException($"{homeMenuItem.MenuType} not known!");
			}
			await _navigationService.NavigateToAsync(viewModel, true);
		}
	}
}
