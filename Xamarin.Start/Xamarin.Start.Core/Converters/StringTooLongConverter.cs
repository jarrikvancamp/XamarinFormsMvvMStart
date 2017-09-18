using System;
using System.Globalization;
using Xamarin.Start.Core.Constants;
using Xamarin.Forms;

namespace Xamarin.Start.Core.Converters {
	public class StringTooLongConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if(value != null) {
				int count = value.ToString().Length;
				if(count >= AppConstants.ApplicationStringCutOffLength) {
					return true;
				}
				return false;
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new InvalidOperationException("StringTooLongConverter");
		}
	}
}
