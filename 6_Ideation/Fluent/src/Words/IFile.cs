

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that specifies a file on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IFile<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Specifies a file on the builder.
        /// </summary>
        /// <param name="value">The file parameter to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder File(TArgument value);
    }
}