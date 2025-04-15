// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicManager.cs
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

using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Ecs.Systems.Manager.Physic
{
    /// <summary>
    ///     The physic manager base class
    /// </summary>
    /// <seealso cref="AManager" />
    public class PhysicManager : AManager
    {
        /// <summary>
        ///     The time step physics
        /// </summary>
        private float timeStepPhysics;

        /// <summary>
        ///     The vector
        /// </summary>
        public WorldPhysic WorldPhysic = new WorldPhysic();

        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public PhysicManager(Context context) : base(context)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="timeStepPhysics">The time step physics</param>
        public PhysicManager(Context context, float timeStepPhysics) : base(context) => this.timeStepPhysics = timeStepPhysics;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicManager" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="context">The context</param>
        /// <param name="timeStepPhysics">The time step physics</param>
        public PhysicManager(string id, string name, string tag, bool isEnable, Context context, float timeStepPhysics) : base(id, name, tag, isEnable, context) => this.timeStepPhysics = timeStepPhysics;

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            WorldPhysic = new WorldPhysic(Context.Setting.Physic.Gravity);
        }

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public override void OnAwake()
        {
            timeStepPhysics = 1f / 20f;
            if (Context.Setting.Graphic.TargetFrames <= 240)
            {
                timeStepPhysics = 1f / 80f;
            }

            if (Context.Setting.Graphic.TargetFrames <= 200)
            {
                timeStepPhysics = 1f / 60f;
            }

            if (Context.Setting.Graphic.TargetFrames <= 120)
            {
                timeStepPhysics = 1f / 40f;
            }

            if (Context.Setting.Graphic.TargetFrames <= 60)
            {
                timeStepPhysics = 1f / 30f;
            }

            if (Context.Setting.Graphic.TargetFrames <= 30)
            {
                timeStepPhysics = 1f / 15f;
            }

            if (Context.Setting.Graphic.TargetFrames <= 15)
            {
                timeStepPhysics = 1f / 10f;
            }

            if (Context.Setting.Graphic.TargetFrames <= 5)
            {
                timeStepPhysics = 1f / 5f;
            }
        }

        /// <summary>
        ///     Ons the physic update
        /// </summary>
        public override void OnPhysicUpdate()
        {
            WorldPhysic.Step(timeStepPhysics);
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (Context is null)
            {
            }
        }


        /// <summary>
        ///     Uns the attach using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        public void UnAttach(Body body)
        {
            WorldPhysic.Remove(body);
        }
    }
}