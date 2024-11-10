// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AComponent.cs
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
using System.Runtime.Serialization;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;

namespace Alis.Core.Ecs.Component
{
    /// <summary>
    ///     The component class
    /// </summary>
    /// <seealso cref="IComponent{GameObject}" />
    /// <seealso cref="ISerializable" />
    public abstract class AComponent : IComponent<GameObject>
    {
        /// <summary>
        ///     Gets or sets the value of the game object
        /// </summary>
        [JsonPropertyName("_Context_", true, true)]
        public Context Context => GameObject.Context;

        /// <summary>
        ///     Gets or sets the value of the is enable
        /// </summary>
        [JsonPropertyName("_IsEnable_")]
        public bool IsEnable { get; set; } = true;

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        [JsonPropertyName("_Name_")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the value of the id
        /// </summary>
        [JsonPropertyName("_Id_")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        ///     Gets or sets the value of the tag
        /// </summary>
        [JsonPropertyName("_Tag_")]
        public string Tag { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the value of the game object
        /// </summary>
        [JsonPropertyName("_GameObject_", true, true)]
        public GameObject GameObject { get; set; }

        /// <summary>
        ///     Ons the enable
        /// </summary>
        public virtual void OnEnable() => Logger.Trace();

        /// <summary>
        ///     Ons the init
        /// </summary>
        public virtual void OnInit() => Logger.Trace();

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public virtual void OnAwake() => Logger.Trace();

        /// <summary>
        ///     Ons the start
        /// </summary>
        public virtual void OnStart() => Logger.Trace();

        /// <summary>
        /// Ons the physic update
        /// </summary>
        public virtual void OnPhysicUpdate()=> Logger.Trace();

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public virtual void OnBeforeUpdate() => Logger.Trace();

        /// <summary>
        ///     Ons the update
        /// </summary>
        public virtual void OnUpdate() => Logger.Trace();

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public virtual void OnAfterUpdate() => Logger.Trace();

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public virtual void OnBeforeFixedUpdate() => Logger.Trace();

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public virtual void OnFixedUpdate() => Logger.Trace();

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public virtual void OnAfterFixedUpdate() => Logger.Trace();

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public virtual void OnDispatchEvents() => Logger.Trace();

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public virtual void OnCalculate() => Logger.Trace();

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public virtual void OnDraw() => Logger.Trace();

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public virtual void OnGui() => Logger.Trace();

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public virtual void OnDisable() => Logger.Trace();

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public virtual void OnReset() => Logger.Trace();

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public virtual void OnStop() => Logger.Trace();

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public virtual void OnExit() => Logger.Trace();

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public virtual void OnDestroy() => Logger.Trace();

        /// <summary>
        ///     Attaches the game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void Attach(GameObject gameObject) => GameObject = gameObject;

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public virtual void OnPressDownKey(KeyCodes key) => Logger.Trace();

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public virtual void OnReleaseKey(KeyCodes key) => Logger.Trace();

        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public virtual void OnPressKey(KeyCodes key) => Logger.Trace();

        /// <summary>
        ///     Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public virtual void OnCollisionEnter(GameObject gameObject) => Logger.Trace();

        /// <summary>
        ///     Ons the collision exit using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public virtual void OnCollisionExit(GameObject gameObject) => Logger.Trace();

        /// <summary>
        ///     Ons the collision stay using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public virtual void OnCollisionStay(GameObject gameObject) => Logger.Trace();

        /// <summary>
        ///     Ons the trigger enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public virtual void OnTriggerEnter(GameObject gameObject) => Logger.Trace();

        /// <summary>
        ///     Ons the trigger exit using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public virtual void OnTriggerExit(GameObject gameObject) => Logger.Trace();

        /// <summary>
        ///     Ons the trigger stay using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public virtual void OnTriggerStay(GameObject gameObject) => Logger.Trace();
    }
}