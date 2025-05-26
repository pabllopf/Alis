namespace Alis.Core.Ecs.Components
{
    /// <summary>
    ///     Indicates a component should be updated with the specified components
    /// </summary>
    /// <remarks>Components should only implement one "Update" method.</remarks>
    public partial interface IComponent<TArg> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update" />
        void Update(ref TArg arg);
    }
}