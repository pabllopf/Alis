using System;
using Alis.Core.Ecs.Sample.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class ChunkEnumerationSample : IEcsSample
    {
        public string Key => "chunk-query";

        public string Title => "Chunk Enumeration";

        public string Description => "Updates component data in chunks using EnumerateChunks.";

        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(new Position(0, 0), new Velocity(1, 2));
            scene.Create(new Position(3, 4), new Velocity(2, 3));
            scene.Create(new Position(8, 9), new Velocity(-1, 1));

            foreach (ChunkTuple<Position, Velocity> chunk in scene.Query<With<Position>, With<Velocity>>().EnumerateChunks<Position, Velocity>())
            {
                Span<Position> positions = chunk.Span1;
                Span<Velocity> velocities = chunk.Span2;

                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i].X += velocities[i].DX;
                    positions[i].Y += velocities[i].DY;
                }
            }

            Console.WriteLine("Positions after chunk update:");
            foreach (RefTuple<Position> tuple in scene.Query<With<Position>>().Enumerate<Position>())
            {
                Console.WriteLine($"X={tuple.Item1.Value.X}, Y={tuple.Item1.Value.Y}");
            }
        }
    }
}

