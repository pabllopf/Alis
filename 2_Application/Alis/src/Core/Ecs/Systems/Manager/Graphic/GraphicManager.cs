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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory;
using Alis.Core.Ecs.Components.Body;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
using Alis.Core.Graphic.Platforms.Osx;
using Color = Alis.Core.Aspect.Math.Definition.Color;

namespace Alis.Core.Ecs.Systems.Manager.Graphic
{
    /// <summary>
    ///     The graphic manager base class
    /// </summary>
    /// <seealso cref="AManager" />
    public class GraphicManager : AManager
    {
        /// <summary>
        ///     The pixels per meter
        /// </summary>
        private const float PixelsPerMeter = 32.0f;

        /// <summary>
        ///     The escape
        /// </summary>
        private readonly ConsoleKey[] allKeys = new[]
        {
            ConsoleKey.A, ConsoleKey.B, ConsoleKey.C, ConsoleKey.D, ConsoleKey.E,
            ConsoleKey.F, ConsoleKey.G, ConsoleKey.H, ConsoleKey.I, ConsoleKey.J,
            ConsoleKey.K, ConsoleKey.L, ConsoleKey.M, ConsoleKey.N, ConsoleKey.O,
            ConsoleKey.P, ConsoleKey.Q, ConsoleKey.R, ConsoleKey.S, ConsoleKey.T,
            ConsoleKey.U, ConsoleKey.V, ConsoleKey.W, ConsoleKey.X, ConsoleKey.Y,
            ConsoleKey.Z,
            ConsoleKey.Spacebar, ConsoleKey.Enter, ConsoleKey.Escape
        };

        /// <summary>
        ///     The date time
        /// </summary>
        private readonly Dictionary<ConsoleKey, DateTime> keyDownTimestamps = new Dictionary<ConsoleKey, DateTime>();

        /// <summary>
        ///     The console key
        /// </summary>
        private HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey>();

        /// <summary>
        ///     The platform
        /// </summary>
        private INativePlatform platform;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicManager" /> class
        /// </summary>
        public GraphicManager(Context context) : base(context)
        {
        }

        /// <summary>
        ///     Gets or sets the value of the renderer
        /// </summary>
        public IntPtr Renderer { get; set; }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            if (Context.Setting.Graphic.PreviewMode)
            {
                Console.WriteLine("Preview mode enabled, skipping graphics initialization.");
                return;
            }


#if osxarm64 || osxarm || osxx64 || osx
            platform = new MacNativePlatform();
#elif winx64 || winx86 || winarm64 || winarm || win
            platform = new Alis.Core.Graphic.Platforms.Win.WinNativePlatform();
#elif linuxarm64 || linuxarm || linuxx64
            platform = new Alis.Core.Graphic.Platforms.Linux.LinuxNativePlatform();
#else
            platform = null;
#endif
            if (Context.Setting.Graphic.WindowSize != default(Vector2F))
            {
                platform.Initialize((int) Context.Setting.Graphic.WindowSize.X, (int) Context.Setting.Graphic.WindowSize.Y, "Alis Game");
            }
            else
            {
                platform.Initialize(800, 600, "Alis Game");
            }


            platform.MakeContextCurrent();

            Gl.Initialize(platform.GetProcAddress);

            if (!string.IsNullOrEmpty(Context.Setting.General.Name))
            {
                platform.SetTitle(Context.Setting.General.Name);
            }
            else
            {
                platform.SetTitle("Alis Game");
            }


            if (!string.IsNullOrEmpty(Context.Setting.General.Icon) && (AssetRegistry.GetResourcePathByName(Context.Setting.General.Icon) != null))
            {
                platform.SetWindowIcon(AssetRegistry.GetResourcePathByName(Context.Setting.General.Icon));
            }

            platform.ShowWindow();
        }


        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        ///     Ons the before draw
        /// </summary>
        public override void OnBeforeDraw()
        {
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public override void OnDraw()
        {
            if (Context.Setting.Graphic.PreviewMode)
            {
                RenderPreview();
                return;
            }


            bool running = platform.PollEvents();
            if (!running)
            {
                Context.Exit();
            }

            HashSet<ConsoleKey> pressedKeys = ProcessKeyState();

            ProcessKeyEventDispatch(pressedKeys);

            RenderScene(Context.Setting, PixelsPerMeter);

            platform.SwapBuffers();
            CheckGlError();
        }

        /// <summary>
        ///     Renders the preview
        /// </summary>
        private void RenderPreview()
        {
            RenderScene(Context.Setting, PixelsPerMeter);
        }

        private HashSet<ConsoleKey> ProcessKeyState()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey>(allKeys.Where(platform.IsKeyDown));
            DateTime now = DateTime.UtcNow;

            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>(newKeys);
            pressedKeys.ExceptWith(currentKeys);
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey>(newKeys);
            heldKeys.IntersectWith(currentKeys);
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey>(currentKeys);
            releasedKeys.ExceptWith(newKeys);

            foreach (ConsoleKey k in pressedKeys)
            {
                keyDownTimestamps[k] = now;
            }

            foreach (ConsoleKey k in releasedKeys)
            {
                keyDownTimestamps.TryGetValue(k, out DateTime _);
                keyDownTimestamps.Remove(k);
            }

            currentKeys = newKeys;
            return pressedKeys;
        }

