namespace Alis.Core.Ecs.Components
{
    /// <summary>
    ///     Indicates a component should be updated with itself as an argument
    /// </summary>
    /// <remarks>Components should only implement one "Update" method.</remarks>
    public partial interface IGameObjectComponent : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update" />
        void Update(GameObject self);
    }
}