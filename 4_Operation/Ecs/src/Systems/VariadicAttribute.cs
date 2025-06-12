
using System;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    /// The variadic attribute class
    /// </summary>
    /// <seealso cref="Attribute"/>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class VariadicAttribute : Attribute
    {
        /// <summary>
        /// The from
        /// </summary>
        private readonly string _from;
        /// <summary>
        /// The pattern
        /// </summary>
        private readonly string _pattern;
        /// <summary>
        /// The count
        /// </summary>
        private readonly int _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariadicAttribute"/> class
        /// </summary>
        /// <param name="from">The from</param>
        /// <param name="pattern">The pattern</param>
        /// <param name="count">The count</param>
        public VariadicAttribute(string from, string pattern, int count = 16)
        {
            _from = from;
            _pattern = pattern;
            _count = count;
        }
    }
}