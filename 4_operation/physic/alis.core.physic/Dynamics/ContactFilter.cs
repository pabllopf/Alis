namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// Implement this class to provide collision filtering. In other words, you can implement
    /// this class if you want finer control over contact creation.
    /// </summary>
    public class ContactFilter
    {
        /// <summary>
        /// Return true if contact calculations should be performed between these two shapes.
        /// If you implement your own collision filter you may want to build from this implementation.
        /// @warning for performance reasons this is only called when the AABBs begin to overlap.
        /// </summary>
        public virtual bool ShouldCollide(Fixture fixtureA, Fixture fixtureB)
        {
            FilterData filterA = fixtureA.Filter;
            FilterData filterB = fixtureB.Filter;

            if (filterA.GroupIndex == filterB.GroupIndex && filterA.GroupIndex != 0)
            {
                return filterA.GroupIndex > 0;
            }

            bool collide = (filterA.MaskBits & filterB.CategoryBits) != 0 && (filterA.CategoryBits & filterB.MaskBits) != 0;
            return collide;
        }

        /// <summary>
        /// Return true if the given shape should be considered for ray intersection.
        /// </summary>
        public bool RayCollide(object userData, Fixture fixture)
        {
            //By default, cast userData as a shape, and then collide if the shapes would collide
            if (userData == null)
            {
                return true;
            }

            return ShouldCollide((Fixture)userData, fixture);
        }
    }
}