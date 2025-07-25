namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     The action interface
    /// </summary>
    public interface IAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13,
        TArg14, TArg15>
    {
        /// Executes the function
        void Run(ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5, ref TArg6 arg6,
            ref TArg7 arg7, ref TArg8 arg8, ref TArg9 arg9, ref TArg10 arg10, ref TArg11 arg11, ref TArg12 arg12,
            ref TArg13 arg13, ref TArg14 arg14, ref TArg15 arg15);
    }
}