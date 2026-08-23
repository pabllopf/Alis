// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateTests.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Test.Models;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Additional coverage tests for <c>Update.cs</c> runner classes.
    ///     Targets the remaining uncovered lines including arity 8 range-based Run.
    /// </summary>
    public class UpdateTests
    {
        #region Arity 8 Range Run via Direct Archetype Access

      
       

        #endregion
    }

    #region Test Components

    /// <summary>
    ///     Component for testing arity 8 Update
    /// </summary>
    internal struct Update8Comp : IOnUpdate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>
    {
        /// <summary>
        ///     The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        ///     Updates the self with all 8 arguments
        /// </summary>
        public void Update(IGameObject self, ref Position pos, ref Velocity vel, ref Health health,
            ref Armor armor, ref Damage damage, ref Transform transform, ref TestComponent test, ref AnotherComponent another)
        {
            CallCount++;
            pos.X += vel.X;
            pos.Y += vel.Y;
            health.Value -= damage.Value;
            armor.Value = armor.Value + damage.Value + 1;
            damage.Value += 1;
            transform.Rotation += 2;
            test.Value += test.Value;
            another.Data += 1;
            another.Y += 1;
        }
    }

    #endregion
}
