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
    /// The video game class
    /// </summary>
    /// <seealso cref="IGame"/>
    /// <seealso cref="IBuilder{VideoGameBuilder}"/>
    public sealed class VideoGame : IGame, IBuilder<VideoGameBuilder>
    {
        /// <summary>
        /// The context handler
        /// </summary>
        private readonly ContextHandler _contextHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class
        /// </summary>
        public VideoGame() : this(new Setting()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class
        /// </summary>
        /// <param name="setting">The setting</param>
        public VideoGame(Setting setting) : this(new Context(setting)) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class
        /// </summary>
        /// <param name="context">The context</param>
        [JsonConstructor]
        public VideoGame(Context context) => _contextHandler = new ContextHandler(context);

        /// <summary>
        /// Gets the value of the context
        /// </summary>
        [JsonPropertyName("_Context_")] 
        public Context Context => _contextHandler.Context;

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run() => _contextHandler.Run();

        /// <summary>
        /// Runs the preview
        /// </summary>
        public void RunPreview() => _contextHandler.RunPreview();

        /// <summary>
        /// Exits this instance
        /// </summary>
        public void Exit() => _contextHandler.Exit();

        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The video game builder</returns>
        public VideoGameBuilder Builder() => new VideoGameBuilder();

        /// <summary>
        /// Creates
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Create() => new VideoGameBuilder();
    }
}