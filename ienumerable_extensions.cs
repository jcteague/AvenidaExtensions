using System;
using System.Collections.Generic;

namespace AvenidaSoftware.Extensions {

	public static class ienumerable_extensions {

		public static void for_each< T >( this IEnumerable<T> enumeration, Action<T> action ) {
			foreach( var item in enumeration ) {
				action( item );
			}
		}
	}

}