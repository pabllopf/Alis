using System.Collections;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The list object class
    /// </summary>
    /// <seealso cref="ListObject" />
    internal sealed class IListObject : ListObject
    {
        /// <summary>
        ///     The list
        /// </summary>
        private IList _list;

        /// <summary>
        ///     Gets or sets the value of the list
        /// </summary>
        public override object List
        {
            get => base.List;
            set
            {
                base.List = value;
                _list = (IList) value;
            }
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public override void Clear() => _list.Clear();

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        public override void Add(object value, JsonOptions options = null) => _list.Add(value);
    }
}