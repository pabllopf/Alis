

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that controls the active (enabled/disabled)
    ///     state of a game entity or component.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The activation state — typically <see langword="true"/> or <see langword="false"/>.</typeparam>
    /// <remarks>
    ///     Deactivated entities are excluded from update, draw, and physics loops
    ///     but remain in the scene hierarchy. The entity can be re-activated later.
    ///     Related interfaces: <see cref="IOnExit"/>.
    /// </remarks>
    public interface IIsActive<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the active (enabled) state on the builder.
        /// </summary>
        /// <param name="value"><see langword="true"/> to activate the entity; <see langword="false"/> to deactivate it.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder IsActive(TArgument value);
    }
}