using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.Services.General;
using Xamarin.Start.Core.Contracts.ViewModels;
using Xamarin.Start.Core.Helpers;

namespace Xamarin.Start.Core.ViewModels {
	public class BaseViewModel : ObservableObject, IBaseViewModel {
		protected readonly IConnectionService _connectionService;
		protected readonly IDialogService _dialogService;
		protected readonly INavigationService _navigationService;

		private bool _isLoading;

		public BaseViewModel(INavigationService navigationService, IConnectionService connectionService, IDialogService dialogService) {
			_navigationService = navigationService;
			_connectionService = connectionService;
			_dialogService = dialogService;
		}

		public bool IsLoading {
			get { return _isLoading; }
			set {
				SetProperty(ref _isLoading, value);
			}
		}

		public virtual Task InitializeAsync(object navigationData) {
			return Task.FromResult(false);
		}
	}
}
