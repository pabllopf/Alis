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
using Alis.Core.Ecs.Components;
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
        internal readonly ConsoleKey[] allKeys = new[]
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
        internal readonly Dictionary<ConsoleKey, DateTime> keyDownTimestamps = new Dictionary<ConsoleKey, DateTime>();

        /// <summary>
        ///     The console key
        /// </summary>
        private HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey>();

        /// <summary>
        ///     Reusable buffer for pressed keys calculation to avoid per-frame allocations.
        /// </summary>
        private readonly HashSet<ConsoleKey> _pressedKeysBuffer = new HashSet<ConsoleKey>();

        /// <summary>
        ///     Reusable buffer for held keys calculation to avoid per-frame allocations.
        /// </summary>
        private readonly HashSet<ConsoleKey> _heldKeysBuffer = new HashSet<ConsoleKey>();

        /// <summary>
        ///     Reusable buffer for released keys calculation to avoid per-frame allocations.
        /// </summary>
        private readonly HashSet<ConsoleKey> _releasedKeysBuffer = new HashSet<ConsoleKey>();

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
            // Method intentionally left empty.
        }

        /// <summary>
        ///     Ons the before draw
        /// </summary>
        public override void OnBeforeDraw()
        {
            // Method intentionally left empty.
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

            DateTime now = DateTime.UtcNow;
            HashSet<ConsoleKey> newKeys = BuildNewKeys();

            ComputePressedKeys(newKeys, currentKeys, _pressedKeysBuffer);
            ComputeHeldKeys(newKeys, currentKeys, _heldKeysBuffer);
            ComputeReleasedKeys(currentKeys, newKeys, _releasedKeysBuffer);

            UpdateKeyTimestamps(_pressedKeysBuffer, _releasedKeysBuffer, now);
            ProcessKeyEventComponents(_pressedKeysBuffer, _heldKeysBuffer, _releasedKeysBuffer, now);

            currentKeys = newKeys;


            float pixelsPerMeter = PixelsPerMeter;
            Setting contextSetting = Context.Setting;
            PhysicSetting physicSettings = contextSetting.Physic;
            Color backgrounColor = contextSetting.Graphic.BackgroundColor;


            // Set the clear color (convert from 0-255 range to 0.0-1.0 range)
            Gl.GlClearColor(backgrounColor.R / 255.0f, backgrounColor.G / 255.0f, backgrounColor.B / 255.0f, backgrounColor.A / 255.0f);

            // Clear the screen
            Gl.GlClear(ClearBufferMasks.ColorBufferBit);

            GameObjectQueryEnumerator.QueryEnumerable spriteGameObjects = Context.SceneManager.CurrentWorld
                .Query<With<Sprite>>()
                .EnumerateWithEntities();

            GameObjectQueryEnumerator.QueryEnumerable boxColliderGameObjects = Context.SceneManager.CurrentWorld
                .Query<With<BoxCollider>>()
                .EnumerateWithEntities();

            foreach (RefTuple<Camera> camera in Context.SceneManager.CurrentWorld
                         .Query<With<Camera>>()
                         .Enumerate<Camera>())
            {
                RenderBoxColliders(boxColliderGameObjects, physicSettings, camera, pixelsPerMeter);
                RenderSprites(spriteGameObjects, camera, pixelsPerMeter);
            }

            // Swap the buffers to display the triangle
            platform.SwapBuffers();
            int glError = Gl.GlGetError();
            if (glError != 0)
            {
                Logger.Info($"OpenGL error tras flushBuffer: 0x{glError:X}");
            }
        }

        /// <summary>
        ///     Renders the preview
        /// </summary>
        internal void RenderPreview()
        {
            float pixelsPerMeter = PixelsPerMeter;
            Setting contextSetting = Context.Setting;
            PhysicSetting physicSettings = contextSetting.Physic;
            Color backgrounColor = contextSetting.Graphic.BackgroundColor;


            // Set the clear color (convert from 0-255 range to 0.0-1.0 range)
            Gl.GlClearColor(backgrounColor.R / 255.0f, backgrounColor.G / 255.0f, backgrounColor.B / 255.0f, backgrounColor.A / 255.0f);

            // Clear the screen
            Gl.GlClear(ClearBufferMasks.ColorBufferBit);

            GameObjectQueryEnumerator.QueryEnumerable spriteGameObjects = Context.SceneManager.CurrentWorld
                .Query<With<Sprite>>()
                .EnumerateWithEntities();

            GameObjectQueryEnumerator.QueryEnumerable boxColliderGameObjects = Context.SceneManager.CurrentWorld
                .Query<With<BoxCollider>>()
                .EnumerateWithEntities();

            foreach (RefTuple<Camera> camera in Context.SceneManager.CurrentWorld
                         .Query<With<Camera>>()
                         .Enumerate<Camera>())
            {
                RenderBoxColliders(boxColliderGameObjects, physicSettings, camera, pixelsPerMeter);
                RenderSprites(spriteGameObjects, camera, pixelsPerMeter);
            }
        }

        /// <summary>
        ///     Builds the set of currently pressed keys using a manual loop to avoid LINQ allocations.
        /// </summary>
        private HashSet<ConsoleKey> BuildNewKeys()
        {
            HashSet<ConsoleKey> keys = new HashSet<ConsoleKey>();
            for (int i = 0; i < allKeys.Length; i++)
            {
                if (platform.IsKeyDown(allKeys[i]))
                {
                    keys.Add(allKeys[i]);
                }
            }

            return keys;
        }

        /// <summary>
        /// Computes the pressed keys into a reusable destination set.
        /// </summary>
        internal static void ComputePressedKeys(HashSet<ConsoleKey> newKeys, HashSet<ConsoleKey> currentKeys, HashSet<ConsoleKey> result)
        {
            result.Clear();
            result.UnionWith(newKeys);
            result.ExceptWith(currentKeys);
        }

        /// <summary>
        /// Computes the held keys into a reusable destination set.
        /// </summary>
        internal static void ComputeHeldKeys(HashSet<ConsoleKey> newKeys, HashSet<ConsoleKey> currentKeys, HashSet<ConsoleKey> result)
        {
            result.Clear();
            result.UnionWith(newKeys);
            result.IntersectWith(currentKeys);
        }

        /// <summary>
        /// Computes the released keys into a reusable destination set.
        /// </summary>
        internal static void ComputeReleasedKeys(HashSet<ConsoleKey> currentKeys, HashSet<ConsoleKey> newKeys, HashSet<ConsoleKey> result)
        {
            result.Clear();
            result.UnionWith(currentKeys);
            result.ExceptWith(newKeys);
        }

        /// <summary>
        /// Updates the key timestamps using the specified pressed keys
        /// </summary>
        /// <param name="pressedKeys">The pressed keys</param>
        /// <param name="releasedKeys">The released keys</param>
        /// <param name="now">The now</param>
        internal void UpdateKeyTimestamps(HashSet<ConsoleKey> pressedKeys, HashSet<ConsoleKey> releasedKeys, DateTime now)
        {
            foreach (ConsoleKey key in pressedKeys)
            {
                keyDownTimestamps[key] = now;
            }

            foreach (ConsoleKey key in releasedKeys)
            {
                keyDownTimestamps.Remove(key);
            }
        }

        /// <summary>
        /// Processes the key event components using the specified pressed keys
        /// </summary>
        /// <param name="pressedKeys">The pressed keys</param>
        /// <param name="heldKeys">The held keys</param>
        /// <param name="releasedKeys">The released keys</param>
        /// <param name="now">The now</param>
        internal void ProcessKeyEventComponents(HashSet<ConsoleKey> pressedKeys, HashSet<ConsoleKey> heldKeys, HashSet<ConsoleKey> releasedKeys, DateTime now)
        {
            foreach (GameObject gameObject in Context.SceneManager.CurrentWorld
                         .Query<With<Info>>()
                         .EnumerateWithEntities())
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    ProcessKeyEventForComponent(componentType, gameObject, pressedKeys, heldKeys, releasedKeys, now);
                }
            }
        }

        /// <summary>
        /// Processes the key event for component using the specified component type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <param name="gameObject">The game object</param>
        /// <param name="pressedKeys">The pressed keys</param>
        /// <param name="heldKeys">The held keys</param>
        /// <param name="releasedKeys">The released keys</param>
        /// <param name="now">The now</param>
        internal void ProcessKeyEventForComponent(Type componentType, GameObject gameObject, HashSet<ConsoleKey> pressedKeys, HashSet<ConsoleKey> heldKeys, HashSet<ConsoleKey> releasedKeys, DateTime now)
        {
            if (typeof(IOnPressKey).IsAssignableFrom(componentType))
            {
                IOnPressKey onPressKey = (IOnPressKey)gameObject.Get(componentType);
                foreach (ConsoleKey k in pressedKeys)
                {
                    onPressKey.OnPressKey(new KeyEventInfo(k, now, TimeSpan.Zero));
                }
            }

            if (typeof(IOnHoldKey).IsAssignableFrom(componentType))
            {
                IOnHoldKey onHoldKey = (IOnHoldKey)gameObject.Get(componentType);
                foreach (ConsoleKey k in heldKeys)
                {
                    TimeSpan holdDuration = keyDownTimestamps.TryGetValue(k, out DateTime downTime) ? now - downTime : TimeSpan.Zero;
                    onHoldKey.OnHoldKey(new KeyEventInfo(k, now, holdDuration));
                }
            }

            if (typeof(IOnReleaseKey).IsAssignableFrom(componentType))
            {
                IOnReleaseKey onReleaseKey = (IOnReleaseKey)gameObject.Get(componentType);
                foreach (ConsoleKey k in releasedKeys)
                {
                    TimeSpan holdDuration = keyDownTimestamps.TryGetValue(k, out DateTime downTime) ? now - downTime : TimeSpan.Zero;
                    onReleaseKey.OnReleaseKey(new KeyEventInfo(k, now, holdDuration));
                }
            }
        }

        /// <summary>
        /// Renders the box colliders using the specified box collider game objects
        /// </summary>
        /// <param name="boxColliderGameObjects">The box collider game objects</param>
        /// <param name="physicSettings">The physic settings</param>
        /// <param name="camera">The camera</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        internal static void RenderBoxColliders(GameObjectQueryEnumerator.QueryEnumerable boxColliderGameObjects, PhysicSetting physicSettings, RefTuple<Camera> camera, float pixelsPerMeter)
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

        /// <summary>
        /// Renders the sprites using the specified sprite game objects
        /// </summary>
        /// <param name="spriteGameObjects">The sprite game objects</param>
        /// <param name="camera">The camera</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        internal static void RenderSprites(GameObjectQueryEnumerator.QueryEnumerable spriteGameObjects, RefTuple<Camera> camera, float pixelsPerMeter)
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
}