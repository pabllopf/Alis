// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameStub.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Ecs.System;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The game stub class
    /// </summary>
    /// <seealso cref="IGame" />
    [ExcludeFromCodeCoverage]
    internal class GameStub : IGame
    {
        /// <summary>
        ///     Gets or sets the value of the run invoked
        /// </summary>
        public bool RunInvoked { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the exit invoked
        /// </summary>
        public bool ExitInvoked { get; private set; }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            RunInvoked = true;
        }

        /// <summary>
        ///     Runs the preview
        /// </summary>
        public void RunPreview()
        {
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit()
        {
            ExitInvoked = true;
        }
    }
}