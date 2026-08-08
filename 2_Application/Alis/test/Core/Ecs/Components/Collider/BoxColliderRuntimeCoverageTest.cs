// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderRuntimeCoverageTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Tests runtime coverage for <see cref="BoxCollider" /> using real ECS and physics objects.
    /// </summary>
    public class BoxColliderRuntimeCoverageTest
    {
        /// <summary>
        ///     Verifies that the settings-based constructor copies every value to the collider.
        /// </summary>
        [Fact]
        public void BoxCollider_BoxColliderSettings_Constructor_ShouldCopyAllValues()
        {
            BoxCollider.BoxColliderSettings settings = new BoxCollider.BoxColliderSettings(
                true,
                12f,
                24f,
                0.75f,
                new Vector2F(1f, -3f),
                true,
                BodyType.Dynamic,
                0.2f,
                0.4f,
                true,
                9f,
                true,
                new Vector2F(5f, 6f),
                7f);

            BoxCollider collider = new BoxCollider(settings);

            Assert.True(collider.IsTrigger);
            Assert.Equal(12f, collider.Width, 5);
            Assert.Equal(24f, collider.Height, 5);
            Assert.Equal(0.75f, collider.Rotation, 5);
            Assert.Equal(new Vector2F(1f, -3f), collider.RelativePosition);
            Assert.True(collider.AutoTilling);
            Assert.Equal(BodyType.Dynamic, collider.BodyType);
            Assert.Equal(0.2f, collider.Restitution, 5);
            Assert.Equal(0.4f, collider.Friction, 5);
            Assert.True(collider.FixedRotation);
            Assert.Equal(9f, collider.Mass, 5);
            Assert.True(collider.IgnoreGravity);
            Assert.Equal(new Vector2F(5f, 6f), collider.LinearVelocity);
            Assert.Equal(7f, collider.AngularVelocity, 5);
        }
        
    }
}
