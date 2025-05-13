




using Alis.Variadic.Generator;
using static Alis.Core.Ecs.AttributeHelpers;

namespace Alis.Core.Ecs.Components;
    public partial interface IEntityComponent<TArg1, TArg2, TArg3> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update"/>
        void Update(Entity self, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3);
    }
