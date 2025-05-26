
using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    record struct Vel(float DX) : IComponent<Pos>
    {
        /// <summary>
        /// Updates the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <param name="pos">The pos</param>
        public void Update(ref Pos pos)
        {
            pos.X += DX * 0.1f;
        }
    }
}