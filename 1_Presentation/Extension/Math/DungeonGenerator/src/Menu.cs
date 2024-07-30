//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Menu.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------

using Alis.Core.Aspect.Data.Json;
using Alis.Core.Ecs.Entity;

namespace Alis.Extension.Math.DungeonGenerator
{
    /// <summary>
    /// The menu class
    /// </summary>
    [System.Serializable]
    public class Menu
    {
        /// <summary>The box to spawn</summary>
        [JsonPropertyName("TypeCellBoxToSpawn:")]
        private TypeCellBox typeCellBoxToSpawn = TypeCellBox.Floor;

        /// <summary>The minimum to spawn</summary>
        [JsonPropertyName("MinToSpawn:")]
        private int minToSpawn = 0;

        /// <summary>The maximum to spawn</summary>
        [JsonPropertyName("MaxToSpawn:")]
        private int maxToSpawn = 0;

        /// <summary>Gets or sets the prefab.</summary>
        /// <value>The prefab.</value>
        [JsonPropertyName("Prefab:")]
        public GameObject Prefab { get; set; }

        /// <summary>Gets or sets the box to spawn.</summary>
        /// <value>The box to spawn.</value>
        public TypeCellBox TypeCellBoxToSpawn { get => typeCellBoxToSpawn; set => typeCellBoxToSpawn = value; }

        /// <summary>Gets or sets the minimum to spawn.</summary>
        /// <value>The minimum to spawn.</value>
        public int MinToSpawn { get => minToSpawn; set => minToSpawn = value; }

        /// <summary>Gets or sets the maximum to spawn.</summary>
        /// <value>The maximum to spawn.</value>
        public int MaxToSpawn { get => maxToSpawn; set => maxToSpawn = value; }

    }
}