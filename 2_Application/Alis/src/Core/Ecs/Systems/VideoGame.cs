// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGame.cs
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

using Alis.Builder.Core.Ecs.System;

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Represents a video game with context handling capabilities.
    /// </summary>
    /// <seealso cref="IGame" />
    /// <seealso cref="IHasBuilder{TOut}" />
    public sealed class VideoGame : IGame
    {
        /// <summary>
        ///     The context handler
        /// </summary>
        private readonly IContextHandler<Context> _contextHandler;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        public VideoGame() : this(new ContextHandler(new Context()))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        /// <param name="setting">The setting</param>
        public VideoGame(Setting setting) : this(new ContextHandler(new Context(setting)))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public VideoGame(Context context) : this(new ContextHandler(context))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class.
        /// </summary>
        /// <param name="contextHandler">The context handler.</param>
        
        public VideoGame(IContextHandler<Context> contextHandler) => _contextHandler = contextHandler;

        /// <summary>
        ///     Gets the current context.
        /// </summary>
        
        public Context Context => _contextHandler.Context;

        /// <summary>
        ///     Runs the game.
        /// </summary>
        public void Run() => _contextHandler.Run();

        /// <summary>
        ///     Exits the game.
        /// </summary>
        public void Exit() => _contextHandler.Exit();

        /// <summary>
        /// Creates
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Create() => new VideoGameBuilder();

        /// <summary>
        /// Saves this instance
        /// </summary>
        public void Save() => _contextHandler.Save();
    }
}