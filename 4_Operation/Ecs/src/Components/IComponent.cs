namespace Alis.Core.Ecs.Components
{
    /// <summary>
    /// Indicates a component should be updated with zero arguments
    /// </summary>
    /// <remarks>Components should only implement one "Update" method.</remarks>
    public partial interface IComponent : IComponentBase
    {
        /// <summary>
        /// Updates this component
        /// </summary>
        void Update();
    }
}