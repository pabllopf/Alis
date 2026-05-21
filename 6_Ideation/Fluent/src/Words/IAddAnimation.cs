

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that attaches an animation clip or animation name
    ///     to a game entity for playback during the rendering loop.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The animation identifier, clip reference, or configuration object.</typeparam>
    /// <remarks>
    ///     Use this interface to assign sprite-sheet animations, skeletal animations,
    ///     or procedural animations to an entity. The argument type typically maps
    ///     to an <see cref="IAnimation"/> or a string-based animation key.
    /// </remarks>
    public interface IAddAnimation<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Adds the specified animation to the builder's target entity.
        /// </summary>
        /// <param name="value">The animation clip, key, or configuration to apply. Must not be null.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder AddAnimation(TArgument value);
    }
}