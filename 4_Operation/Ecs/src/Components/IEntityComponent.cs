
using static Frent.AttributeHelpers;

namespace Frent.Components;

/// <summary>
/// Indicates a component should be updated with itself as an argument
/// </summary>
public interface IEntityComponent : IComponentBase
{
    /// <inheritdoc cref="IComponent.Update"/>
    void Update(Entity self);
}

/// <summary>
/// Indicates a component should be updated with itself as an argument and the specified components
/// </summary>


public interface IEntityComponent<TArg> : IComponentBase
{
    /// <inheritdoc cref="IComponent.Update"/>
    void Update(Entity self, ref TArg arg);
}
