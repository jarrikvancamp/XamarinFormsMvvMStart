using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Start1.Model.App;
using Xamarin.Forms.Start1.Model.Enums;
using Xamarin.Forms;

namespace Xamarin.Forms.Start1.DataTemplateSelectors {
	public class MenuDataTemplateSelector : DataTemplateSelector {
		public DataTemplate HeaderTemplate { get; set; }
		public DataTemplate MenuItemTemplate { get; set; }
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
			var menuItem = (HomeMenuItem)item;
			//if (menuItem.MenuType.Equals(MenuType.))
			//	return HeaderTemplate;
			//else
			return MenuItemTemplate;
		}
	}
}
