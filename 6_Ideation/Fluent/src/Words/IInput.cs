

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures input bindings and control mappings
    ///     for a game entity or the application.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The input configuration type — bindings, axes, or action maps.</typeparam>
    /// <remarks>
    ///     Used to define keyboard, mouse, gamepad, or touch controls.
    ///     The argument may reference an <see cref="IInputActionMap"/>, a key binding,
    ///     or an input scheme identifier.
    /// </remarks>
    public interface IInput<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures input bindings on the builder.
        /// </summary>
        /// <param name="value">The input configuration — action maps, key bindings, or control axes.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Input(TArgument value);
    }
}