        private void ProcessKeyEventDispatch(HashSet<ConsoleKey> pressedKeys)
        {
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey>(currentKeys);
            heldKeys.IntersectWith(pressedKeys);
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey>(currentKeys);
            releasedKeys.ExceptWith(pressedKeys);

            DateTime now = DateTime.UtcNow;

            GameObjectQueryEnumerator.QueryEnumerable result = Context.SceneManager.CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnPressKey).IsAssignableFrom(componentType))
                    {
                        IOnPressKey onPressKey = (IOnPressKey) gameObject.Get(componentType);
                        foreach (ConsoleKey k in pressedKeys)
                        {
                            KeyEventInfo info = new KeyEventInfo(k, now, TimeSpan.Zero);
                            onPressKey.OnPressKey(info);
                        }
                    }

                    if (typeof(IOnHoldKey).IsAssignableFrom(componentType))
                    {
                        IOnHoldKey onHoldKey = (IOnHoldKey) gameObject.Get(componentType);
                        foreach (ConsoleKey k in heldKeys)
                        {
                            keyDownTimestamps.TryGetValue(k, out DateTime downTime);
                            KeyEventInfo info = new KeyEventInfo(k, now, now - downTime);
                            onHoldKey.OnHoldKey(info);
                        }
                    }

                    if (typeof(IOnReleaseKey).IsAssignableFrom(componentType))
                    {
                        IOnReleaseKey onReleaseKey = (IOnReleaseKey) gameObject.Get(componentType);
                        foreach (ConsoleKey k in releasedKeys)
                        {
                            keyDownTimestamps.TryGetValue(k, out DateTime downTime);
                            KeyEventInfo info = new KeyEventInfo(k, now, now - downTime);
                            onReleaseKey.OnReleaseKey(info);
                        }
                    }
                }
            }
        }

        private void RenderBoxColliders(HashSet<GameObject> boxColliderGameObjects, Setting contextSetting, float pixelsPerMeter)
        {
            PhysicSetting physicSettings = contextSetting.Physic;

            foreach (RefTuple<Camera> camera in Context.SceneManager.CurrentWorld.Query<With<Camera>>().Enumerate<Camera>())
            {
                foreach (GameObject boxColliderGameobject in boxColliderGameObjects)
                {
                    if (boxColliderGameobject.Has<BoxCollider>())
                    {
                        ref BoxCollider boxCollider = ref boxColliderGameobject.Get<BoxCollider>();
                        if (physicSettings.Debug)
                        {
                            boxCollider.Render(boxColliderGameobject, camera.Item1.Value.Position, camera.Item1.Value.Resolution, pixelsPerMeter);
                        }
                    }
                }
            }
        }

        private void RenderSprites(HashSet<GameObject> spriteGameObjects, Setting contextSetting, float pixelsPerMeter)
        {
            foreach (RefTuple<Camera> camera in Context.SceneManager.CurrentWorld.Query<With<Camera>>().Enumerate<Camera>())
            {
                foreach (GameObject spriteGameobject in spriteGameObjects)
                {
                    if (spriteGameobject.Has<Animator>() && spriteGameobject.Has<Sprite>())
                    {
                        ref Animator animator = ref spriteGameobject.Get<Animator>();
                        ref Sprite sprite = ref spriteGameobject.Get<Sprite>();
                        animator.DrawAnimation(ref sprite);
                    }

                    if (spriteGameobject.Has<Sprite>())
                    {
                        ref Sprite sprite = ref spriteGameobject.Get<Sprite>();
                        sprite.Render(spriteGameobject, camera.Item1.Value.Position, camera.Item1.Value.Resolution, pixelsPerMeter);
                    }
                }
            }
        }

        private void RenderScene(Setting contextSetting, float pixelsPerMeter)
        {
            Gl.GlClearColor(contextSetting.Graphic.BackgroundColor.R / 255.0f, contextSetting.Graphic.BackgroundColor.G / 255.0f, contextSetting.Graphic.BackgroundColor.B / 255.0f, contextSetting.Graphic.BackgroundColor.A / 255.0f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit);

            HashSet<GameObject> spriteGameObjects = Context.SceneManager.CurrentWorld.Query<With<Sprite>>().EnumerateWithEntities().ToHashSet();
            HashSet<GameObject> boxColliderGameObjects = Context.SceneManager.CurrentWorld.Query<With<BoxCollider>>().EnumerateWithEntities().ToHashSet();

            RenderBoxColliders(boxColliderGameObjects, contextSetting, pixelsPerMeter);
            RenderSprites(spriteGameObjects, contextSetting, pixelsPerMeter);
        }

        private void CheckGlError()
        {
            int glError = Gl.GlGetError();
            if (glError != 0)
            {
                Logger.Info($"OpenGL error tras flushBuffer: 0x{glError:X}");
            }
        }
    }
}