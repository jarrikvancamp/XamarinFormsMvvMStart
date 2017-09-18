using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Contracts.Services.General;
using Xamarin.Forms.Start1.Contracts.ViewModels;

namespace Xamarin.Forms.Start1.ViewModels {
	class MainViewModel : BaseViewModel, IMainViewModel {
		public MainViewModel(INavigationService navigationService, IConnectionService connectionService, IDialogService dialogService) : base(navigationService, connectionService, dialogService) {
		}
	}
}
