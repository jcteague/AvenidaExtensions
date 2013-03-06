using System.Linq;
using System.Reflection;

namespace AvenidaSoftware.Extensions {

	public static class property_info_extensions {

		public static T get_attribute<T>(this PropertyInfo property_info) where T : class {
			var the_attribute = property_info.GetCustomAttributes(typeof (T), true).FirstOrDefault();
			return the_attribute as T;
		}

	}

}