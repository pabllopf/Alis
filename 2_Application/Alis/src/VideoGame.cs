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

using Alis.Builder.Core.Ecs.System;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Profile;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;

namespace Alis
{
    /// <summary>
    ///     The video game class
    /// </summary>
    /// <seealso cref="Game" />
    public sealed class VideoGame : Game
    {
        public VideoGame(
            Settings settings,
            AudioManager audioManager,
            GraphicManager graphicManager,
            InputManager inputManager,
            NetworkManager networkManager,
            PhysicManager physicManager,
            ProfileManager profileManager,
            SceneManager sceneManager,
            Context context = null,
            params Manager[] managers) : base(managers)
        {
            context ??= new Context(this, settings);
            this.Context = context;
            audioManager.SetContext(context);
            graphicManager.SetContext(context);
            inputManager.SetContext(context);
            networkManager.SetContext(context);
            physicManager.SetContext(context);
            profileManager.SetContext(context);
            sceneManager.SetContext(context);
            foreach (Manager manager in managers)
            {
                manager.SetContext(this.Context);
            }
            
            Add(audioManager);
            Add(graphicManager);
            Add(inputManager);
            Add(networkManager);
            Add(physicManager);
            Add(profileManager);
            Add(sceneManager);
        }
        
        public AudioManager AudioManager => Context.AudioManager;
        
        public GraphicManager GraphicManager => Context.GraphicManager;
        
        public InputManager InputManager => Context.InputManager;
        
        public NetworkManager NetworkManager => Context.NetworkManager;
        
        public PhysicManager PhysicManager => Context.PhysicManager;
        
        public ProfileManager ProfileManager => Context.ProfileManager;
        
        public SceneManager SceneManager => Context.SceneManager;
        
        public Settings Settings
        {
            set => Context.Settings = value;
            get => Context.Settings;
        }
        
        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Builder() => new VideoGameBuilder();
    }
}