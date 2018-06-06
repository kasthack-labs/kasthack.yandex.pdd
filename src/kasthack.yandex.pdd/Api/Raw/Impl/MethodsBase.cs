using System.Collections.Generic;
using System.Linq;

namespace kasthack.yandex.pdd.RawMethods
{
    internal abstract class MethodsBase
    {
        protected internal readonly DomainRawContext Context;

        protected internal IEnumerable<KeyValuePair<string, string>> EmptyParams => Enumerable.Empty<KeyValuePair<string, string>>();

        internal MethodsBase(DomainRawContext context) => Context = context;
    }
}