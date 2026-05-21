

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that initiates the creation of a game entity
    ///     or game object within a scene.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The creation parameter type — typically an entity name, prefab reference, or spawn configuration.</typeparam>
    /// <remarks>
    ///     This marks the beginning of a fluent entity construction chain.
    ///     After calling <c>Create</c>, additional fluent calls (e.g., <see cref="IPosition2D"/>,
    ///     <see cref="IGraphic"/>) can modify the entity before <see cref="IRun"/> finalizes it.
    /// </remarks>
    public interface ICreate<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Creates a new game entity with the specified creation parameters.
        /// </summary>
        /// <param name="obj">The creation parameters — may be a name string, prefab ID, or spawn configuration.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Create(TArgument obj);
    }
}