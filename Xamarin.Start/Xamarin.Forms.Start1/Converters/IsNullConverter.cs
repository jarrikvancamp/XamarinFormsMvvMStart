using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.Forms.Start1.Converters {
	public class IsNullConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			return (value == null);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new InvalidOperationException("IsNullConverter");
		}
	}
}
