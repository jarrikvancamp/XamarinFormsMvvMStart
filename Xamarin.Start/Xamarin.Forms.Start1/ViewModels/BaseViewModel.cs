using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Contracts.Services.General;
using Xamarin.Forms.Start1.Contracts.ViewModels;
using Xamarin.Forms.Start1.Helpers;

namespace Xamarin.Forms.Start1.ViewModels {
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
