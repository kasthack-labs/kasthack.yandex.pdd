namespace kasthack.yandex.pdd {
    public abstract class MethodsBase<T> {
        protected internal readonly T Parent;

        internal MethodsBase( T parent ) { Parent = parent; }
    }
}