// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IPlayer.cs
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
using System.Threading.Tasks;

namespace Alis.Core.Audio.Interfaces
{
    /// <summary>
    ///     The player interface
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        ///     Gets the value of the playing
        /// </summary>
        bool Playing { get; }
        
        /// <summary>
        ///     Gets the value of the paused
        /// </summary>
        bool Paused { get; }
        
        /// <summary>
        ///     playback
        /// </summary>
        event EventHandler PlaybackFinished;
        
        /// <summary>
        ///     Plays the file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        Task Play(string fileName);
        
        /// <summary>
        ///     Pauses this instance
        /// </summary>
        Task Pause();
        
        /// <summary>
        ///     Resumes this instance
        /// </summary>
        Task Resume();
        
        /// <summary>
        ///     Stops this instance
        /// </summary>
        Task Stop();
        
        /// <summary>
        ///     Sets the volume using the specified percent
        /// </summary>
        /// <param name="percent">The percent</param>
        Task SetVolume(byte percent);
    }
}