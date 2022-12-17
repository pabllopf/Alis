// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGame.cs
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
using System.Linq;
using System.Reflection;
using Alis.Builder;
using Alis.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Manager;
using Alis.Core.Manager.Audio;
using Alis.Core.Manager.Graphic;
using Alis.Core.Manager.Input;
using Alis.Core.Manager.Physic;
using Alis.Core.Manager.Scene;
using Alis.Core.Manager.Setting;

namespace Alis
{
    /// <summary>
    ///     The video game class
    /// </summary>
    /// <seealso cref="GameBase" />
    public class VideoGame : GameBase
    {
        /// <summary>
        ///     Video game
        /// </summary>
        public VideoGame()
        { 
            //EmbeddedDllClass.ExtractEmbeddedDlls("libcsfml-graphics.dylib");
            
            PhysicManager = new PhysicManager();
            GraphicManager = new GraphicManager();
            SceneManager = new SceneManager();
            AudioManager = new AudioManager();
            InputManager = new InputManager();

            Managers = new List<ManagerBase>
            {
                PhysicManager,
                GraphicManager,
                SceneManager,
                AudioManager,
                InputManager
            };
            
            Logger.Trace();
        }


        /*private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            Console.WriteLine("TRY TO LOAD");
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            AssemblyName asembly = new AssemblyName(args.Name);
            string requireDllName = $"{asembly.Name}.dylib";
            string resource = currentAssembly.GetManifestResourceNames().FirstOrDefault(i => i.EndsWith(requireDllName));

            if (resource != null)
            {
                using (Stream stream = currentAssembly.GetManifestResourceStream(resource))
                {
                    if (stream == null)
                    {
                        return null;
                    }

                    byte[] block = new byte[stream.Length];
                    stream.Read(block, 0, block.Length);
                    return Assembly.Load(block);
                }
            }
            
            return null;
        }*/
        
        



        /// <summary>
        ///     Gets or sets the value of the input manager
        /// </summary>
        public static InputManager InputManager { get; set; } = new InputManager();

        /// <summary>
        ///     Gets or sets the value of the graphic manager
        /// </summary>
        public static GraphicManager GraphicManager { get; set; } = new GraphicManager();

        /// <summary>
        ///     Gets or sets the value of the scene manager
        /// </summary>
        public static SceneManager SceneManager { get; set; } = new SceneManager();

        /// <summary>
        ///     Gets the value of the audio manager
        /// </summary>
        public static AudioManager AudioManager { get; set; } = new AudioManager();

        /// <summary>
        /// Gets or sets the value of the physic manager
        /// </summary>
        public static PhysicManager PhysicManager { get; set; } = new PhysicManager();

        /// <summary>
        ///     Gets or sets the value of the setting manager
        /// </summary>
        public static SettingManager Setting { get; set; } = new SettingManager();

        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Builder() => new VideoGameBuilder();
    }
}