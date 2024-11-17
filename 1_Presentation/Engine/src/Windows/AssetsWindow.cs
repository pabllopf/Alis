// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetsWindow.cs
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
using System.Runtime.InteropServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The assets window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class AssetsWindow : IWindow
    {
        private static readonly string WindowName = $"{FontAwesome5.FolderOpen} Assets";

        /// <summary>
        ///     The command ptr
        /// </summary>
        private readonly IntPtr commandPtr;

        /// <summary>
        ///     The is open
        /// </summary>
        private bool isOpen = true;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AssetsWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public AssetsWindow(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
            commandPtr = Marshal.AllocHGlobal(256);
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
                return;
            }

            if (ImGui.Begin(WindowName, ref isOpen))
            {
                ImGui.Button("Assets");
                ImGui.SameLine();
                ImGui.Text("/");
                ImGui.SameLine();
                ImGui.Button("Textures");
                ImGui.SameLine();
                ImGui.InputText($"{FontAwesome5.Search}", commandPtr, 256);
                ImGui.Separator();
                ImGui.Columns(2);
                ImGui.Text("Directory");

                if (ImGui.TreeNodeEx("Folder"))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ImGui.Text($"Folder {i}");
                    }

                    ImGui.TreePop();
                }

                ImGui.NextColumn();
                ImGui.Text("Files");
                for (int i = 0; i < 10; i++)
                {
                    ImGui.Text($"Texture {i}");
                }
            }

            ImGui.End();
        }
    }
}