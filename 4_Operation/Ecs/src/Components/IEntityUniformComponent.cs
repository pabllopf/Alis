﻿
namespace Alis.Core.Ecs.Components
{
    /// <summary>
    /// Indicates a component should be updated with itself as an argument and a uniform of type <typeparamref name="TUniform"/>
    /// </summary>
    public interface IEntityUniformComponent<TUniform> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update"/>
        public void Update(Entity self, TUniform uniform);
    }

    /// <summary>
    /// Indicates a component should be updated with itself as an argument and a uniform of type <typeparamref name="TUniform"/>, along with the specified components
    /// </summary>


    public interface IEntityUniformComponent<TUniform, TArg> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update"/>
        public void Update(Entity self, TUniform uniform, ref TArg arg);
    }
}