using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Contracts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Start1.Views {
	public partial class LoadingView : ContentPage {
		public LoadingView() {
			InitializeComponent();
		}

		protected override void OnAppearing() {
			((ILoadingViewModel)BindingContext).Init();
		}
	}
}