

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that determines the physics body type
    ///     for a collider or rigid body component.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The body type enumeration or configuration, typically <see cref="BodyType"/>.</typeparam>
    /// <remarks>
    ///     The body type affects how the physics engine treats the entity:
    ///     <list type="bullet">
    ///         <item><description><c>Static</c> — immovable, zero mass, not affected by forces</description></item>
    ///         <item><description><c>Dynamic</c> — fully simulated, affected by forces and collisions</description></item>
    ///         <item><description><c>Kinematic</c> — moved via code, not affected by forces but participates in collisions</description></item>
    ///     </list>
    /// </remarks>
    public interface IBodyType<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the physics body type on the builder.
        /// </summary>
        /// <param name="value">The body type to apply — static, dynamic, or kinematic.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder BodyType(TArgument value);
    }
}