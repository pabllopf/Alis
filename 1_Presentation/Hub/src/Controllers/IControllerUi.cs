// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IControllerUi.cs
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

namespace Alis.App.Hub.Controllers
{
    /// <summary>
    ///     The controller ui interface
    /// </summary>
    public interface IControllerUi
    {
        /// <summary>
        ///     Ons the init
        /// </summary>
        void OnInit();

        /// <summary>
        ///     Ons the start
        /// </summary>
        void OnStart();

        /// <summary>
        ///     Ons the poll events
        /// </summary>
        void OnPollEvents();

        /// <summary>
        ///     Ons the start frame
        /// </summary>
        void OnStartFrame();

        /// <summary>
        ///     Ons the render frame
        /// </summary>
        void OnRenderFrame();

        /// <summary>
        ///     Ons the end frame
        /// </summary>
        void OnEndFrame();

        /// <summary>
        ///     Ons the exit
        /// </summary>
        void OnExit();
    }
}