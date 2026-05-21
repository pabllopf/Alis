

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the background properties
    ///     of a game scene or entity's visual representation.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The background configuration type, typically a color, texture, or scene background descriptor.</typeparam>
    /// <remarks>
    ///     Used to configure the scene background color, skybox, or backdrop texture.
    ///     For UI elements, this may set the panel background sprite or color tint.
    /// </remarks>
    public interface IBackground<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the background on the builder.
        /// </summary>
        /// <param name="value">The background configuration value — a color, texture reference, or background descriptor.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Background(TArgument value);
    }
}