// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayerWindow.cs
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
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The audio player window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class AudioPlayerWindow : IWindow
    {
        private static readonly string WindowName = $"{FontAwesome5.Music} Audio Player";

        /// <summary>
        ///     The current time
        /// </summary>
        private readonly TimeSpan currentTime;

        /// <summary>
        ///     The no collapse
        /// </summary>
        private readonly ImGuiWindowFlags flags = ImGuiWindowFlags.NoCollapse;

        /// <summary>
        ///     The progress
        /// </summary>
        private readonly float progress;

        /// <summary>
        ///     The total time
        /// </summary>
        private readonly TimeSpan totalTime;

        /// <summary>
        ///     The is open
        /// </summary>
        private bool isOpen = true;

        /// <summary>
        ///     The is playing
        /// </summary>
        private bool isPlaying;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioPlayerWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public AudioPlayerWindow(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;

            // mock sample:
            progress = 1f;
            isPlaying = true;
            currentTime = new TimeSpan(0);
            totalTime = new TimeSpan(0, 0, 10);
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            if (!isOpen)
            {
                Console.WriteLine("Audio Player Window is closed");
                return;
            }

            if (ImGui.Begin(WindowName, ref isOpen, flags))
            {
                if (ImGui.Button($"{FontAwesome5.Play}"))
                {
                    isPlaying = true;
                }

                ImGui.SameLine();

                if (isPlaying)
                {
                    ImGui.ProgressBar(progress, new Vector2(-10, 0), $"{currentTime} / {totalTime} ");
                }
            }

            ImGui.End();
        }
    }
}