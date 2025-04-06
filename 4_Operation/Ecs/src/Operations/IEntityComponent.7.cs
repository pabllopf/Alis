using System.ComponentModel;
using Alis.Core.Ecs.Comps;

namespace Alis.Core.Ecs.Operations
{
    public interface IEntityComponent<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update"/>
        void Update(Entity self, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5, ref TArg6 arg6, ref TArg7 arg7);
    }
}
