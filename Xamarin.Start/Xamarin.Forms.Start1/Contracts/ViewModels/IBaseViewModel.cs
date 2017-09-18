using System.Threading.Tasks;

namespace Xamarin.Forms.Start1.Contracts.ViewModels {
	public interface IBaseViewModel {
		Task InitializeAsync(object navigationData);
	}
}
