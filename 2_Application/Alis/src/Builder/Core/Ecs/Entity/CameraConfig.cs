using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Builder.Core.Ecs.Entity
{
    public delegate void CameraConfig<T>(CameraBuilder builder) where T : ICamera;
}