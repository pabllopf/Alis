// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   RenderManager.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.Json.Serialization;
using Alis.Core.Configurations;
using Alis.Core.Graphics2D.Graphics;
using Alis.Core.Graphics2D.Windows;
using Alis.Core.Systems;
using Sprite = Alis.Core.Components.Sprite;

namespace Alis.Core.Managers
{
    /// <summary>Implement the render system of SFML library.</summary>
    public class RenderManager : RenderSystem
    {
        /// <summary>Initializes a new instance of the <see cref="RenderManager" /> class.</summary>
        [JsonConstructor]
        public RenderManager()
        {
            TitleWindow = $"{Game.Setting.General.Name} | {Game.Setting.General.Author}";
            VideoMode = new VideoMode((uint) Game.Setting.Window.Resolution.X, (uint) Game.Setting.Window.Resolution.Y);
            ScreenMode = Game.Setting.Window.ScreenMode switch
            {
                Configurations.ScreenMode.Default => Styles.Default,
                Configurations.ScreenMode.Resize => Styles.Resize,
                _ => Styles.Fullscreen
            };

            Game.Setting.General.OnChangeName += General_OnChangeName;
            Game.Setting.General.OnChangeAuthor += General_OnChangeAuthor;

            Game.Setting.Window.OnChangeResolution += Window_OnChangeResolution;
            Game.Setting.Window.OnChangeScreenMode += Window_OnChangeScreenMode;
        }


        /// <summary>Gets or sets the render window.</summary>
        /// <value>The render window.</value>
        private static RenderWindow? RenderWindow { get; set; }

        /// <summary>Gets or sets the video mode.</summary>
        /// <value>The video mode.</value>
        private VideoMode VideoMode { get; set; }

        /// <summary>Gets or sets the title window.</summary>
        /// <value>The title window.</value>
        private string TitleWindow { get; set; }

        /// <summary>Gets or sets the screen mode.</summary>
        /// <value>The screen mode.</value>
        private Styles ScreenMode { get; set; }

        /// <summary>Gets or sets the sprites.</summary>
        /// <value>The sprites.</value>
        private static List<Sprite> Sprites { get; set; } = new List<Sprite>(Game.Setting.Graphic.MaxElementsRender);

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            RenderWindow = new RenderWindow(VideoMode, TitleWindow, ScreenMode);
        }

        /// <summary>Awakes this instance.</summary>
        public override void Awake()
        {
            if (RenderWindow is not null)
            {
                RenderWindow.Closed += RenderWindow_Closed;
            }
        }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            Sprites = Sprites.OrderBy(o => o.Level).ToList();
        }

        /// <summary>Before the update.</summary>
        public override void BeforeUpdate()
        {
            RenderWindow?.Clear();
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            if (RenderWindow is not null)
            {
                for (int i = 0; i < Sprites.Count; i++)
                {
                    if (Sprites[i].IsActive)
                    {
                        RenderWindow.Draw(Sprites[i].Drawable);
                    }
                }

                if (Game.Setting.Debug.ShowPhysicBorders)
                {
                    if (PhysicsSystem.Colliders.Count > 0)
                    {
                        //Colliders = Colliders.OrderBy(o => o.Level).ToList();
                        for (int i = 0; i < PhysicsSystem.Colliders.Count; i++)
                        {
                            RenderWindow.Draw(PhysicsSystem.Colliders[i].GetDrawable());
                        }
                    }
                }
            }
        }

        /// <summary>Afters the update.</summary>
        public override void AfterUpdate()
        {
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public override void Draw()
        {
            RenderWindow?.Display();
        }

        /// <summary>Fixed the update.</summary>
        public override void FixedUpdate()
        {
        }

        /// <summary>Dispatches the events.</summary>
        public override void DispatchEvents()
        {
            RenderWindow?.DispatchEvents();
        }


        /// <summary>Resets this instance.</summary>
        public override void Reset()
        {
        }


        /// <summary>Stops this instance.</summary>
        public override void Stop()
        {
        }


        /// <summary>Exits this instance.</summary>
        public override void Exit()
        {
            RenderWindow?.Close();
        }

        /// <summary>Attaches the specified sprite.</summary>
        /// <param name="sprite">The sprite.</param>
        public static void Attach(Sprite sprite)
        {
            Sprites.Add(sprite);
        }

        /// <summary>Uns the attach.</summary>
        /// <param name="sprite">The sprite.</param>
        public static void UnAttach(Sprite sprite)
        {
            Sprites.Remove(sprite);
        }

        /// <summary>
        ///     Generals the on change name using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="name">The name</param>
        private void General_OnChangeName(object? sender, string name)
        {
            TitleWindow = $"{Game.Setting.General.Name} | {Game.Setting.General.Author}";
        }

        /// <summary>
        ///     Generals the on change author using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="author">The author</param>
        private void General_OnChangeAuthor(object? sender, string author)
        {
            TitleWindow = $"{Game.Setting.General.Name} | {Game.Setting.General.Author}";
        }


        /// <summary>Renders the window closed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RenderWindow_Closed(object? sender, EventArgs e)
        {
            Game.Exit();
        }

        /// <summary>
        ///     Windows the on change screen mode using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="screenMode">The screen mode</param>
        private void Window_OnChangeScreenMode(object? sender, ScreenMode screenMode)
        {
            ScreenMode = Game.Setting.Window.ScreenMode switch
            {
                Configurations.ScreenMode.Default => Styles.Default,
                Configurations.ScreenMode.Resize => Styles.Resize,
                _ => Styles.Fullscreen
            };
        }

        /// <summary>
        ///     Windows the on change resolution using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="resolution">The resolution</param>
        private void Window_OnChangeResolution(object? sender, Vector2 resolution)
        {
            VideoMode = new VideoMode((uint) resolution.X, (uint) resolution.Y);
        }

        /// <summary>Finalizes an instance of the <see cref="RenderManager" /> class.</summary>
        ~RenderManager()
        {
            Console.WriteLine(@$"Destroy RenderManager {GetHashCode().ToString()}");
        }

        /// <summary>
        ///     Sets the view using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        public static void SetView(View view)
        {
            RenderWindow?.SetView(view);
        }

        /// <summary>
        ///     Gets the windows
        /// </summary>
        /// <returns>The render window</returns>
        public static RenderWindow GetWindows()
        {
            return RenderWindow;
        }
    }
}