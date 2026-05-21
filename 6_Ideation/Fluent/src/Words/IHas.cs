

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that specifies ownership or a has-a relationship
    ///     between a game entity and a child object or component.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The type of the owned child object or component.</typeparam>
    /// <remarks>
    ///     Establishes a parent-child relationship. For example, an entity may "have"
    ///     a weapon, a UI element may "have" a child panel, or a scene may "have" a subsystem.
    /// </remarks>
    public interface IHas<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Assigns a child object or component to the builder's target entity.
        /// </summary>
        /// <param name="obj">The child object or component to assign ownership of.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Has(TArgument obj);
    }
}