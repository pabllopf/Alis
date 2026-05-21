

using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.Logic
{
    /// <summary>
    ///     The physics logic class
    /// </summary>
    /// <seealso cref="FilterData" />
    public abstract class PhysicsLogic : FilterData
    {
        /// <summary>
        ///     The cat 01
        /// </summary>
        public readonly ControllerCategory ControllerCategory = ControllerCategory.Cat01;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicsLogic" /> class
        /// </summary>
        /// <param name="worldPhysic">The world</param>
        public PhysicsLogic(WorldPhysic worldPhysic) => WorldPhysic = worldPhysic;

        /// <summary>
        ///     Gets or sets the value of the world
        /// </summary>
        public WorldPhysic WorldPhysic { get; internal set; }

        /// <summary>
        ///     Describes whether this instance is active on
        /// </summary>
        /// <param name="body">The body</param>
        /// <returns>The bool</returns>
        public override bool IsActiveOn(Body body)
        {
            if (body.ControllerFilter.IsControllerIgnored(ControllerCategory))
            {
                return false;
            }

            return base.IsActiveOn(body);
        }
    }
}