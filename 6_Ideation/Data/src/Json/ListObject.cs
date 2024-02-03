using System.Collections.Generic;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Defines an object that handles list deserialization.
    /// </summary>
    public abstract class ListObject
    {
        /// <summary>
        ///     Gets or sets the list object.
        /// </summary>
        /// <value>
        ///     The list.
        /// </value>
        public virtual object List { get; set; }

        /// <summary>
        ///     Gets the current context.
        /// </summary>
        /// <value>
        ///     The context. May be null.
        /// </value>
        public virtual IDictionary<string, object> Context => null;

        /// <summary>
        ///     Clears the list object.
        /// </summary>
        public abstract void Clear();

        /// <summary>
        ///     Adds a value to the list object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="options">The options.</param>
        public abstract void Add(object value, JsonOptions options = null);
    }
}