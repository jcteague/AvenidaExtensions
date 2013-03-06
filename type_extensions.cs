using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AvenidaSoftware.Extensions {

	public static class type_extensions {

		public static Type un_box_type(this Type type){
			return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) ? type.GetGenericArguments()[0] : type;
		}

        public static IEnumerable<PropertyInfo> get_public_writable_instance_properties(this Type type){
            return type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanWrite);
        }

        public static bool inherits_from<InterfaceType>(this Type type){
            return typeof (InterfaceType).IsAssignableFrom(type);
        }
	}

}