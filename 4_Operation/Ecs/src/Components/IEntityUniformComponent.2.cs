




using Alis.Variadic.Generator;
using static Alis.Core.Ecs.AttributeHelpers;

namespace Alis.Core.Ecs.Components;
    public partial interface IEntityUniformComponent<TUniform, TArg1, TArg2> : IComponentBase
    {
        /// <inheritdoc cref="IComponent.Update"/>
        public void Update(Entity self, TUniform uniform, ref TArg1 arg1, ref TArg2 arg2);
    }
