//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Decoration.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Ecs.Entity;

namespace Alis.Extension.Math.DungeonGenerator
{
    /// <summary>Decoration item of the game. </summary>
    [Serializable]
    public class Item
    {
        /// <summary>Gets or sets the prefab.</summary>
        /// <value>The prefab.</value>
        [JsonPropertyName("Prefab:")]
        public GameObject Prefab { get; set; }

        /// <summary>Gets or sets the box to spawn.</summary>
        /// <value>The box to spawn.</value>
        [JsonPropertyName("TypeCellBoxToSpawn:")]
        public CellBox TypeCellBoxToSpawn { get; set; } = CellBox.Floor;

        /// <summary>Gets or sets the minimum to spawn.</summary>
        /// <value>The minimum to spawn.</value>
        [JsonPropertyName("MinToSpawn:")]
        public int MinToSpawn { get; set; }

        /// <summary>Gets or sets the maximum to spawn.</summary>
        /// <value>The maximum to spawn.</value>
        [JsonPropertyName("MaxToSpawn:")]
        public int MaxToSpawn { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class
        /// </summary>
        public Item()
        {
            Prefab = null;
            TypeCellBoxToSpawn = CellBox.Floor;
            MinToSpawn = 0;
            MaxToSpawn = 0;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class
        /// </summary>
        /// <param name="prefab">The prefab</param>
        /// <param name="typeCellBoxToSpawn">The type cell box to spawn</param>
        /// <param name="minToSpawn">The min to spawn</param>
        /// <param name="maxToSpawn">The max to spawn</param>
        [JsonConstructor]
        public Item(GameObject prefab, CellBox typeCellBoxToSpawn, int minToSpawn, int maxToSpawn)
        {
            Prefab = prefab;
            TypeCellBoxToSpawn = typeCellBoxToSpawn;
            MinToSpawn = minToSpawn;
            MaxToSpawn = maxToSpawn;
        }
    }
}