// -------------------------------------------------------------------------- 
//  
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█  
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄ 
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█ 
//
//  -------------------------------------------------------------------------- 
//  File:IGame.cs 
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


using System.Collections.Generic;
using Alis.Core.Manager;

namespace Alis.Core
{
    /// <summary>
    /// Define a game.
    /// </summary>
    public abstract class GameBase
    {
        /// <summary>
        /// Active game
        /// </summary>
        public bool IsRunning;
        
        /// <summary>
        /// The manager base
        /// </summary>
        protected List<ManagerBase> Managers = new List<ManagerBase>();

        /// <summary>
        /// Run program
        /// </summary>
        public virtual void Run()
        {
            IsRunning = true;
            
            Managers.ForEach(i => i.Awake());
            Managers.ForEach(i => i.Start());

            while (IsRunning)
            {
                Managers.ForEach(i => i.BeforeUpdate());
                Managers.ForEach(i => i.Update());
                Managers.ForEach(i => i.AfterUpdate());
                Managers.ForEach(i => i.DispatchEvents());
                
                Managers.ForEach(i => i.FixedUpdate());
            }
            
            Managers.ForEach(i => i.Stop());
            Managers.ForEach(i => i.Exit());
            
            IsRunning = false;
        }
    }
}
