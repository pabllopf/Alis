// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Context.cs
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

using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.System;
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
    public class Context : IContext
    {
        private readonly VideoGame videoGame;
        
        public Context(VideoGame videoGame, Settings settings)
        {
            this.videoGame = videoGame;
            Settings = settings;
        }
        
        public AudioManager AudioManager => videoGame.Find<AudioManager>();
        
        public GraphicManager GraphicManager => videoGame.Find<GraphicManager>();
        
        public InputManager InputManager => videoGame.Find<InputManager>();
        
        public NetworkManager NetworkManager => videoGame.Find<NetworkManager>();
        
        public PhysicManager PhysicManager => videoGame.Find<PhysicManager>();
        
        public ProfileManager ProfileManager => videoGame.Find<ProfileManager>();
        
        public SceneManager SceneManager => videoGame.Find<SceneManager>();
        
        public Settings Settings { get; internal set; }
        
        public TimeManager TimeManager => videoGame.TimeManager;
        
        public void Exit() => videoGame.Exit();
    }
}