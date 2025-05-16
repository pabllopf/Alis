
using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    struct Velocity(int dx, int dy) : IComponent<Position>
    {
        public int DX = dx;
        public int DY = dy;
        public void Update(ref Position pos)
        {
            pos.X += DX;
            pos.Y += DY;
        }
    }
}