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
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Setting;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The video game class
    /// </summary>
    /// <seealso cref="IGame" />
    public sealed class VideoGame : IGame, IHasContext<Context>, IBuilder<VideoGameBuilder>
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly Context _context;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        public VideoGame() => _context = new Context(new Settings());

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class
        /// </summary>
        /// <param name="settings">The settings</param>
        public VideoGame(Settings settings) => _context = new Context(settings);

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        /// <param name="context">The context</param>
        [JsonConstructor]
        public VideoGame(Context context) => _context = context;
        
        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        [JsonPropertyName("_Context_")]
        public Context Context => _context;

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run() => _context.Run();

        /// <summary>
        /// Runs the preview
        /// </summary>
        public void RunPreview() => _context.RunPreview();

        /// <summary>
        /// Exits this instance
        /// </summary>
        public void Exit() => _context.Exit();

        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The video game builder</returns>
        public VideoGameBuilder Builder() => new VideoGameBuilder();

        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Create() => new VideoGameBuilder();
    }
}