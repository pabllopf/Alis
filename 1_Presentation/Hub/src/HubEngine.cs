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

using Alis.App.Hub.Controllers;
using Alis.App.Hub.Windows;

namespace Alis.App.Hub
{
    /// <summary>
    ///     The engine class
    /// </summary>
    public class HubEngine
    {
        /// <summary>
        ///     The hub window
        /// </summary>
        private HubWindow hubWindow;

        /// <summary>
        ///     The im gui controller
        /// </summary>
        private ImGuiControllerImplementGlfw imGuiController;

        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <returns>The int</returns>
        public void Run()
        {
            imGuiController = new ImGuiControllerImplementGlfw(
                "Welcome to Alis by @pabllopf",
                1025,
                575,
                1,
                false);

            hubWindow = new HubWindow(imGuiController);

            imGuiController.OnInit();
            imGuiController.OnStart();

            hubWindow.OnInit();
            hubWindow.OnStart();

            while (imGuiController.IsRunning)
            {
                imGuiController.OnPollEvents();

                imGuiController.OnStartFrame();

                imGuiController.OnRenderFrame();

                hubWindow.OnRender();

                imGuiController.OnEndFrame();
            }

            hubWindow.OnDestroy();
            imGuiController.OnExit();
        }
    }
}