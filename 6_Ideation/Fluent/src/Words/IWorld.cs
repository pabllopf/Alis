

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that associates the builder with a specific
    ///     game world or scene context.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The world or scene reference type — typically a <see cref="Scene"/> or world identifier.</typeparam>
    /// <remarks>
    ///     Specifies which <see cref="Scene"/> or game world the entity belongs to.
    ///     Required when building entities that must be associated with a particular world
    ///     in multi-scene or multi-world setups.
    /// </remarks>
    public interface IWorld<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Assigns the target world or scene context to the builder.
        /// </summary>
        /// <param name="value">The world or scene reference to associate with this builder.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder World(TArgument value);
    }
}