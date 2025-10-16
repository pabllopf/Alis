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
using System.IO;
using System.IO.Compression;
using System.Linq;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;
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
        ///     The platform
        /// </summary>
        private INativePlatform platform;
        
        /// <summary>
        /// The escape
        /// </summary>
        ConsoleKey[] allKeys = new[]
        {
            ConsoleKey.A, ConsoleKey.B, ConsoleKey.C, ConsoleKey.D, ConsoleKey.E,
            ConsoleKey.F, ConsoleKey.G, ConsoleKey.H, ConsoleKey.I, ConsoleKey.J,
            ConsoleKey.K, ConsoleKey.L, ConsoleKey.M, ConsoleKey.N, ConsoleKey.O,
            ConsoleKey.P, ConsoleKey.Q, ConsoleKey.R, ConsoleKey.S, ConsoleKey.T,
            ConsoleKey.U, ConsoleKey.V, ConsoleKey.W, ConsoleKey.X, ConsoleKey.Y,
            ConsoleKey.Z,
            ConsoleKey.Spacebar, ConsoleKey.Enter, ConsoleKey.Escape
        };

        // Diccionario para guardar el timestamp de pulsación de cada tecla
        /// <summary>
        /// The date time
        /// </summary>
        private Dictionary<ConsoleKey, DateTime> keyDownTimestamps = new Dictionary<ConsoleKey, DateTime>();
        // Estado actual de teclas presionadas
        /// <summary>
        /// The console key
        /// </summary>
        private HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey>();
        // Estado anterior de teclas presionadas
        /// <summary>
        /// The console key
        /// </summary>
        private HashSet<ConsoleKey> previousKeys = new HashSet<ConsoleKey>();

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
#if osxarm64 || osxarm || osxx64 || osx
            platform = new Alis.Core.Graphic.Platforms.Osx.MacNativePlatform();
#elif winx64
            platform = new Alis.Core.Graphic.Platforms.Win.WinNativePlatform();
#elif LINUX
            platform = new Alis.Core.Graphic.Platforms.Linux.LinuxNativePlatform();
#else
            throw new Exception("Sistema operativo no soportado");
#endif


            platform.Initialize((int) Context.Setting.Graphic.WindowSize.X, (int) Context.Setting.Graphic.WindowSize.Y, Context.Setting.General.Name);
            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            //Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            //Gl.GlEnable(EnableCap.DepthTest);

            
            platform.SetTitle(Context.Setting.General.Name);

            string iconPath = AssetManager.Find(Context.Setting.General.Icon);
            if (string.IsNullOrEmpty(iconPath))
            {
                using (Stream streamPack = AssetRegistry.GetAssetStreamByBaseName("assets.pak"))
                {
                    if (streamPack == null)
                        throw new FileNotFoundException("Resource file 'assets.pak' not found in embedded resources.");
  
                    using (MemoryStream memPack = new MemoryStream())
                    {
                        streamPack.CopyTo(memPack);
                        memPack.Position = 0;
  
                        using (ZipArchive zip = new ZipArchive(memPack, ZipArchiveMode.Read))
                        {
                            ZipArchiveEntry entry = zip.Entries.FirstOrDefault(e => e.FullName.Contains(Context.Setting.General.Icon));
                            if (entry == null)
                                throw new FileNotFoundException($"Resource '{Context.Setting.General.Icon}' not found in 'assets.pak'.");
  
                            using (Stream entryStream = entry.Open())
                            using (MemoryStream memImage = new MemoryStream())
                            {
                                entryStream.CopyTo(memImage);
                                memImage.Position = 0;
                               
                                // write file on temp path:
                                string tempPath = Path.GetTempPath();
                                string tempFile = Path.Combine(tempPath, Context.Setting.General.Icon);
                                using (FileStream fileStream = new FileStream(tempFile, FileMode.Create, FileAccess.Write))
                                {
                                    memImage.CopyTo(fileStream);
                                }
                                platform.SetWindowIcon(tempFile);
                            }
                        }
                    }
                }
            }
            else
            {
                platform.SetWindowIcon(iconPath);
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
            bool running = platform.PollEvents();
            if (!running)
            {
                Context.Exit();
            }
            
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey>();
            DateTime now = DateTime.UtcNow;
            foreach (ConsoleKey k in allKeys)
            {
                if (platform.IsKeyDown(k))
                    newKeys.Add(k);
            }
            // Detectar eventos
            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>(newKeys);
            pressedKeys.ExceptWith(currentKeys); // Press: nuevas pulsaciones
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey>(newKeys);
            heldKeys.IntersectWith(currentKeys); // Hold: mantenidas
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey>(currentKeys);
            releasedKeys.ExceptWith(newKeys); // Release: soltadas

            // Actualizar timestamps y crear KeyEventInfo
            foreach (ConsoleKey k in pressedKeys)
            {
                keyDownTimestamps[k] = now;
            }
            foreach (ConsoleKey k in releasedKeys)
            {
                keyDownTimestamps.TryGetValue(k, out DateTime downTime);
                keyDownTimestamps.Remove(k);
            }

            GameObjectQueryEnumerator.QueryEnumerable result = Context.SceneManager.CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnPressKey).IsAssignableFrom(componentType))
                    {
                        IOnPressKey onPressKey = (IOnPressKey)gameObject.Get(componentType);
                        foreach (ConsoleKey k in pressedKeys)
                        {
                            KeyEventInfo info = new KeyEventInfo(k, now, TimeSpan.Zero);
                            onPressKey.OnPressKey(info);
                        }
                    }
                    if (typeof(IOnHoldKey).IsAssignableFrom(componentType))
                    {
                        IOnHoldKey onHoldKey = (IOnHoldKey)gameObject.Get(componentType);
                        foreach (ConsoleKey k in heldKeys)
                        {
                            keyDownTimestamps.TryGetValue(k, out DateTime downTime);
                            KeyEventInfo info = new KeyEventInfo(k, now, now - downTime);
                            onHoldKey.OnHoldKey(info);
                        }
                    }
                    if (typeof(IOnReleaseKey).IsAssignableFrom(componentType))
                    {
                        IOnReleaseKey onReleaseKey = (IOnReleaseKey)gameObject.Get(componentType);
                        foreach (ConsoleKey k in releasedKeys)
                        {
                            keyDownTimestamps.TryGetValue(k, out DateTime downTime);
                            KeyEventInfo info = new KeyEventInfo(k, now, now - downTime);
                            onReleaseKey.OnReleaseKey(info);
                        }
                    }
                }
            }

            // Actualizar los estados para el siguiente frame
            previousKeys = new HashSet<ConsoleKey>(currentKeys);
            currentKeys = newKeys;

            float pixelsPerMeter = PixelsPerMeter;
            Setting contextSetting = Context.Setting;
            PhysicSetting physicSettings = contextSetting.Physic;
            Color backgrounColor = contextSetting.Graphic.BackgroundColor;

            //Glfw.PollEvents();

            // Set the clear color (convert from 0-255 range to 0.0-1.0 range)
            Gl.GlClearColor(backgrounColor.R / 255.0f, backgrounColor.G / 255.0f, backgrounColor.B / 255.0f, backgrounColor.A / 255.0f);

            // Clear the screen
            Gl.GlClear(ClearBufferMask.ColorBufferBit);

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

            // Swap the buffers to display the triangle
            //Glfw.SwapBuffers(Window);

            platform.SwapBuffers();
            int glError = Gl.GlGetError();
            if (glError != 0)
            {
                Logger.Info($"OpenGL error tras flushBuffer: 0x{glError:X}");
            }
        }
    }
}