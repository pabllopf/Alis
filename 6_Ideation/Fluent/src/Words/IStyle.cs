

namespace Alis.Core.Aspect.Fluent.Words
{
/// <summary>
    ///     Fluent builder interface that applies a named visual style, theme,
    ///     or CSS-like configuration to a UI element or entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The style definition — a style object, theme key, or style sheet reference.</typeparam>
    /// <remarks>
    ///     Styles bundle visual properties (colors, fonts, borders, spacing)
    ///     into reusable configurations. Changes to a style propagate to all
    ///     elements that reference it.
    /// </remarks>
    public interface IStyle<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies a visual style or theme to the builder's target element.
        /// </summary>
        /// <param name="value">The style definition, theme key, or style sheet reference.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Style(TArgument value);
    }
}