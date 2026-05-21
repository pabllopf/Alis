

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures physics properties
    ///     and simulation parameters for a game entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The physics configuration type — body properties, collision settings, or a preset identifier.</typeparam>
    /// <remarks>
    ///     Applies a broad set of physics parameters at once. For granular control,
    ///     use specific interfaces: <see cref="IBodyType"/>, <see cref="IMass"/>,
    ///     <see cref="IDensity"/>, <see cref="IRestitution"/>, <see cref="IFriction"/>.
    /// </remarks>
    public interface IPhysic<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures physics properties on the builder.
        /// </summary>
        /// <param name="value">The physics configuration — body properties, collision settings, or a preset identifier.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Physic(TArgument value);
    }
}