using System.Threading.Tasks;
using System.Windows.Input;

namespace Xamarin.Start.Core.Contracts.Helpers {
	/// <summary>
	/// Extension of ICommand which exposes a raise execute handler and async support.
	/// </summary>
	public interface IAsyncCommand : ICommand {
		/// <summary>
		/// Call this to raise the CanExecuteChanged event.
		/// </summary>
		void RaiseCanExecuteChanged();

		/// <summary>
		/// Executes the command and returns the async Task.
		/// </summary>
		/// <returns>async result</returns>
		/// <param name="parameter">Parameter.</param>
		Task ExecuteAsync(object parameter);
	}

	/// <summary>
	/// Extension of ICommand which exposes a raise execute handler.
	/// </summary>
	public interface IAsyncCommand<T> : IAsyncCommand {
		/// <summary>
		/// Executes the command and returns the async Task.
		/// </summary>
		/// <returns>async result</returns>
		/// <param name="parameter">Parameter.</param>
		Task ExecuteAsync(T parameter);
	}
}
