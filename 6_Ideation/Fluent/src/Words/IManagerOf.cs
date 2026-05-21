

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that registers or configures a manager component
    ///     responsible for coordinating a specific subsystem or resource type.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The manager configuration or type parameter.</typeparam>
    /// <remarks>
    ///     Managers handle cross-cutting concerns like audio management,
    ///     entity pooling, event dispatching, or resource lifecycle.
    ///     This interface allows binding a manager to a specific context or scope.
    /// </remarks>
    public interface IManagerOf<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures a manager of a specific type on the builder.
        /// </summary>
        /// <typeparam name="T">The specific manager type to configure.</typeparam>
        /// <param name="value">The manager configuration instance or parameters.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder ManagerOf<T>(TArgument value);
    }
}