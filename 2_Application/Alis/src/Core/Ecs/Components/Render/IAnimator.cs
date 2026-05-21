

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The animator interface
    /// </summary>
    /// <seealso cref="IOnInit" />
    /// <seealso cref="IOnUpdate" />
    public interface IAnimator :
        IOnStart,
        IOnUpdate,
        IHasContext<Context>,
        IOnExit
    {
    }
}