// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IController.cs
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

namespace Alis.App.Hub.Controllers
{
    /// <summary>
    /// The controller class
    /// </summary>
    public abstract class AController
    {
        /// <summary>
        /// Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork {get;}

        /// <summary>
        /// Initializes a new instance of the <see cref="AController"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public AController(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
        }
        
        /// <summary>
        /// Ons the init
        /// </summary>
        public abstract void OnInit();
        
        /// <summary>
        /// Ons the start
        /// </summary>
        public abstract void OnStart();
        
        /// <summary>
        /// Ons the start render
        /// </summary>
        public abstract void OnStartRender();
        
        /// <summary>
        /// Ons the update
        /// </summary>
        public abstract void OnUpdate();
        
        /// <summary>
        /// Ons the end render
        /// </summary>
        public abstract void OnEndRender();
        
        /// <summary>
        /// Ons the destroy
        /// </summary>
        public abstract void OnDestroy();
    }
}