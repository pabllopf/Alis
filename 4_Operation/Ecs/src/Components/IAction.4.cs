namespace Alis.Core.Ecs.Components;
    public interface IAction<TArg1, TArg2, TArg3, TArg4>
    {
        /// Executes the function
        void Run(ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4);
    }
