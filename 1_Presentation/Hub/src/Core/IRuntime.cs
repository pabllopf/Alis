// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRuntime.cs
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

namespace Alis.App.Hub.Core
{
    /// <summary>
    ///     Defines the lifecycle contract for runtime components within the Hub application.
    ///     Implementors must manage initialization, rendering, and cleanup of UI or engine resources.
    /// </summary>
    public interface IRuntime
    {
        /// <summary>
        ///     Performs one-time resource allocation and setup before the main loop begins.
        /// </summary>
        void OnInit();

        /// <summary>
        ///     Activates the component and prepares it for interaction after initialization completes.
        /// </summary>
        void OnStart();

        /// <summary>
        ///     Updates component state each frame, handling logic independent of rendering.
        /// </summary>
        void OnUpdate();

        /// <summary>
        ///     Renders the component's visual representation at the given scale factor.
        /// </summary>
        /// <param name="scale">The DPI-aware scale factor for rendering.</param>
        void OnRender(float scale);

        /// <summary>
        ///     Releases all resources and performs cleanup when the component is destroyed.
        /// </summary>
        void OnDestroy();
    }
}