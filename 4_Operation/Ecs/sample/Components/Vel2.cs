

using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    ///     Represents the sample velocity component for initialized positions.
    /// </summary>
    internal record struct Vel2(float DX) : IOnUpdate<Pos2>
    {
        /// <summary>
        ///     Updates the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <param name="pos">The pos</param>
        public void Update(IGameObject self, ref Pos2 pos)
        {
            pos.X += DX * 0.1f;
        }
    }
}