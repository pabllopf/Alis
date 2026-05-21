

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the software license
    ///     or usage terms for the application or game.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The license type — typically a string, enum, or license descriptor object.</typeparam>
    /// <remarks>
    ///     This is primarily used for metadata, splash screens, or compliance checks.
    ///     Common values include "MIT", "GPL-3.0", "Commercial", etc.
    ///     The license does not affect runtime behavior.
    /// </remarks>
    public interface ILicense<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the license identifier on the builder.
        /// </summary>
        /// <param name="value">The license string, enum value, or license descriptor.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder License(TArgument value);
    }
}