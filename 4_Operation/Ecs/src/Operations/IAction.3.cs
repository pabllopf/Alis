

namespace Alis.Core.Ecs.Operations
{
    public interface IAction<TArg1, TArg2, TArg3>
    {
        void Run(ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3);
    }
}