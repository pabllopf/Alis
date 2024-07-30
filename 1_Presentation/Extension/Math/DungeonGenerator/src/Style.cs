//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Style.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Ecs.Entity;

namespace Alis.Extension.Math.DungeonGenerator
{
    /// <summary>Define a style of a dungeon.</summary>
    [Serializable]
    public class Style
    {
        /// <summary>
        /// The empty
        /// </summary>
        [JsonPropertyName("Name:")]
        private string nameStyle = string.Empty;

        /// <summary>
        /// The game object
        /// </summary>
        [JsonPropertyName("Floors:")]
        private List<GameObject> floors = new List<GameObject>();

        /// <summary>
        /// The game object
        /// </summary>
        [JsonPropertyName("Walls:")]
        private List<GameObject> wallsDown = new List<GameObject>();
        
        /// <summary>
        /// The game object
        /// </summary>
        private List<GameObject> wallsLeft = new List<GameObject>();
        
        /// <summary>
        /// The game object
        /// </summary>
        private List<GameObject> wallsRight = new List<GameObject>();
        
        /// <summary>
        /// The game object
        /// </summary>
        private List<GameObject> wallsTop = new List<GameObject>();

        /// <summary>
        /// The game object
        /// </summary>
        [JsonPropertyName("Corners:")]
        private List<GameObject> cornersLeftDown = new List<GameObject>();
        
        /// <summary>
        /// The game object
        /// </summary>
        private List<GameObject> cornersRightDown = new List<GameObject>();

        /// <summary>
        /// The game object
        /// </summary>
        private List<GameObject> cornersLeftUp = new List<GameObject>();
        
        /// <summary>
        /// The game object
        /// </summary>
        private List<GameObject> cornersRightUp = new List<GameObject>();

        /// <summary>
        /// The game object
        /// </summary>
        [JsonPropertyName("Internal Corners:")]
        private List<GameObject> cornersInternalLeftDown = new List<GameObject>();
        
        /// <summary>
        /// The game object
        /// </summary>
        private List<GameObject> cornersInternalLeftUp = new List<GameObject>();
        
        /// <summary>
        /// The game object
        /// </summary>
        private List<GameObject> cornersInternalRightDown = new List<GameObject>();
        
        /// <summary>
        /// The game object
        /// </summary>
        private List<GameObject> cornersInternalRightUp = new List<GameObject>();

        /// <summary>
        /// The menu
        /// </summary>
        [JsonPropertyName("Enemy")]
        private List<Menu> enemys = new List<Menu>();

        /// <summary>
        /// The menu
        /// </summary>
        [JsonPropertyName("Decoration")]
        private List<Menu> decorations = new List<Menu>();
        
        /// <summary>Gets or sets the name style.</summary>
        /// <value>The name style.</value>
        public string NameStyle { get => nameStyle; set => nameStyle = value; }
        
        /// <summary>Gets or sets the floors.</summary>
        /// <value>The floors.</value>
        public List<GameObject> Floors { get => floors; set => floors = value; }
        
        /// <summary>Gets or sets the walls down.</summary>
        /// <value>The walls down.</value>
        public List<GameObject> WallsDown { get => wallsDown; set => wallsDown = value; }
        
        /// <summary>Gets or sets the walls left.</summary>
        /// <value>The walls left.</value>
        public List<GameObject> WallsLeft { get => wallsLeft; set => wallsLeft = value; }
        
        /// <summary>Gets or sets the walls right.</summary>
        /// <value>The walls right.</value>
        public List<GameObject> WallsRight { get => wallsRight; set => wallsRight = value; }
        
        /// <summary>Gets or sets the walls top.</summary>
        /// <value>The walls top.</value>
        public List<GameObject> WallsTop { get => wallsTop; set => wallsTop = value; }
        
        /// <summary>Gets or sets the corners left down.</summary>
        /// <value>The corners left down.</value>
        public List<GameObject> CornersLeftDown { get => cornersLeftDown; set => cornersLeftDown = value; }
        
