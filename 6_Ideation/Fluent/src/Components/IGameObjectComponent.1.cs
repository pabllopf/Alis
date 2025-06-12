namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Indicates a component should be updated with itself as an argument and the specified components
    /// </summary>
    /// <remarks>Components should only implement one "Update" method.</remarks>
    public partial interface IGameObjectComponent<TArg> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update" />
        void Update(IGameObject self, ref TArg arg);
    }
}


