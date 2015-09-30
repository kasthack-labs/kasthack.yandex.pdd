using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd.Methods {

    public abstract class MethodsBase<T> {

        protected internal readonly T Parent;

        internal MethodsBase( T parent ) { Parent = parent; }

        protected internal async Task<TRequest> Process<TRequest>( Task<string> task ) => PddApi.Serializer.Deserialize<TRequest>( ( await task.ConfigureAwait( false ) ).ToJSONReader() );

    }

}