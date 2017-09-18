using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Start1.Helpers {
	public class UrlBuilder {
		private readonly StringBuilder _url = new StringBuilder();
		public UrlBuilder(string url) {
			if(string.IsNullOrWhiteSpace(url))
				return;
			_url.Append(url.Trim());
		}

		public StringBuilder Url => _url;

		public UrlBuilder Append(string path) {
			if(!string.IsNullOrWhiteSpace(path)) {
				path = path.Trim();
				if(Url[Url.Length - 1] == '/') {
					if(path[0] == '/') {
						Url.Remove(Url.Length - 1, 1);
					}
				} else {
					if(path[0] != '/') {
						Url.Append('/');
					}
				}
				Url.Append(path);
			}
			return this;
		}
		public override string ToString() {
			return Url.ToString();
		}
		public Uri ToUri() {
			return new Uri(ToString());
		}
	}
}
