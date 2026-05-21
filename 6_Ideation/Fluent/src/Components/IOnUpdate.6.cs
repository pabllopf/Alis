

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook invoked each frame during the update loop, providing the owning entity and
    ///     6 additional component references of types <typeparamref name="TArg1"/>, <typeparamref name="TArg2"/>, <typeparamref name="TArg3"/>, <typeparamref name="TArg4"/>, <typeparamref name="TArg5"/>, and <typeparamref name="TArg6"/>.
    /// </summary>
    /// <typeparam name="TArg1">The type of the 1st additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg2">The type of the 2nd additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg3">The type of the 3rd additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg4">The type of the 4th additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg5">The type of the 5th additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg6">The type of the 6th additional component or data argument passed to the update method.</typeparam>
    /// <seealso cref="IComponentBase" />
    public partial interface IOnUpdate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : IComponentBase
    {
        /// <summary>
        ///     Invokes the update logic with the owning entity and 6 component references.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        /// <param name="arg1">The 1st additional component reference of type <typeparamref name="TArg1"/>.</param>
        /// <param name="arg2">The 2nd additional component reference of type <typeparamref name="TArg2"/>.</param>
        /// <param name="arg3">The 3rd additional component reference of type <typeparamref name="TArg3"/>.</param>
        /// <param name="arg4">The 4th additional component reference of type <typeparamref name="TArg4"/>.</param>
        /// <param name="arg5">The 5th additional component reference of type <typeparamref name="TArg5"/>.</param>
        /// <param name="arg6">The 6th additional component reference of type <typeparamref name="TArg6"/>.</param>
        void Update(IGameObject self, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5,
            ref TArg6 arg6);
    }
}
