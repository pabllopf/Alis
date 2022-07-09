using Alis.Core.Physic.Collision.Shapes;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// A fixture definition is used to create a fixture. This class defines an
    /// abstract fixture definition. You can reuse fixture definitions safely.
    /// </summary>
    public class FixtureDef
    {
        /// <summary>
        /// The constructor sets the default fixture definition values.
        /// </summary>	
        public FixtureDef()
        {
            Type = ShapeType.UnknownShape;
            UserData = null;
            Friction = 0.2f;
            Restitution = 0.0f;
            Density = 0.0f;
            Filter.CategoryBits = 0x0001;
            Filter.MaskBits = 0xFFFF;
            Filter.GroupIndex = 0;
            IsSensor = false;
        }

        /// <summary>
        /// Holds the shape type for down-casting.
        /// </summary>
        public ShapeType Type;

        /// <summary>
        /// Use this to store application specific fixture data.
        /// </summary>
        public object UserData;

        /// <summary>
        /// The friction coefficient, usually in the range [0,1].
        /// </summary>
        public float Friction;

        /// <summary>
        /// The restitution (elasticity) usually in the range [0,1].
        /// </summary>
        public float Restitution;

        /// <summary>
        /// The density, usually in kg/m^2.
        /// </summary>
        public float Density;

        /// <summary>
        /// A sensor shape collects contact information but never generates a collision response.
        /// </summary>
        public bool IsSensor;

        /// <summary>
        /// Contact filtering data.
        /// </summary>
        public FilterData Filter;
    }
}