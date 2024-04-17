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

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The video game class
    /// </summary>
    /// <seealso cref="AGame" />
    public sealed class VideoGame : AGame
    {
        /// <summary>
        /// Gets or sets the value of the context
        /// </summary>
        private new Context Context { get => (Context)base.Context; set => base.Context = value; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class
        /// </summary>
        /// <param name="settings">The settings</param>
        /// <param name="audioManager">The audio manager</param>
        /// <param name="graphicManager">The graphic manager</param>
        /// <param name="inputManager">The input manager</param>
        /// <param name="networkManager">The network manager</param>
        /// <param name="physicManager">The physic manager</param>
        /// <param name="profileManager">The profile manager</param>
        /// <param name="sceneManager">The scene manager</param>
        /// <param name="context">The context</param>
        /// <param name="managers">The managers</param>
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
            Context = context;
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
        
        /// <summary>
        /// Gets or sets the value of the settings
        /// </summary>
        public Settings Settings { get => Context.Settings; set => Context.Settings = value; }
        
        /// <summary>
        /// Sets the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public new void Set<T>(T component) where T : Manager
        {
            component.SetContext(Context);
            Managers[typeof(T)] = component;
        }
        
        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Builder() => new VideoGameBuilder();
    }
}