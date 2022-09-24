// -------------------------------------------------------------------------- 
//  
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█  
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄ 
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█ 
//
//  -------------------------------------------------------------------------- 
//  File:GraphicManager.cs 
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
using Alis.Core.Graphic.D2.SFML.Graphics;
using Alis.Core.Graphic.D2.SFML.Windows;

namespace Alis.Core.Manager
{
    /// <summary>
    /// The graphic manager class
    /// </summary>
    /// <seealso cref="ManagerBase"/>
    public class GraphicManager : ManagerBase
    {
        /// <summary>
        /// The window
        /// </summary>
        private RenderWindow window;

        /// <summary>
        /// The video mode
        /// </summary>
        private VideoMode videoMode;

        /// <summary>
        /// The title
        /// </summary>
        private string title = "Default";
        
        private Color backGroundColor = Color.Blue;
        
        /// <summary>
        /// Inits this instance
        /// </summary>
        internal override void Init()
        {
            videoMode = new VideoMode(640, 480);
            window = new RenderWindow(videoMode, title);
            
            window.SetVerticalSyncEnabled(true);
            window.SetFramerateLimit(60);
            
            window.Closed += WindowOnClosed;
        }

        private void WindowOnClosed(object sender, EventArgs e)
        {
            GameBase.IsRunning = false;
        }

        /// <summary>
        /// Starts this instance
        /// </summary>
        public override void Start()
        {
            
        }
        
        /// <summary>
        /// Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
            //throw new NotImplementedException();
        }

       

        /// <summary>
        /// Awakes this instance
        /// </summary>
        public override void Awake()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Befores the update
        /// </summary>
        public override void BeforeUpdate()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Exits this instance
        /// </summary>
        public override void Exit()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Fixeds the update
        /// </summary>
        public override void FixedUpdate()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Resets this instance
        /// </summary>
        public override void Reset()
        {
            //throw new NotImplementedException();
        }

       

        /// <summary>
        /// Stops this instance
        /// </summary>
        public override void Stop()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public override void Update()
        {
            if (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(backGroundColor);
                window.Display();
            }
        }
    }
}
