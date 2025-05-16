namespace Alis.Core.Ecs.Components;
    public interface IAction<TArg1, TArg2>
    {
        /// Executes the function
        void Run(ref TArg1 arg1, ref TArg2 arg2);
    }
