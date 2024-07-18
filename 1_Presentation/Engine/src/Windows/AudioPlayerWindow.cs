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
    public class AudioPlayerWindow : IWindow
    {
        private const string WindowName = "Audio Player";

        private readonly TimeSpan currentTime;

        private readonly ImGuiWindowFlags flags = ImGuiWindowFlags.NoCollapse;

        private bool isOpen = true;

        private bool isPlaying;

        private readonly float progress;

        private readonly TimeSpan totalTime;

        public AudioPlayerWindow(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;

            // mock sample:
            progress = 1f;
            isPlaying = true;
            currentTime = new TimeSpan(0);
            totalTime = new TimeSpan(0, 0, 10);
        }

        public SpaceWork SpaceWork { get; }

        public void Initialize()
        {
        }

        public void Start()
        {
        }

        public void Render()
        {
            if (!isOpen)
            {
                Console.WriteLine("Audio Player Window is closed");
                return;
            }

            if (ImGui.Begin(WindowName, ref isOpen, flags))
            {
                if (ImGui.Button($"{FontAwesome5.Play}", new Vector2(25, 25)))
                {
                    isPlaying = true;
                }

                ImGui.SameLine();

                if (isPlaying)
                {
                    ImGui.ProgressBar(progress, new Vector2(-1, 0), $"{currentTime} / {totalTime} ");
                }
            }

            ImGui.End();
        }
    }
}