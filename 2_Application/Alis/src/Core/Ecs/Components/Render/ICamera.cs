

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The camera interface
    /// </summary>
    /// <seealso cref="IOnInit" />
    /// <seealso cref="IOnUpdate" />
    public interface ICamera : IOnStart, IHasContext<Context>, IOnExit
    {
    }
}