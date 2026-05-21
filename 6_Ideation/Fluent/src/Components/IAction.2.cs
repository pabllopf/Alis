

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Defines a fluent action delegate that operates on 2 arguments
    ///     of types TArg1, TArg2.
    /// </summary>
    /// <typeparam name="TArg1">The type of the 1st argument passed to the action.</typeparam>
    /// <typeparam name="TArg2">The type of the 2nd argument passed to the action.</typeparam>
    public partial interface IAction<TArg1, TArg2>
    {
        /// <summary>
        ///     Executes the action with the provided 2 arguments, passed by reference.
        /// </summary>
        /// <param name="arg1">The 1st action argument of type <typeparamref name="TArg1"/>, passed by reference so the action can mutate it.</param>
        /// <param name="arg2">The 2nd action argument of type <typeparamref name="TArg2"/>, passed by reference so the action can mutate it.</param>
        void Run(ref TArg1 arg1, ref TArg2 arg2);
    }
}