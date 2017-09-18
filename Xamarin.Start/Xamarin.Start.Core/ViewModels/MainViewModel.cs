using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.Services.General;
using Xamarin.Start.Core.Contracts.ViewModels;

namespace Xamarin.Start.Core.ViewModels {
	class MainViewModel : BaseViewModel, IMainViewModel {
		public MainViewModel(INavigationService navigationService, IConnectionService connectionService, IDialogService dialogService) : base(navigationService, connectionService, dialogService) {
		}
	}
}
