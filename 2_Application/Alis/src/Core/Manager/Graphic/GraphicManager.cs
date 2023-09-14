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
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.SFML.Graphics;
using Alis.Core.Graphic.SFML.Windows;
using Sprite = Alis.Core.Component.Render.Sprite;
using Styles = Alis.Core.Graphic.SFML.Windows.Styles;

namespace Alis.Core.Manager.Graphic
{
    /// <summary>
    ///     The graphic manager class
    /// </summary>
    /// <seealso cref="ManagerBase" />
    public class GraphicManager : GraphicManagerBase
    {
        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2 defaultSize;

        /// <summary>
        ///     The renderWindow
        /// </summary>
        private static RenderWindow _renderWindow;

        /// <summary>
        ///     The default
        /// </summary>
        private Styles styles = Styles.Default;

        /// <summary>
        ///     The video mode
        /// </summary>
        private VideoMode videoMode;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicManager" /> class
        /// </summary>
        public GraphicManager()
        {
        }

        /// <summary>
        ///     Gets or sets the value of the sprites
        /// </summary>
        private static List<Sprite> Sprites { get; set; } = new List<Sprite>();

        /// <summary>
        ///     Gets or sets the value of the colliders
        /// </summary>
        private static List<Shape> Colliders { get; } = new List<Shape>();
        
        /// <summary>
        ///     The blue
        /// </summary>
        private byte blue;

        /// <summary>
        ///     The blue
        /// </summary>
        private byte green;

        /// <summary>
        ///     The blue
        /// </summary>
        private byte red;
        
        /// <summary>
        /// The counter
        /// </summary>
        private int counter;

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            Logger.Log("init::graphic:new");

            defaultSize = new Vector2(VideoGame.Setting.Graphic.Window.Resolution.X, VideoGame.Setting.Graphic.Window.Resolution.Y);

            styles = Styles.Default;
            InitRenderWindow();
        }

        /// <summary>
        ///     Renders the window on resized using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void RenderWindowOnResized(object sender, SizeEventArgs e)
        {
            VideoGame.Setting.Graphic.Window.Resolution = new Vector2(e.Width, e.Height);

            _renderWindow.Size = new Vector2U(
                (uint) VideoGame.Setting.Graphic.Window.Resolution.X,
                (uint) VideoGame.Setting.Graphic.Window.Resolution.Y);
        }

        /// <summary>
        ///     Inits the render window
        /// </summary>
        private void InitRenderWindow()
        {
            if (_renderWindow is {IsOpen: true})
            {
                _renderWindow.Close();
                _renderWindow.Dispose();
            }

            videoMode = new VideoMode(
                (uint) defaultSize.X,
                (uint) defaultSize.Y);

            VideoGame.Setting.Graphic.Window.Resolution = new Vector2(defaultSize.X, defaultSize.Y);

            _renderWindow = new RenderWindow(videoMode,
                $"{VideoGame.Setting.General.Name} by {VideoGame.Setting.General.Author}", styles);

            _renderWindow.RequestFocus();
            _renderWindow.SetVisible(true);


            if (!VideoGame.Setting.General.IconFile.Equals(""))
            {
                Image image = new Image(VideoGame.Setting.General.IconFile);
                _renderWindow.SetIcon(image.Size.X, image.Size.Y, image.Pixels);
            }

            _renderWindow.Resized += RenderWindowOnResized;
            _renderWindow.Closed += RenderWindowOnClosed;
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start() => Sprites = Sprites.OrderBy(o => o.Depth).ToList();

        /// <summary>
        /// Before the update
        /// </summary>
        public override void BeforeUpdate() => _renderWindow.Clear(VideoGame.Setting.Graphic.Window.Background);

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            if (Sprites.Count <= 0 && Colliders.Count <= 0)
            {
                RenderSampleColor();
            }
            
            Sprites.ForEach(i => _renderWindow.Draw(i.SpriteSfml));
            Colliders.ForEach(i => _renderWindow.Draw(i));
        }

        /// <summary>
        /// Renders the sample color
        /// </summary>
        private void RenderSampleColor()
        {
            counter += 1;
            if (counter >= 100)
            {
                red += 1;
                if (red >= 255)
                {
                    red -= 0;
                }

                green += 2;
                if (green >= 255)
                {
                    green -= 1;
                }

                blue += 3;
                if (blue >= 255)
                {
                    blue -= 1;
                }
                counter = 0;
            }
            _renderWindow.Clear(new Color(red, green, blue));
        }

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate() => _renderWindow.Display();

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
            _renderWindow.DispatchEvents();
            if (Keyboard.IsKeyPressed(Key.LAlt) && Keyboard.IsKeyPressed(Key.Enter) && (Math.Abs(_renderWindow.Size.X - defaultSize.X) > 0.1) && (Math.Abs(_renderWindow.Size.Y - defaultSize.Y) > 0.1))
            {
                styles = Styles.Default;
                Logger.Log("Change style to default");
                InitRenderWindow();
                Task.Delay(100).Wait();
                return;
            }

            if (Keyboard.IsKeyPressed(Key.LAlt) && Keyboard.IsKeyPressed(Key.Enter) && (Math.Abs(_renderWindow.Size.X - defaultSize.X) < 0.1) && (Math.Abs(_renderWindow.Size.Y - defaultSize.Y) < 0.1))
            {
                styles = Styles.Fullscreen;
                Logger.Log("Change style to Fullscreen");
                InitRenderWindow();
                Task.Delay(100).Wait();
            }
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit() => _renderWindow.Close();

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
        ///     Sets the view using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        public static void SetView(View view) => _renderWindow.SetView(view);

        /// <summary>
        ///     Attaches the collider using the specified shape
        /// </summary>
        /// <param name="shape">The shape</param>
        public void AttachCollider(Shape shape) => Colliders.Add(shape);
    }
}