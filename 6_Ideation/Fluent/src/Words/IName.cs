

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that assigns a human-readable name
    ///     to a game entity, component, or configuration object.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The name type, typically <see cref="string"/>.</typeparam>
    /// <remarks>
    ///     Entity names are used for debugging, scene hierarchy display, and runtime lookups.
    ///     Names are not required to be unique but are highly recommended for editor workflows.
    /// </remarks>
    public interface IName<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Assigns a name to the builder's target entity or configuration.
        /// </summary>
        /// <param name="value">The name string to assign.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Name(TArgument value);
    }
}