using System;

namespace Alis.FluentApi
{
    public interface IBuilder<T>
    {
        public static T Builder()
        {
            return (T) Activator.CreateInstance(typeof(T), true);
        }
    }
}