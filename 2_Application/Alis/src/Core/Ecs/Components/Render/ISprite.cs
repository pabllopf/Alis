

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The sprite interface
    /// </summary>
    /// <seealso cref="IOnInit" />
    /// <seealso cref="IOnUpdate" />
    /// <seealso cref="IHasBuilder{SpriteBuilder}" />
    /// <seealso cref="IBuild{Sprite}" />
    public interface ISprite :
        IOnStart,
        IOnUpdate,
        IHasContext<Context>,
        IOnExit
    {
    }
}