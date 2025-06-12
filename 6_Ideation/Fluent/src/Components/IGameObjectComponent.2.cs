namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     The gameObject component interface
    /// </summary>
    /// <seealso cref="IComponentBase" />
    public partial interface IGameObjectComponent<TArg1, TArg2> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update" />
        void Update(IGameObject self, ref TArg1 arg1, ref TArg2 arg2);
    }
}