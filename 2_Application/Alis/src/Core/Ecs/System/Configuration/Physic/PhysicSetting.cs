using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.System.Configuration.Physic
{
    
    public record struct PhysicSetting(
        Vector2F Gravity = default(Vector2F)): 
        IPhysicSetting;
}