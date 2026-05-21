

using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    ///     Represents the sample velocity component.
    /// </summary>
    internal record struct Vel(float DX) : IOnUpdate<Pos>
    {
        /// <summary>
        ///     Updates the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <param name="pos">The pos</param>
        public void Update(IGameObject self, ref Pos pos)
        {
            pos.X += DX * 0.1f;
        }
    }
}