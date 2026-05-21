

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the author or creator metadata
    ///     for a game entity, configuration, or asset.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The author name type, typically <see cref="string"/>.</typeparam>
    /// <remarks>
    ///     Commonly used for metadata tagging, debugging attribution, or
    ///     content pipeline tracking. Does not affect runtime behavior.
    /// </remarks>
    public interface IAuthor<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the author name on the builder.
        /// </summary>
        /// <param name="value">The author name string to assign to the entity or configuration.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Author(TArgument value);
    }
}