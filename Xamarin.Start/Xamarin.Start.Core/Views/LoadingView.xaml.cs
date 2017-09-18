using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Start.Core.Contracts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Start.Core.Views {
	public partial class LoadingView : ContentPage {
		public LoadingView() {
			InitializeComponent();
		}

		protected override void OnAppearing() {
			((ILoadingViewModel)BindingContext).Init();
		}
	}
}