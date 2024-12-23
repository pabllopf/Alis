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
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.System.Configuration;
using Alis.Core.Ecs.System.Scope;

namespace Alis.Core.Ecs.System
{
    /// <summary>
    ///     Represents a video game with context handling capabilities.
    /// </summary>
    /// <seealso cref="IGame" />
    /// <seealso cref="IHasBuilder{TOut}" />
    public sealed class VideoGame : IGame, IHasBuilder<VideoGameBuilder>
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
        [JsonConstructor]
        public VideoGame(IContextHandler<Context> contextHandler) => _contextHandler = contextHandler;

        /// <summary>
        ///     Gets the current context.
        /// </summary>
        [JsonPropertyName("_Context_")]
        public Context Context => _contextHandler.Context;

        /// <summary>
        ///     Runs the game.
        /// </summary>
        public void Run() => _contextHandler.Run();

        /// <summary>
        ///     Runs the game in preview mode.
        /// </summary>
        public void RunPreview() => _contextHandler.RunPreview();

        /// <summary>
        ///     Exits the game.
        /// </summary>
        public void Exit() => _contextHandler.Exit();

        /// <summary>
        ///     Creates a new instance of the <see cref="VideoGameBuilder" />.
        /// </summary>
        /// <returns>A new <see cref="VideoGameBuilder" /> instance.</returns>
        public VideoGameBuilder Builder() => new VideoGameBuilder();

        /// <summary>
        ///     Starts the preview
        /// </summary>
        public void StartPreview() => _contextHandler.StartPreview();

        /// <summary>
        ///     Saves this instance
        /// </summary>
        public void Save() => _contextHandler.Save();

        /// <summary>
        ///     Saves the path
        /// </summary>
        /// <param name="path">The path</param>
        public void Save(string path) => _contextHandler.Save(path);

        /// <summary>
        ///     Loads this instance
        /// </summary>
        public void Load() => _contextHandler.Load();

        /// <summary>
        ///     Loads the path
        /// </summary>
        /// <param name="path">The path</param>
        public void Load(string path) => _contextHandler.Load(path);

        /// <summary>
        ///     Loads the and run
        /// </summary>
        public void LoadAndRun()
        {
            _contextHandler.LoadAndRun();
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="VideoGameBuilder" />.
        /// </summary>
        /// <returns>A new <see cref="VideoGameBuilder" /> instance.</returns>
        public static VideoGameBuilder Create() => new VideoGameBuilder();
    }
}