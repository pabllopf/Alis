using System;

namespace Frent.Sample
{
    /// <summary>
    /// The sample attribute class
    /// </summary>
    /// <seealso cref="Attribute"/>
    [AttributeUsage(AttributeTargets.Method)]
    internal class SampleAttribute : Attribute;
}