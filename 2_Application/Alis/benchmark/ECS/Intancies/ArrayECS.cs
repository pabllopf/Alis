namespace Alis.Benchmark.ECS.Intancies
{
    /// <summary>
    /// The array ecs class
    /// </summary>
    public class ArrayEcs
    {
        /// <summary>
        /// The positions
        /// </summary>
        private Position[] positions;
        /// <summary>
        /// The count
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayEcs"/> class
        /// </summary>
        /// <param name="size">The size</param>
        public ArrayEcs(int size)
        {
            positions = new Position[size];
        }

        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <returns>The int</returns>
        public int CreateEntity()
        {
            positions[count] = new Position { X = count, Y = count };
            return count++;
        }

        /// <summary>
        /// Updates the entities
        /// </summary>
        public void UpdateEntities()
        {
            for (int i = 0; i < count; i++)
            {
                positions[i].X += 1;
                positions[i].Y += 1;
            }
        }
    }
}