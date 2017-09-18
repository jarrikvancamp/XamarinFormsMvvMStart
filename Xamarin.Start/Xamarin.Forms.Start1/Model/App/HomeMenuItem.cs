using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Model.Enums;

namespace Xamarin.Forms.Start1.Model.App {
	public class HomeMenuItem {
		public HomeMenuItem(string title, string icon, MenuType menuType) {
			Title = title;
			Icon = icon;
			MenuType = menuType;
		}

		public string Icon { get; private set; }
		public MenuType MenuType { get; private set; }
		public string Title { get; private set; }
	}
}
