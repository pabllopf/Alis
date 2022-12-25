// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundGame.cs
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

using System.Collections.Generic;
using Alis.Builder;
using Alis.Core;
using Alis.Core.Manager;
using Alis.Core.Manager.Audio;
using Alis.Core.Manager.Input;
using Alis.Core.Manager.Scene;

namespace Alis
{
    /// <summary>
    ///     The sound game class
    /// </summary>
    /// <seealso cref="GameBase" />
    public class SoundGame : GameBase
    {
        /// <summary>
        ///     Runs this instance
        /// </summary>
        public override void Run()
        {
            Managers = new List<ManagerBase>
            {
                new InputManager(),
                new AudioManager(),
                new SceneManager()
            };
        }

        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The sound game builder</returns>
        public static SoundGameBuilder Builder() => new SoundGameBuilder();
    }
}