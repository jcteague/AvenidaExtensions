using System;
using System.Collections.Generic;
using System.Reflection;

namespace AvenidaSoftware.Extensions {
	
	public static class object_extensions {
		
		// TODO: find out why the summary isnt showing
		/// <summary>
		/// Calls .ToString() if the object is not null
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string to_string( this object obj ) {
			return obj == null ? null : obj.ToString( );
		}

        public static IEnumerable<PropertyInfo> get_public_writable_instance_properties(this object obj){
            return obj.GetType().get_public_writable_instance_properties();
        }

		public static object get_property_value( this object instance, string property_name ) {
			var instance_type = instance.GetType( );
			var property_info = instance_type.GetProperty( property_name );
            
			if(property_info.is_null()) throw new Exception( "Could not find property with name: " + property_name );

			return property_info.GetValue( instance, null );
		}

		public static object try_get_property_value( this object instance, string property_name, object default_value = null ) {
			try {
				return instance.get_property_value( property_name );
			} catch( Exception ) {
				return default_value;
			}
		}

		public static bool is_null( this object obj ) {
			return obj == null;
		}

		public static bool is_not_null( this object obj ) {
			return obj != null;
		}

		public static IEnumerable<T> to_enumerable< T >( this T obj ) {
			return new [ ] { obj };
		}
	}

}