using System;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{

    public abstract class MethodsBase<T>
    {

        protected internal readonly T Parent;

        internal MethodsBase(T parent) => Parent = parent;

        protected internal async Task<TRequest> Process<TRequest>(Task<string> task) where TRequest : Response
        {
            var ret = PddApi.Serializer.Deserialize<TRequest>((await task.ConfigureAwait(false)).ToJSONReader());
            if (!ret.Success)
            {
                throw new Exception($"Requested for {ret.Domain} failed: {ret.Error}");
            }
            return ret;
        }
    }

}