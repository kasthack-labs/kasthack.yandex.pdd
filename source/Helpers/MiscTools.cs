using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace kasthack.yandex.pdd.Helpers {
    internal static class MiscTools {
        /// <summary>
        /// Converts CamelCase targetInnerType snake_case
        /// </summary>
        /// <param name="name">Name for converting</param>
        /// <param name="separator">Word separator</param>
        /// <returns>Converted string</returns>
        public static string ToSnake( this string name, char separator = '_' ) {
            var t = new StringBuilder();
            t.Append( Char.ToLower( name[ 0 ] ) );
            for ( var index = 1; index < name.Length; index++ ) {
                var c = name[ index ];
                //add '_' before numbers and captials 
                if ( Char.IsUpper( c )
                     || ( Char.IsNumber( c ) && !Char.IsNumber( name[ index - 1 ] ) ) ) {
                    t.Append( separator );
                    t.Append( Char.ToLower( c ) );
                }
                else t.Append( c );
            }
            return t.ToString();
        }

        public static string ToMeth( this string name, bool p = false, char separator = '_' ) {
            var t = new StringBuilder();
            t.Append( p ? Char.ToLower( name[ 0 ] ) : Char.ToUpper( name[ 0 ] ) );
            for ( var index = 1; index < name.Length; index++ ) {
                var c = name[ index ];
                //add '_' before numbers and capitals 
                if ( c == '.'
                     || c == separator ) t.Append( Char.ToUpper( name[ ++index ] ) );
                else t.Append( c );
            }
            return t.ToString();
        }

        public static string ToNCString<T>( this T? input ) where T : struct, IFormattable => input?.ToNCString();

        public static string ToNCString<T>( this T value ) where T : IFormattable
            => ( (IFormattable) value ).ToString( null, BuiltInData.Instance.NC );

        public static string ToNClString<T>( this T value ) where T : IFormattable
            => ( (IFormattable) value ).ToString( null, BuiltInData.Instance.NC ).ToLowerInvariant();

        public static string ToNCStringA<T>( this IEnumerable<T> value ) where T : IFormattable
            => String.Join( ",", value.Select( a => ToNCString( a ) ) );

        public static string ToYesNo( this bool value ) => value ? "yes" : "no";
        public static string ToYesNo( this bool? value ) => value?.ToYesNo();
        public static JsonReader ToJSONReader( this string source ) => new JsonTextReader( new StringReader( source ) );

        public static StringContent StringContent( string name, string value ) => new StringContent(value) { Headers = { ContentDisposition = { Name = name } } };

        public static StreamContent StreamContent( string name, Stream value ) => new StreamContent( value ) { Headers = { ContentDisposition = new ContentDispositionHeaderValue( "form-data" ) { FileName = name } } };

    } //
}