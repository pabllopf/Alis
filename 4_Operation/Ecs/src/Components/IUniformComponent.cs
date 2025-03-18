﻿
using static Frent.AttributeHelpers;

namespace Frent.Components;

/// <summary>
/// Indicates a component should be updated with a uniform of type <typeparamref name="TUniform"/>
/// </summary>
public interface IUniformComponent<TUniform> : IComponentBase
{
    /// <inheritdoc cref="IComponent.Update"/>
    void Update(TUniform uniform);
}

/// <summary>
/// Indicates a component should be updated with a uniform of type <typeparamref name="TUniform"/> and the specified components
/// </summary>


public interface IUniformComponent<TUniform, TArg> : IComponentBase
{
    /// <inheritdoc cref="IComponent.Update"/>
    void Update(TUniform uniform, ref TArg arg);
}