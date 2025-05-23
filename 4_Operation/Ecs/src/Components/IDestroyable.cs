namespace Alis.Core.Ecs.Components
{
    /// <summary>
    ///     Marks a component to have a <see cref="Destroy" /> method to be called at the end of a component lifetime.
    /// </summary>
    public interface IDestroyable : IComponentBase
    {
        /// <summary>
        ///     This method is called whenever a component reaches the end of its lifetime, whether by an
        ///     <see cref="GameObject.Remove{T}()" /> method or <see cref="GameObject.Delete" />.
        /// </summary>
        void Destroy();
    }
}