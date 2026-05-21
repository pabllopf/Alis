// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Controller.cs
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

using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Controllers
{
    /// <summary>
    ///     Abstract base class for all physics controllers.
    /// </summary>
    /// <remarks>
    ///     Controllers are specialized objects that modify the behavior of physics bodies
    ///     during simulation. They can apply forces, modify velocities, constrain motion,
    ///     or implement game-specific physics logic. Common examples include gravity controllers,
    ///     buoyancy controllers, and velocity limiters.
    ///     
    ///     Each controller belongs to a category that can be selectively enabled or disabled
    ///     for specific bodies using the controller filter system.
    /// </remarks>
    /// <example>
    ///     <code>
    ///     public class MyCustomController : Controller
    ///     {
    ///         public override void Update(float dt)
    ///         {
    ///             foreach (Body body in WorldPhysic.BodyList)
    ///             {
    ///                 if (IsActiveOn(body))
    ///                 {
    ///                     // Apply custom physics logic
    ///                 }
    ///             }
    ///         }
    ///     }
    /// </code>
    /// </example>
    /// <seealso cref="FilterData"/>
    public abstract class Controller : FilterData
    {
        /// <summary>
        ///     Gets the category this controller belongs to.
        /// </summary>
        /// <value>
        ///     A <see cref="ControllerCategory"/> value determining which bodies ignore this controller.
        /// </value>
        /// <remarks>
        ///     Bodies can be configured to ignore controllers from specific categories
        ///     using their <see cref="ControllerFilter"/>. This allows fine-grained control
        ///     over which controllers affect which bodies.
        /// </remarks>
        public readonly ControllerCategory ControllerCategory = ControllerCategory.Cat01;

        /// <summary>
        ///     Gets or sets whether this controller is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the controller is active and will be updated; <c>false</c> to disable.
        /// </value>
        /// <remarks>
        ///     When disabled, the controller's <see cref="Update(float)"/> method is not called
        ///     during simulation, effectively turning off its physics influence.
        /// </remarks>
        public bool Enabled = true;

        /// <summary>
        ///     Gets or sets the world this controller belongs to.
        /// </summary>
        /// <value>
        ///     The <see cref="WorldPhysic"/> instance this controller is registered with.
        /// </value>
        /// <remarks>
        ///     This property is automatically set when the controller is added to a world.
        ///     It provides access to the simulation world for iterating over bodies and
        ///     other physics objects.
        /// </remarks>
        public WorldPhysic WorldPhysic { get; internal set; }

        /// <summary>
        ///     Determines whether this controller should be active for the specified body.
        /// </summary>
        /// <param name="body">The body to check.</param>
        /// <returns>
        ///     <c>true</c> if the controller should be applied to the body; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        ///     This method first checks if the body has configured a controller filter to ignore
        ///     this controller's category. If not ignored, it delegates to the base implementation
        ///     for additional filtering logic.
        /// </remarks>
        public override bool IsActiveOn(Body body)
        {
            if (body.ControllerFilter.IsControllerIgnored(ControllerCategory))
            {
                return false;
            }

            return base.IsActiveOn(body);
        }

        /// <summary>
        ///     Updates the controller's state for the current simulation step.
        /// </summary>
        /// <param name="dt">
        ///     The delta time (in seconds) since the last simulation step.
        ///     This is typically the fixed timestep used for physics simulation.
        /// </param>
        /// <remarks>
        ///     This method is called once per simulation step for each enabled controller.
        ///     Override this to implement custom physics behavior such as applying forces,
        ///     modifying velocities, or constraining body motion.
        /// </remarks>
        public abstract void Update(float dt);
    }
}