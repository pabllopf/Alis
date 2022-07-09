namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// This is called when a body's shape passes outside of the world boundary.
    /// </summary>
    public abstract class BoundaryListener
    {
        /// <summary>
        /// This is called for each body that leaves the world boundary.
        /// @warning you can't modify the world inside this callback.
        /// </summary>
        public abstract void Violation(Body body);
    }
}