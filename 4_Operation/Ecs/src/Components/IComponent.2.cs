namespace Alis.Core.Ecs.Components
{
    /// <summary>
    ///     The component interface
    /// </summary>
    /// <seealso cref="IComponentBase" />
    public partial interface IComponent<TArg1, TArg2> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update" />
        void Update(ref TArg1 arg1, ref TArg2 arg2);
    }
}