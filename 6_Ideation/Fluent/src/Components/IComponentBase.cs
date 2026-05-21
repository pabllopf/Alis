

namespace Alis.Core.Aspect.Fluent.Components
{
/// <summary>
    ///     Base marker interface for all component interfaces in the fluent game entity system.
    ///     Components implementing this interface are auto-registered for AOT compilation compatibility.
    /// </summary>
    /// <remarks>
    ///     This is a marker-only interface with no members. Derived interfaces define lifecycle hooks
    ///     (e.g., <see cref="IOnUpdate"/>, <see cref="IOnDraw"/>, <see cref="IOnCollisionEnter"/>)
    ///     and behavior contracts for game entities.
    /// </remarks>
    /// <example>
    /// <code>
    /// // A typical component combines multiple marker interfaces:
    /// public struct HealthComponent : IComponentBase, IOnUpdate&lt;float&gt;
    /// {
    ///     public float Value;
    ///     public void Update(IGameObject self, ref float deltaTime) { ... }
    /// }
    /// </code>
    /// </example>
    public interface IComponentBase;
}