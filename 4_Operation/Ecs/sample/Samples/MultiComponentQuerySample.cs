using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Sample.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The multi component query sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class MultiComponentQuerySample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "multi-query";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Multi-Component Query";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Queries Position + Velocity at once and writes updated positions.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(new Position(0, 0), new Velocity(1, 1));
            scene.Create(new Position(10, 5), new Velocity(-1, 2));
            scene.Create(new Position(4, 8));

            foreach (RefTuple<Position, Velocity> tuple in scene.Query<With<Position>, With<Velocity>>().Enumerate<Position, Velocity>())
            {
                Ref<Position> position = tuple.Item1;
                Ref<Velocity> velocity = tuple.Item2;
                position.Value.X += velocity.Value.DX;
                position.Value.Y += velocity.Value.DY;
            }

            Console.WriteLine("Positions after query-based movement:");
            int index = 1;
            foreach (RefTuple<Position> tuple in scene.Query<With<Position>>().Enumerate<Position>())
            {
                Ref<Position> position = tuple.Item1;
                Console.WriteLine($"Entity {index++}: X={position.Value.X}, Y={position.Value.Y}");
            }
        }
    }
}

