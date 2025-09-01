namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Marks a component to have a <see cref="Destroy" /> method to be called at the end of a component lifetime.
    /// </summary>
    public interface IDestroyable : IComponentBase
    {
        void Destroy();
    }
}