        /// <summary>Gets or sets the corners right down.</summary>
        /// <value>The corners right down.</value>
        public List<GameObject> CornersRightDown { get => cornersRightDown; set => cornersRightDown = value; }
        
        /// <summary>Gets or sets the corners left up.</summary>
        /// <value>The corners left up.</value>
        public List<GameObject> CornersLeftUp { get => cornersLeftUp; set => cornersLeftUp = value; }
        
        /// <summary>Gets or sets the corners right up.</summary>
        /// <value>The corners right up.</value>
        public List<GameObject> CornersRightUp { get => cornersRightUp; set => cornersRightUp = value; }
       
        /// <summary>Gets or sets the corners internal left down.</summary>
        /// <value>The corners internal left down.</value>
        public List<GameObject> CornersInternalLeftDown { get => cornersInternalLeftDown; set => cornersInternalLeftDown = value; }
        
        /// <summary>Gets or sets the corners internal left up.</summary>
        /// <value>The corners internal left up.</value>
        public List<GameObject> CornersInternalLeftUp { get => cornersInternalLeftUp; set => cornersInternalLeftUp = value; }
        
        /// <summary>Gets or sets the corners internal right down.</summary>
        /// <value>The corners internal right down.</value>
        public List<GameObject> CornersInternalRightDown { get => cornersInternalRightDown; set => cornersInternalRightDown = value; }
        
        /// <summary>Gets or sets the corners internal right up.</summary>
        /// <value>The corners internal right up.</value>
        public List<GameObject> CornersInternalRightUp { get => cornersInternalRightUp; set => cornersInternalRightUp = value; }

        /// <summary>Gets or sets the enemys.</summary>
        /// <value>The enemys.</value>
        public List<Menu> Enemys { get => enemys; set => enemys = value; }

        /// <summary>Gets or sets the decorations.</summary>
        /// <value>The decorations.</value>
        public List<Menu> Decorations { get => decorations; set => decorations = value; }
        
        /// <summary>Gets the tile.</summary>
        /// <param name="tileTypeCellBox">The tile box.</param>
        /// <returns>Return the texture.</returns>
        public GameObject GetTile(TypeCellBox tileTypeCellBox)
        {
            return RandomGameObject(
                tileTypeCellBox.Equals(TypeCellBox.WallDown) ? WallsDown :
                tileTypeCellBox.Equals(TypeCellBox.WallLeft) ? WallsLeft :
                tileTypeCellBox.Equals(TypeCellBox.WallRight) ? WallsRight :
                tileTypeCellBox.Equals(TypeCellBox.WallTop) ? WallsTop :
                tileTypeCellBox.Equals(TypeCellBox.CornerLeftUp) ? CornersLeftUp :
                tileTypeCellBox.Equals(TypeCellBox.CornerRightUp) ? CornersRightUp :
                tileTypeCellBox.Equals(TypeCellBox.CornerLeftDown) ? CornersLeftDown :
                tileTypeCellBox.Equals(TypeCellBox.CornerRightDown) ? CornersRightDown :
                tileTypeCellBox.Equals(TypeCellBox.CornerInternalLeftDown) ? CornersInternalLeftDown :
                tileTypeCellBox.Equals(TypeCellBox.CornerInternalLeftUp) ? CornersInternalLeftUp :
                tileTypeCellBox.Equals(TypeCellBox.CornerInternalRightDown) ? CornersInternalRightDown :
                tileTypeCellBox.Equals(TypeCellBox.CornerInternalRightUp) ? CornersInternalRightUp :
                Floors);
        }

        /// <summary>Random the game object.</summary>
        /// <param name="gameObjects">The game objects.</param>
        /// <returns>A game object.</returns>
        private GameObject RandomGameObject(List<GameObject> gameObjects) 
        {
            return gameObjects[new Random().Next(0, gameObjects.Count - 1)];
        }
    }
}