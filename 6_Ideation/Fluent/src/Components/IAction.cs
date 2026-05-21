

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Defines a fluent action delegate that operates on 1 argument
    ///     of type <typeparamref name="TArg1"/>.
    /// </summary>
    /// <remarks>
    ///     Partial interface — implementations may provide overloads for multiple
    ///     argument counts to support flexible action signatures.
    /// </remarks>
    /// <typeparam name="TArg1">The type of the 1st argument passed to the action.</typeparam>
    public partial interface IAction<TArg1>
    {
        /// <summary>
        ///     Executes the action with the provided 1 argument, passed by reference.
        /// </summary>
        /// <param name="arg1">The 1st action argument of type <typeparamref name="TArg1"/>, passed by reference so the action can mutate it.</param>
        void Run(ref TArg1 arg1);
    }
}