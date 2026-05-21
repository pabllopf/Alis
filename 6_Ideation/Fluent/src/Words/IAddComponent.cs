

using System;

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that attaches a typed component to a game entity
    ///     during the entity construction pipeline.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TType">The base type or interface that the component must implement.</typeparam>
    /// <remarks>
    ///     This interface supports two overloads: one that accepts a pre-constructed component
    ///     instance, and another that accepts a factory function for deferred construction.
    ///     The factory overload receives the entity being built as its argument.
    /// </remarks>
    public interface IAddComponent<out TBuilder, in TType>
    {
        /// <summary>
        ///     Adds a component to the builder using a factory function that receives the entity.
        /// </summary>
        /// <typeparam name="T">The specific component type, which must derive from <typeparamref name="TType"/>.</typeparam>
        /// <param name="value">A factory function that receives the entity and returns a component instance of type <typeparamref name="T"/>.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
        TBuilder AddComponent<T>(Func<T, TType> value) where T : TType;

        /// <summary>
        ///     Adds a pre-constructed component instance to the builder.
        /// </summary>
        /// <typeparam name="T">The specific component type, which must derive from <typeparamref name="TType"/>.</typeparam>
        /// <param name="value">The component instance to attach. Must not be null for reference types.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder AddComponent<T>(T value) where T : TType;
    }
}