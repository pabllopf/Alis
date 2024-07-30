//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Hostile.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Ecs.Entity;

namespace Alis.Extension.Math.DungeonGenerator
{
    /// <summary>Hostile enemy of dungeon. </summary>
    [Serializable]
    public class Hostile
    {
        /// <summary>Gets or sets the prefab.</summary>
        /// <value>The prefab.</value>
        [JsonPropertyName("Prefab:")]
        public GameObject Prefab { get; set; }

        /// <summary>Gets or sets the box to spawn.</summary>
        /// <value>The box to spawn.</value>
        [JsonPropertyName("TypeCellBoxToSpawn:")]
        public TypeCellBox TypeCellBoxToSpawn { get; set; } = TypeCellBox.Floor;

        /// <summary>Gets or sets the minimum to spawn.</summary>
        /// <value>The minimum to spawn.</value>
        [JsonPropertyName("MinToSpawn:")]
        public int MinToSpawn  { get; set; } = 0;

        /// <summary>Gets or sets the maximum to spawn.</summary>
        /// <value>The maximum to spawn.</value>
        [JsonPropertyName("MaxToSpawn:")]
        public int MaxToSpawn  { get; set; } = 0;
    }
}