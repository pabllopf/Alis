namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Defines an interface for quick access to a type member.
    /// </summary>
    public interface IMemberAccessor
    {
        /// <summary>
        ///     Gets a component value.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns>The value.</returns>
        object Get(object component);

        /// <summary>
        ///     Sets a component's value.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="value">The value to set.</param>
        void Set(object component, object value);
    }
}