

using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Builder.Core.Ecs.Entity
{
    /// <summary>
    ///     The animator config
    /// </summary>
    public delegate void AnimatorConfig<T>(AnimatorBuilder builder) where T : IAnimator;
}