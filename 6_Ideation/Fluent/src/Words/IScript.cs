

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that attaches a script or behavior module
    ///     to a game entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The script type or instance — typically a <see cref="MonoBehaviour"/> subclass or scriptable object.</typeparam>
    /// <remarks>
    ///     Scripts define custom logic (AI, movement, interaction) for entities.
    ///     May accept either a type reference for instantiation or a pre-built instance
    ///     depending on the builder implementation.
    /// </remarks>
    public interface IScript<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Assigns a script to the builder's target entity.
        /// </summary>
        /// <param name="value">The script instance, type, or configuration to attach.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Script(TArgument value);
    }
}