using System;
using Alis.Core.Ecs.Sample.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The chunk with entity sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class ChunkWithEntitySample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "chunk-entities";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Chunk Enumeration By Index";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Processes paired chunk spans using index-based access.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(new Position(0, 0), new Velocity(1, 0));
            scene.Create(new Position(2, 2), new Velocity(0, 1));
            scene.Create(new Position(5, 5), new Velocity(-1, -1));

            foreach (ChunkTuple<Position, Velocity> chunk in scene.Query<With<Position>, With<Velocity>>().EnumerateChunks<Position, Velocity>())
            {
                for (int localIndex = 0; localIndex < chunk.Span1.Length; localIndex++)
                {
                    chunk.Span1[localIndex].X += chunk.Span2[localIndex].DX;
                    chunk.Span1[localIndex].Y += chunk.Span2[localIndex].DY;
                    Console.WriteLine($"Chunk item {localIndex + 1}: X={chunk.Span1[localIndex].X}, Y={chunk.Span1[localIndex].Y}");
                }
            }
        }
    }
}


