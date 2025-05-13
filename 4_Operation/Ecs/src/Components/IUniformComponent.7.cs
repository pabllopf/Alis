




using Alis.Variadic.Generator;
using static Alis.Core.Ecs.AttributeHelpers;

namespace Alis.Core.Ecs.Components;
    public partial interface IUniformComponent<TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update"/>
        void Update(TUniform uniform, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5, ref TArg6 arg6, ref TArg7 arg7);
    }
