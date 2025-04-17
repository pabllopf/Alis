using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Builder.Core.Ecs.Entity
{
    /// <summary>
    /// The camera config
    /// </summary>
    public delegate void CameraConfig<T>(CameraBuilder builder) where T : ICamera;
}