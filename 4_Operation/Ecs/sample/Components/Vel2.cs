
using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    record struct Vel2(float DX) : IUniformComponent<float, Pos2>
    {
        public void Update(float dt, ref Pos2 pos)
        {
            pos.X += DX * dt;
        }
    }
}