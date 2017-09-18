using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.Services.General;
using Xamarin.Start.Core.Contracts.ViewModels;

namespace Xamarin.Start.Core.ViewModels {
	public class LoadingViewModel : BaseViewModel, ILoadingViewModel {
		public LoadingViewModel(INavigationService navigationService,
			IConnectionService connectionService,
			IDialogService dialogService) : base(navigationService, connectionService, dialogService) {

			IsLoading = true;
		}

		public async Task Init() {
			IsLoading = true;

			if(await FetchAllData())
				await _navigationService.NavigateToAsync<IRootViewModel>(true);

			Task.WaitAll();
			//IsLoading = false;
		}

		private async Task<bool> FetchAllData() {
			await Task.Delay(1000);
			return true;
		}
	}
}
