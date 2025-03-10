using System;

namespace Alis.Benchmark.EntityComponentSystem
{
    /// <summary>
    /// The context attribute class
    /// </summary>
    /// <seealso cref="Attribute"/>
    [AttributeUsage(AttributeTargets.Field)]
    internal sealed class ContextAttribute : Attribute
    { }
}
