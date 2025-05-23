namespace Alis.Core.Ecs.Components
{
    /// <summary>
    ///     Marks a component to have a <see cref="Init(GameObject)" /> method to be called at the start of a component lifetime.
    /// </summary>
    public interface IInitable : IComponentBase
    {
        /// <summary>
        ///     This method is called whenever a component begins its lifetime, whether by any <see cref="GameObject.Add{T}(in T)" />
        ///     method or any <see cref="Scene.Create{T}(in T)" /> method (but not <see cref="Scene.CreateMany{T}(int)" />).
        /// </summary>
        /// <param name="self">The <see cref="GameObject" /> this component belongs to.</param>
        void Init(GameObject self);
    }
}