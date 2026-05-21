

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     The box collider interface
    /// </summary>
    public interface IBoxCollider : IOnStart, IOnUpdate, IHasContext<Context>, IOnExit
    {
    }
}