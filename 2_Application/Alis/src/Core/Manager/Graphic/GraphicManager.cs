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
using System.Threading.Tasks;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.SFML;
using Alis.Core.Graphic.D2.SFML.Graphics;
using Alis.Core.Graphic.D2.SFML.Windows;
using Sprite = Alis.Core.Component.Render.Sprite;

namespace Alis.Core.Manager.Graphic
{
    /// <summary>
    ///     The graphic manager class
    /// </summary>
    /// <seealso cref="ManagerBase" />
    public class GraphicManager : GraphicManagerBase
    {

        /// <summary>
        /// The current
        /// </summary>
        public static GraphicManager Current;
        
        /// <summary>
        ///     The renderWindow
        /// </summary>
        public RenderWindow renderWindow;

        /// <summary>
        /// The video mode
        /// </summary>
        private VideoMode VideoMode;

        /// <summary>
        ///     Gets or sets the value of the sprites
        /// </summary>
        private static List<Sprite> Sprites { get; set; } = new List<Sprite>();

        private Styles styles = Styles.Default;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicManager"/> class
        /// </summary>
        public GraphicManager()
        {
            Current = this;
        }

        private Vector2 defaultSize = new Vector2();
        
        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            Console.WriteLine("init::graphic:new");
            
            defaultSize = new Vector2(VideoGame.Setting.Graphic.Window.Resolution.X, VideoGame.Setting.Graphic.Window.Resolution.Y);
            
            styles = Styles.Default;
            InitRenderWindow();
        }
        
        

        private void RenderWindowOnKeyPressed(object sender, KeyEventArgs e)
        {
            
        }

        private void RenderWindowOnResized(object sender, SizeEventArgs e)
        {
            
            VideoGame.Setting.Graphic.Window.Resolution = new Vector2(e.Width, e.Height);
            
            renderWindow.Size = new Vector2U(
                (uint) VideoGame.Setting.Graphic.Window.Resolution.X,
                (uint) VideoGame.Setting.Graphic.Window.Resolution.Y);
        }

        private void InitRenderWindow()
        {
            if (renderWindow is {IsOpen: true})
            {
                renderWindow.Close();
                renderWindow.Dispose();
            }
            
            VideoMode = new VideoMode(
                (uint) defaultSize.X, 
                (uint) defaultSize.Y);

            VideoGame.Setting.Graphic.Window.Resolution = new Vector2(defaultSize.X, defaultSize.Y);
            
            renderWindow = new RenderWindow(VideoMode, 
                $"{VideoGame.Setting.General.Name} by {VideoGame.Setting.General.Author}", styles);

            renderWindow.RequestFocus();
            renderWindow.SetVisible(true);


            if (!VideoGame.Setting.General.IconFile.Equals(""))
            {
                Image image = new Image(VideoGame.Setting.General.IconFile);
                renderWindow.SetIcon(image.Size.X, image.Size.Y, image.Pixels);
            }
            
            renderWindow.Resized += RenderWindowOnResized;
            renderWindow.KeyPressed += RenderWindowOnKeyPressed;
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
        public override void BeforeUpdate() => renderWindow.Clear(VideoGame.Setting.Graphic.Window.Background);

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
        public override void DispatchEvents()
        {
            renderWindow.DispatchEvents();
            if (Keyboard.IsKeyPressed(Key.LAlt) && Keyboard.IsKeyPressed(Key.Enter) && Math.Abs(renderWindow.Size.X - defaultSize.X) > 0.1 && Math.Abs(renderWindow.Size.Y - defaultSize.Y) > 0.1)
            {
                styles = Styles.Default;
                Console.WriteLine("Change style to default");
                InitRenderWindow();
                Task.Delay(100).Wait();
                return;
            }

            if (Keyboard.IsKeyPressed(Key.LAlt) && Keyboard.IsKeyPressed(Key.Enter) && Math.Abs(renderWindow.Size.X - defaultSize.X) < 0.1 && Math.Abs(renderWindow.Size.Y - defaultSize.Y) < 0.1)
            {
                styles = Styles.Fullscreen;
                Console.WriteLine("Change style to Fullscreen");
                InitRenderWindow();
                Task.Delay(100).Wait();
                return;
            }
        }

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
        private void RenderWindowOnClosed(object sender, EventArgs e) => GameBase.IsRunning = false;

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

        /// <summary>
        /// Sets the view using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        public void SetView(View view)
        {
            renderWindow.SetView(view);
        }
    }
}