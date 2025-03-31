using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.System.Configuration.Physic
{
    [SkipLocalsInit]
    public record struct PhysicSetting(
        bool DebugMode = false,
        Color DebugColor = default(Color),
        Vector2F Gravity = default(Vector2F)): 
        IPhysicSetting;
}