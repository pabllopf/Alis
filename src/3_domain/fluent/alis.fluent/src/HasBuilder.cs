using System;

namespace Alis.Fluent
{
    public abstract class HasBuilder<T>
    {
        public static T Builder() => (T) Activator.CreateInstance(typeof(T), true);
    }
}