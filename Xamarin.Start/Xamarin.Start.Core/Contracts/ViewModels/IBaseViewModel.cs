using System.Threading.Tasks;

namespace Xamarin.Start.Core.Contracts.ViewModels {
	public interface IBaseViewModel {
		Task InitializeAsync(object navigationData);
	}
}
