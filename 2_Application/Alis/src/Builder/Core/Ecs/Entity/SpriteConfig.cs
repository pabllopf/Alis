using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Builder.Core.Ecs.Entity
{
    /// <summary>
    /// The sprite config
    /// </summary>
    public delegate void SpriteConfig<T>(SpriteBuilder builder) where T : ISprite;
}