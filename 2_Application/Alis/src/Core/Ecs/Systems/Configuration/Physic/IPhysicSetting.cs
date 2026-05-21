

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.Systems.Configuration.Physic
{
    /// <summary>
    ///     The physic setting interface
    /// </summary>
    public interface IPhysicSetting
    {
        /// <summary>
        ///     Gets or sets the gravity.
        /// </summary>
        /// <value>The gravity.</value>
        Vector2F Gravity { get; set; }
    }
}