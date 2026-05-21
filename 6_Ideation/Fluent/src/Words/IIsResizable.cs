

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that enables or disables resizing behavior
    ///     for a game window, UI element, or render surface.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The resizable state — typically a boolean toggle (no-argument overload always enables).</typeparam>
    /// <remarks>
    ///     When resizable is enabled, the user or system can change the dimensions
    ///     of the target (e.g., game window or UI panel). Disabling fixes the size.
    /// </remarks>
    public interface IIsResizable<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Enables resizing on the builder (no argument overload — always enabled).
        /// </summary>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder IsResizable();
    }
}