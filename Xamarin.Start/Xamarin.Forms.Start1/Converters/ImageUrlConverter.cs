using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamarin.Forms.Start1.Converters {
	public class ImageUrlConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if(value is string) {
				return $"{Constants.ApiConstants.ImageUrl}{value as string}";
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			return null;
		}
	}
}
