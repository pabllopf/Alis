

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets a file system path or resource path
    ///     on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The path type, typically <see cref="string"/> representing a file or resource path.</typeparam>
    /// <remarks>
    ///     Used to specify paths for assets, configuration files, level data, or log output.
    ///     The path may be absolute, relative to the application root, or a virtual resource path.
    /// </remarks>
    public interface IFilePath<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the file or resource path on the builder.
        /// </summary>
        /// <param name="value">The file path or resource path to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder File(TArgument value);
    }
}