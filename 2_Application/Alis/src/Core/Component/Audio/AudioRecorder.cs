// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioRecorder.cs
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

using Alis.Builder.Core.Component.Audio;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;
using Alis.Core.Audio;

namespace Alis.Core.Component.Audio
{
    /// <summary>
    ///     The audio recorder class
    /// </summary>
    /// <seealso cref="IAudioRecorder" />
    public class AudioRecorder : ComponentBase, IAudioRecorder, IBuilder<AudioRecorderBuilder>
    {
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The audio recorder builder</returns>
        public  AudioRecorderBuilder Builder() => new AudioRecorderBuilder();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
        }
    }
}