namespace Alis.Core.Ecs.Components
{
    /// <summary>
    /// Indicates a component should be updated with a uniform of type <typeparamref name="TUniform"/>
    /// </summary>
    /// <remarks>Components should only implement one "Update" method.</remarks>
    public partial interface IUniformComponent<TUniform> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update"/>
        void Update(TUniform uniform);
    }

    /// <summary>
    /// Indicates a component should be updated with a uniform of type <typeparamref name="TUniform"/> and the specified components
    /// </summary>
    /// <remarks>Components should only implement one "Update" method.</remarks>
    
    
    public partial interface IUniformComponent<TUniform, TArg> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update"/>
        void Update(TUniform uniform, ref TArg arg);
    }
}