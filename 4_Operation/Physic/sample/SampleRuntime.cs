using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample
{
    internal sealed class SampleRuntime
    {
        public const float FixedDeltaTime = 1.0f / 60.0f;

        public WorldPhysic CreateWorld(Vector2F gravity)
        {
            WorldPhysic world = new WorldPhysic(gravity);
            return world;
        }

        public void AddGround(WorldPhysic world, float y = -10.0f, float width = 80.0f, float height = 1.0f)
        {
            world.CreateRectangle(width, height, 0.0f, new Vector2F(0.0f, y), 0.0f, BodyType.Static);
        }

        public void StepWorld(WorldPhysic world, int steps, Action<int> perStep = null)
        {
            for (int i = 0; i < steps; i++)
            {
                world.Step(FixedDeltaTime);
                if (perStep != null)
                {
                    perStep(i + 1);
                }
            }
        }

        public void PrintBodyState(string label, Body body)
        {
            Console.WriteLine(
                "{0}: pos=({1:F2}, {2:F2}) vel=({3:F2}, {4:F2}) angle={5:F2}",
                label,
                body.Position.X,
                body.Position.Y,
                body.LinearVelocity.X,
                body.LinearVelocity.Y,
                body.Rotation);
        }

        public void PrintSeparator()
        {
            Console.WriteLine(new string('-', 72));
        }
    }
}

