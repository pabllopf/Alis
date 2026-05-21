

using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    ///     The velocity
    /// </summary>
    internal struct Velocity(int dx, int dy) : IOnUpdate<Position>
    {
        /// <summary>
        ///     The dx
        /// </summary>
        public int DX = dx;

        /// <summary>
        ///     The dy
        /// </summary>
        public int DY = dy;

        /// <summary>
        ///     Updates the pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void Update(IGameObject self, ref Position pos)
        {
            pos.X += DX;
            pos.Y += DY;
        }
    }
}