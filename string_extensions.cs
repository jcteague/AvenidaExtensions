using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AvenidaSoftware.Extensions {

	public static class string_extensions {
		public static string wordify( this string str, string spacer = " " ) {
			if( !Regex.IsMatch( str, "[a-z]" ) ) return str;
			return string.Join( spacer, Regex.Split( str, @"(?<!^)(?=[A-Z])" ) );
		}
		
		public static bool is_null_or_empty( this string str ) {
			return string.IsNullOrEmpty( str );
		}

		public static bool is_not_null_nor_empty( this string s ) {
			return !String.IsNullOrEmpty( s );
		}

		public static string uppercase_first( this string s ) {
			if( string.IsNullOrEmpty( s ) ) return s;
			
			return char.ToUpper( s[ 0 ] ) + s.Substring( 1 );
		}

		public static string format( this string s, params object [ ] elements ) {
			return String.Format( s, elements );
		}

		public static int count_occurences( this string s, string needle ) {
			return Regex.Matches( s, needle ).Count;
		}

		static readonly IList<string> unpluralizables = new List<string> { "equipment", "information", "rice", "money", "species", "series", "fish", "sheep", "deer" };

		static readonly IDictionary<string, string> pluralizations = new Dictionary<string, string> { // Start with the rarest cases, and move to the most common
		{ "person", "people" }, { "ox", "oxen" }, { "child", "children" }, { "foot", "feet" }, { "tooth", "teeth" }, { "goose", "geese" }, // And now the more standard rules.
		{ "(.*)fe?", "$1ves" }, // ie, wolf, wife
		{ "(.*)man$", "$1men" }, { "(.+[aeiou]y)$", "$1s" }, { "(.+[^aeiou])y$", "$1ies" }, { "(.+z)$", "$1zes" }, { "([m|l])ouse$", "$1ice" }, { "(.+)(e|i)x$", @"$1ices" }, // ie, Matrix, Index
		{ "(octop|vir)us$", "$1i" }, { "(.+(s|x|sh|ch))$", @"$1es" }, { "(.+)", @"$1s" } };

		public static string pluralize( this string singular ) {
			var last_word = singular.wordify().Split(' ').Last();

			if( unpluralizables.Contains( last_word.ToLower() ) ) return singular;

			var plural = "";
			var key_value_pairs = pluralizations.Where( pluralization => Regex.IsMatch( singular, ( string ) pluralization.Key ) );

			foreach( var pluralization in key_value_pairs ) {
				plural = Regex.Replace( singular, pluralization.Key, pluralization.Value );
				break;
			}

			return plural;
		}
	}

}