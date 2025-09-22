// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HubEngine.cs
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

using Alis.App.Hub.Core;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sdl2;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Ui;

namespace Alis.App.Hub
{
    /// <summary>
    ///     The engine class
    /// </summary>
    public class HubEngine
    {
        /// <summary>
        ///     The windows
        /// </summary>
        private readonly SpaceWork spaceWork = new SpaceWork();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <returns>The int</returns>
        public void Run()
        {
            spaceWork.OnInit();
            spaceWork.OnStart();

            while (spaceWork.IsRunning)
            {
                while (Sdl.PollEvent(out Event e) != 0)
                {
                    spaceWork.OnEvent(e);
                }

                spaceWork.OnStartRender();

                ImGui.SetNextWindowPos(spaceWork.ViewportHub.WorkPos);
                ImGui.SetNextWindowSize(spaceWork.ViewportHub.Size);
                ImGui.Begin("DockSpace Demo", spaceWork.Dockspaceflags);

                Vector2F dockSize = spaceWork.ViewportHub.Size - new Vector2F(5, 85);
                uint dockSpaceId = ImGui.GetId("MyDockSpace");
                ImGui.DockSpace(dockSpaceId, dockSize);

                spaceWork.OnUpdate();

                ImGui.End();


                spaceWork.OnEndRender();
            }

            spaceWork.OnDestroy();
        }
    }
}