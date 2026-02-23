// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Dungeon.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Extension.Math.ProceduralDungeon.Interfaces;
using Alis.Extension.Math.ProceduralDungeon.Models;
using Alis.Extension.Math.ProceduralDungeon.Services;

namespace Alis.Extension.Math.ProceduralDungeon
{
    /// <summary>
    ///     Facade class providing a simplified interface for generating procedural dungeons.
    ///     This class encapsulates the complexity of dungeon generation and provides
    ///     an easy-to-use API for clients.
    /// </summary>
    /// <remarks>
    ///     The Dungeon class implements the Facade pattern, hiding the complex subsystem
    ///     of factories, builders, and generators behind a simple interface.
    ///     It manages the lifecycle of all dependencies and ensures proper initialization.
    /// </remarks>
    /// <example>
    ///     <code>
    ///     // Create with default configuration
    ///     var dungeon = new Dungeon();
    ///     var data = dungeon.Generate();
    ///     
    ///     // Create with custom configuration
    ///     var config = new DungeonConfiguration 
    ///     { 
    ///         BoardWidth = 200,
    ///         NumberOfRooms = 8 
    ///     };
    ///     var customDungeon = new Dungeon(config);
    ///     var customData = customDungeon.Generate();
    ///     </code>
    /// </example>
    public class Dungeon : IDisposable
    {
        /// <summary>
        ///     The dungeon generator used to create dungeons.
        /// </summary>
        private readonly IDungeonGenerator _generator;

        /// <summary>
        ///     The random number generator used for randomization.
        /// </summary>
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        /// <summary>
        ///     Indicates whether this instance has been disposed.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Dungeon" /> class with default configuration.
        /// </summary>
        /// <remarks>
        ///     Creates a dungeon generator with default settings:
        ///     - Board size: 150x150
        ///     - Number of rooms: 4
        ///     - Standard room dimensions with boss room
        /// </remarks>
        public Dungeon() : this(new DungeonConfiguration())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Dungeon" /> class with custom configuration.
        /// </summary>
        /// <param name="configuration">The configuration settings for dungeon generation.</param>
        /// <exception cref="ArgumentNullException">Thrown when configuration is null.</exception>
        /// <exception cref="ArgumentException">Thrown when configuration is invalid.</exception>
        public Dungeon(DungeonConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            configuration.Validate();

            _randomNumberGenerator = new CryptoRandomNumberGenerator();
            _generator = CreateGenerator(configuration, _randomNumberGenerator);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Dungeon" /> class with custom generator.
        /// </summary>
        /// <param name="generator">The dungeon generator to use.</param>
        /// <param name="randomNumberGenerator">The random number generator to use.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
        /// <remarks>
        ///     This constructor is primarily used for testing purposes, allowing dependency injection.
        /// </remarks>
        internal Dungeon(IDungeonGenerator generator, IRandomNumberGenerator randomNumberGenerator)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _randomNumberGenerator = randomNumberGenerator ?? throw new ArgumentNullException(nameof(randomNumberGenerator));
        }

        /// <summary>
        ///     Generates a new procedural dungeon with rooms, corridors, and complete board layout.
        /// </summary>
        /// <returns>
        ///     A <see cref="DungeonData" /> instance containing the complete dungeon structure,
        ///     including board grid, room positions, and corridor connections.
        /// </returns>
        /// <remarks>
        ///     The generation process includes:
        ///     1. Creating rooms with appropriate spacing
        ///     2. Connecting rooms with corridors
        ///     3. Building the board grid
        ///     4. Generating walls and corners
        ///     Each call to Generate() produces a unique dungeon layout.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">Thrown when called after disposal.</exception>
        public DungeonData Generate()
        {
            return _generator.Generate();
        }

        /// <summary>
        ///     Releases all resources used by this instance.
        /// </summary>
        /// <remarks>
        ///     Disposes of the random number generator and other managed resources.
        ///     After disposal, this instance should not be used.
        /// </remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Creates a dungeon generator with all necessary dependencies.
        /// </summary>
        /// <param name="configuration">The dungeon configuration.</param>
        /// <param name="randomNumberGenerator">The random number generator.</param>
        /// <returns>A configured dungeon generator instance.</returns>
        private static IDungeonGenerator CreateGenerator(
            DungeonConfiguration configuration,
            IRandomNumberGenerator randomNumberGenerator)
        {
            IRoomFactory roomFactory = new RoomFactory();
            ICorridorFactory corridorFactory = new CorridorFactory(randomNumberGenerator);
            IBoardBuilder boardBuilder = new BoardBuilder();

            return new DungeonGenerator(configuration, roomFactory, corridorFactory, boardBuilder);
        }

        /// <summary>
        ///     Releases the unmanaged resources used by this instance and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     True to release both managed and unmanaged resources; 
        ///     false to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_randomNumberGenerator is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                }

                _disposed = true;
            }
        }
    }
}

