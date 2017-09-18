using System;
using System.Globalization;
using Xamarin.Forms.Start1.Constants;
using Xamarin.Forms;

namespace Xamarin.Forms.Start1.Converters {
	public class NumberTooHighConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			return ((int)value) > Cutoff;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
		public int Cutoff { get; set; } = AppConstants.ApplicationNumberTooHigh;

	}
}
