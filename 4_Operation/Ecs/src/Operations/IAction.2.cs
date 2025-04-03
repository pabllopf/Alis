

namespace Alis.Core.Ecs.Operations
{
    public interface IAction<TArg1, TArg2>
    {
        
        void Run(ref TArg1 arg1, ref TArg2 arg2);
    }
}