using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Builder.Core.Ecs.Entity
{
    public delegate void SpriteConfig<T>(SpriteBuilder builder) where T : ISprite;
}