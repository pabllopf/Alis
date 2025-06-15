namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     The gameObject component interface
    /// </summary>
    /// <seealso cref="IComponentBase" />
    public partial interface
        IGameObjectComponent<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update" />
        void Update(IGameObject self, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5,
            ref TArg6 arg6, ref TArg7 arg7, ref TArg8 arg8, ref TArg9 arg9, ref TArg10 arg10);
    }
}