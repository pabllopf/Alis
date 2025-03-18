
using static Frent.AttributeHelpers;

namespace Frent.Components;

/// <summary>
/// Indicates a component should be updated with zero arguments
/// </summary>
public interface IComponent : IComponentBase
{
    /// <summary>
    /// Updates this component
    /// </summary>
    void Update();
}

/// <summary>
/// Indicates a component should be updated with the specified components
/// </summary>
public interface IComponent<TArg> : IComponentBase
{
    /// <inheritdoc cref="IComponent.Update"/>
    void Update(ref TArg arg);
}