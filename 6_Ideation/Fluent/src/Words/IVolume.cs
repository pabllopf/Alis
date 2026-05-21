

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the volume on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IVolume<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the volume on the builder.
        /// </summary>
        /// <param name="value">The volume level to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Volume(TArgument value);
    }
}