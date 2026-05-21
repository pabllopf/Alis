

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Math.ProceduralDungeon.Models
{
    /// <summary>
    ///     Represents the complete data structure for a generated dungeon.
    ///     Contains all the information about the dungeon including board, rooms, and corridors.
    /// </summary>
    [Serializable]
    public partial class DungeonData : IJsonSerializable, IJsonDesSerializable<DungeonData>
    {
        /// <summary>
        ///     The backing field for <see cref="Board" />.
        /// </summary>
        private BoardSquare[,] _board;

        /// <summary>
        ///     The backing field for <see cref="Rooms" />.
        /// </summary>
        private List<RoomData> _rooms;

        /// <summary>
        ///     The backing field for <see cref="Corridors" />.
        /// </summary>
        private List<CorridorData> _corridors;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonData" /> class.
        ///     Default constructor for serialization support.
        /// </summary>
        public DungeonData()
        {
            _board = new BoardSquare[0, 0];
            _rooms = new List<RoomData>();
            _corridors = new List<CorridorData>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonData" /> class.
        /// </summary>
        /// <param name="board">The 2D array representing the dungeon board.</param>
        /// <param name="rooms">The list of rooms in the dungeon.</param>
        /// <param name="corridors">The list of corridors connecting the rooms.</param>
        internal DungeonData(BoardSquare[,] board, List<RoomData> rooms, List<CorridorData> corridors)
        {
            Board = board ?? throw new ArgumentNullException(nameof(board));
            Rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
            Corridors = corridors ?? throw new ArgumentNullException(nameof(corridors));
        }

        /// <summary>
        ///     Gets or sets the 2D array representing the dungeon board.
        ///     Each element represents a square on the board with its type (floor, wall, corner, etc.).
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the assigned value is null.</exception>
        [JsonNativePropertyName("board")]
        public BoardSquare[,] Board
        {
            get => _board;
            set => _board = value ?? throw new ArgumentNullException(nameof(Board));
        }

        /// <summary>
        ///     Gets or sets the list of rooms in the dungeon.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the assigned value is null.</exception>
        [JsonNativePropertyName("rooms")]
        public List<RoomData> Rooms
        {
            get => _rooms;
            set => _rooms = value ?? throw new ArgumentNullException(nameof(Rooms));
        }

        /// <summary>
        ///     Gets or sets the list of corridors connecting the rooms.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the assigned value is null.</exception>
        [JsonNativePropertyName("corridors")]
        public List<CorridorData> Corridors
        {
            get => _corridors;
            set => _corridors = value ?? throw new ArgumentNullException(nameof(Corridors));
        }

        /// <summary>
        ///     Gets the width of the dungeon board.
        /// </summary>
        public int Width => Board.GetLength(0);

        /// <summary>
        ///     Gets the height of the dungeon board.
        /// </summary>
        public int Height => Board.GetLength(1);
    }
}
