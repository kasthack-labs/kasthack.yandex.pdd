using System.Collections.Generic;
using System.Linq;

namespace kasthack.yandex.pdd.RawMethods {
    public abstract class RawMethodsBase {
        protected internal readonly DomainRawContextBase Context;

        protected internal IEnumerable<KeyValuePair<string, string>> EmptyParams => Enumerable.Empty<KeyValuePair<string, string>>();

        internal RawMethodsBase( DomainRawContextBase context ) { Context = context; }
    }
}