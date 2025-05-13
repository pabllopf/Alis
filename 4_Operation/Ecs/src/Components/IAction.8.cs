namespace Alis.Core.Ecs.Components;
    public interface IAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    {
        /// Executes the function
        void Run(ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5, ref TArg6 arg6, ref TArg7 arg7, ref TArg8 arg8);
    }
