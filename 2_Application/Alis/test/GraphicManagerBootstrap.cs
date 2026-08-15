// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerBootstrap.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.General;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Test
{
    /// <summary>
    ///     Executes the GraphicManager init and draw paths on the process main thread, because
    ///     AppKit window creation is required on the main thread while xUnit runs tests on worker
    ///     threads. The startup hook invokes <see cref="Initialize" /> before the entry point and
    ///     every step records its result.
    /// </summary>
    internal static class GraphicManagerBootstrap
    {
        /// <summary>
        ///     Indicates whether the bootstrap completed successfully on the main thread.
        /// </summary>
        internal static bool Ready;

        /// <summary>
        ///     The failures collected while executing the steps on the main thread.
        /// </summary>
        internal static readonly List<Exception> Failures = new List<Exception>();

        /// <summary>
        ///     Indicates whether the init with the default window size completed.
        /// </summary>
        internal static bool InitDefaultWindowOk;

        /// <summary>
        ///     Indicates whether the init with the custom window size completed.
        /// </summary>
        internal static bool InitCustomWindowOk;

        /// <summary>
        ///     Indicates whether the draw completed.
        /// </summary>
        internal static bool DrawOk;

        /// <summary>
        ///     Indicates whether the preview draw completed.
        /// </summary>
        internal static bool DrawPreviewOk;

        /// <summary>
        ///     Runs the manager steps on the main thread and records the results.
        /// </summary>
        internal static void Initialize()
        {
            if (Ready)
            {
                return;
            }

            Execute("DefaultWindowInit", () =>
            {
                GraphicManager manager = CreateManager(false, null, null);
                manager.OnInit();
                InitDefaultWindowOk = true;
            });

            Execute("CustomWindowInit", () =>
            {
                GraphicManager manager = CreateManager(true, "alis-exec", "dino_assets.bmp");
                manager.OnInit();
                InitCustomWindowOk = true;
            });

            Execute("Draw", () =>
            {
                GraphicManager manager = CreateManager(true, null, null);
                manager.OnInit();
                manager.OnDraw();
                DrawOk = true;
            });

            Execute("DrawPreview", () =>
            {
                GraphicSetting graphic = new GraphicSetting { PreviewMode = true };
                Setting setting = new Setting { Graphic = graphic };
                Context context = new Context(setting);
                Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
                context.SceneManager.AddScene(scene);
                context.SceneManager.CurrentWorld = scene;
                GraphicManager manager = new GraphicManager(context);
                manager.OnDraw();
                DrawPreviewOk = true;
            });

            Ready = Failures.Count == 0;
        }

        /// <summary>
        ///     Creates a non-preview manager context with a world containing a camera, a sprite
        ///     and a box collider, with the physics debug flag enabled.
        /// </summary>
        /// <param name="customWindowSize">Whether to set a custom window size</param>
        /// <param name="name">The window title override</param>
        /// <param name="icon">The window icon override</param>
        /// <returns>The manager</returns>
        private static GraphicManager CreateManager(bool customWindowSize, string name, string icon)
        {
            GraphicSetting graphic = new GraphicSetting
            {
                PreviewMode = false,
                WindowSize = customWindowSize ? new Vector2F(640, 480) : default
            };
            Setting setting = new Setting
            {
                Graphic = graphic,
                Physic = new PhysicSetting { Debug = true },
                General = new GeneralSetting { Name = name, Icon = icon }
            };
            Context context = new Context(setting);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            GameObject camera = scene.Create();
            camera.Add(new Camera());
            GameObject collider = scene.Create(new Transform(new Vector2F(0.0f, 0.0f), 0.0f, new Vector2F(1.0f, 1.0f)));
            BoxCollider boxCollider = new BoxCollider { Context = context };
            collider.Add(boxCollider);
            GameObject sprite = scene.Create(new Transform(new Vector2F(0.0f, 0.0f), 0.0f, new Vector2F(1.0f, 1.0f)));
            sprite.Add(new Sprite(new Context(), "dino_assets.bmp", 0));
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;
            return new GraphicManager(context);
        }

        /// <summary>
        ///     Executes the specified action and records any exception.
        /// </summary>
        /// <param name="name">The step name</param>
        /// <param name="action">The action to execute</param>
        private static void Execute(string name, Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                Failures.Add(new Exception(name, exception));
            }
        }
    }
}
