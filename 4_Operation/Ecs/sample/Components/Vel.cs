
using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    record struct Vel(float DX) : IUniformComponent<float, Pos>
    {
        public void Update(float dt, ref Pos pos)
        {
            pos.X += DX * dt;
        }
    }
}