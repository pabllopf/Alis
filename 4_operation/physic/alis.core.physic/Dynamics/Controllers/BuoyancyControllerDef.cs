using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    /// This class is used to build buoyancy controllers
    /// </summary>
    public class BuoyancyControllerDef
    {
        /// The outer surface normal
        public Vec2 Normal;
        /// The height of the fluid surface along the normal
        public float Offset;
        /// The fluid density
        public float Density;
        /// Fluid velocity, for drag calculations
        public Vec2 Velocity;
        /// Linear drag co-efficient
        public float LinearDrag;
        /// Linear drag co-efficient
        public float AngularDrag;
        /// If false, bodies are assumed to be uniformly dense, otherwise use the shapes densities
        public bool UseDensity; //False by default to prevent a gotcha
        /// If true, gravity is taken from the world instead of the gravity parameter.
        public bool UseWorldGravity;
        /// Gravity vector, if the world's gravity is not used
        public Vec2 Gravity;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuoyancyControllerDef"/> class
        /// </summary>
        public BuoyancyControllerDef()
        {
            Normal = new Vec2(0, 1);
            Offset = 0;
            Density = 0;
            Velocity = new Vec2(0, 0);
            LinearDrag = 0;
            AngularDrag = 0;
            UseDensity = false;
            UseWorldGravity = true;
            Gravity = new Vec2(0, 0);
        }
    }
}