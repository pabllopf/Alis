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
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Graphic.D2.SFML.Graphics;
using Alis.Core.Graphic.D2.SFML.Windows;
using Sprite = Alis.Core.Component.Render.Sprite;

namespace Alis.Core.Manager
{
    /// <summary>
    ///     The graphic manager class
    /// </summary>
    /// <seealso cref="ManagerBase" />
    public class GraphicManager : ManagerBase
    {
        /// <summary>
        ///     The renderWindow
        /// </summary>
        private RenderWindow renderWindow;

        /// <summary>
        ///     Gets or sets the value of the sprites
        /// </summary>
        private static List<Sprite> Sprites { get; set; } = new List<Sprite>();

        /// <summary>
        ///     Inits this instance
        /// </summary>
        internal override void Init()
        {
            renderWindow = new RenderWindow(new VideoMode(640, 480), $"{GameBase.Setting.General.GameName} by {GameBase.Setting.General.Author}");
            renderWindow.Closed += RenderWindowOnClosed;
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start() => Sprites = Sprites.OrderBy(o => o.Depth).ToList();

        /// <summary>
        ///     Befores the update
        /// </summary>
        public override void BeforeUpdate() => renderWindow.Clear(Color.Blue);

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update() => Sprites.ForEach(i => renderWindow.Draw(i.sprite));

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate() => renderWindow.Display();

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents() => renderWindow.DispatchEvents();

        /// <summary>
        ///     Fixeds the update
        /// </summary>
        public override void FixedUpdate()
        {
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public override void Reset()
        {
        }

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public override void Stop()
        {
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit() => renderWindow.Close();

        /// <summary>
        ///     Windows the on closed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void RenderWindowOnClosed(object sender, EventArgs e)
        {
            GameBase.IsRunning = false;
        }

        /// <summary>
        ///     Attaches the sprite
        /// </summary>
        /// <param name="sprite">The sprite</param>
        public static void Attach(Sprite sprite)
        {
            Sprites.Add(sprite);
            Sprites = Sprites.OrderBy(o => o.Depth).ToList();
        }

        /// <summary>
        ///     Uns the attach using the specified sprite
        /// </summary>
        /// <param name="sprite">The sprite</param>
        public static void UnAttach(Sprite sprite)
        {
            Sprites.Remove(sprite);
            Sprites = Sprites.OrderBy(o => o.Depth).ToList();
        }
    }
}