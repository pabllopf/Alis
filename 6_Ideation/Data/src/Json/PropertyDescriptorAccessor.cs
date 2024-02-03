using System.ComponentModel;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The property descriptor accessor class
    /// </summary>
    /// <seealso cref="IMemberAccessor" />
    internal sealed class PropertyDescriptorAccessor : IMemberAccessor
    {
        /// <summary>
        ///     The pd
        /// </summary>
        private readonly PropertyDescriptor _pd;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyDescriptorAccessor" /> class
        /// </summary>
        /// <param name="pd">The pd</param>
        public PropertyDescriptorAccessor(PropertyDescriptor pd) => _pd = pd;

        /// <summary>
        ///     Gets the component
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The object</returns>
        public object Get(object component) => _pd.GetValue(component);

        /// <summary>
        ///     Sets the component
        /// </summary>
        /// <param name="component">The component</param>
        /// <param name="value">The value</param>
        public void Set(object component, object value)
        {
            if (_pd.IsReadOnly)
                return;

            _pd.SetValue(component, value);
        }
    }
}