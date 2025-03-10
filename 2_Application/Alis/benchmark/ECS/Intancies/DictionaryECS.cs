using System.Collections.Generic;

namespace Alis.Benchmark.ECS.Intancies
{
    /// <summary>
    /// The dictionary ecs class
    /// </summary>
    public class DictionaryEcs
    {
        /// <summary>
        /// The positions
        /// </summary>
        private Dictionary<int, Position> positions =  new Dictionary<int, Position>();
        /// <summary>
        /// The id counter
        /// </summary>
        private int idCounter = 0;

        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <returns>The id</returns>
        public int CreateEntity()
        {
            int id = idCounter++;
            positions[id] = new Position { X = id, Y = id };
            return id;
        }

        /// <summary>
        /// Updates the entities
        /// </summary>
        public void UpdateEntities()
        {
            foreach (int key in positions.Keys)
            {
                positions[key] = new Position { X = positions[key].X + 1, Y = positions[key].Y + 1 };
            }
        }
    }
}