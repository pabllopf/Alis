




using Alis.Variadic.Generator;
using static Alis.Core.Ecs.AttributeHelpers;

namespace Alis.Core.Ecs.Components;
    public partial interface IEntityUniformComponent<TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update"/>
        public void Update(Entity self, TUniform uniform, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5, ref TArg6 arg6, ref TArg7 arg7, ref TArg8 arg8);
    }
