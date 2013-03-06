using System.Collections.Generic;

namespace AvenidaSoftware.Extensions {
	
	public static class dictionary_extensions {

		public static void try_add<TKey,TValue>( this Dictionary<TKey,TValue> dictionary, TKey key, TValue value) {
			 if( key == null || dictionary.ContainsKey( key )) return;
			 dictionary.Add( key,value );
		}

	}

}