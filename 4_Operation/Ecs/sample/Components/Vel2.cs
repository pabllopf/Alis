
using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    record struct Vel2(float DX) : IComponent<Pos2>
    {
        /// <summary>
        /// Updates the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <param name="pos">The pos</param>
        public void Update(ref Pos2 pos)
        {
            pos.X += DX * 0.1f;
        }
    }
}