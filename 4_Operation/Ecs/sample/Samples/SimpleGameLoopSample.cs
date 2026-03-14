using System;
using System.Threading;
using Alis.Core.Ecs.Sample.Components;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The simple game loop sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class SimpleGameLoopSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "simple-game";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Simple Game Loop";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Runs a tiny update loop with Position and Velocity components.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            GameObject player = scene.Create(new Position(4, 2), new Velocity(1, 0));

            for (int frame = 0; frame < 10; frame++)
            {
                scene.Update();
                Position framePosition = player.Get<Position>();
                Console.WriteLine($"Frame {frame + 1}: X={framePosition.X}, Y={framePosition.Y}");
                Thread.Sleep(40);
            }

            Position finalPosition = player.Get<Position>();
            Console.WriteLine($"Final player position: X={finalPosition.X}, Y={finalPosition.Y}");
        }
    }
}

