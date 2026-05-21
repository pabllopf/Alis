

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the tag on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IWithTag<out TBuilder, in TArgument>
    {
        /// <summary>Withes the tag.</summary>
        /// <param name="value">The tag to apply.</param>
        /// <returns>return the object that you want.</returns>
        TBuilder WithTag(TArgument value);
    }
}