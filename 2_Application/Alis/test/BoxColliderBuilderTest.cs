// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The box collider builder test class
    /// </summary>
    public class BoxColliderBuilderTest
    {
        /// <summary>
        /// Tests that constructor with context creates builder
        /// </summary>
        [Fact]
        public void Constructor_WithContext_CreatesBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns box collider instance
        /// </summary>
        [Fact]
        public void Build_ReturnsBoxColliderInstance()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxCollider boxCollider = builder.Build();
            Assert.NotNull(boxCollider);
        }

        /// <summary>
        /// Tests that angular velocity sets value returns builder
        /// </summary>
        [Fact]
        public void AngularVelocity_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.AngularVelocity(1.5f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that auto tilling sets value returns builder
        /// </summary>
        [Fact]
        public void AutoTilling_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.AutoTilling(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that body type sets value returns builder
        /// </summary>
        [Fact]
        public void BodyType_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.BodyType(BodyType.Dynamic);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that fixed rotation sets value returns builder
        /// </summary>
        [Fact]
        public void FixedRotation_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.FixedRotation(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that friction sets value returns builder
        /// </summary>
        [Fact]
        public void Friction_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.Friction(0.5f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that is active returns builder
        /// </summary>
        [Fact]
        public void IsActive_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.IsActive(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that is trigger returns builder
        /// </summary>
        [Fact]
        public void IsTrigger_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.IsTrigger(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that mass sets value returns builder
        /// </summary>
        [Fact]
        public void Mass_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.Mass(10f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that restitution sets value returns builder
        /// </summary>
        [Fact]
        public void Restitution_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.Restitution(0.8f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that rotation sets value returns builder
        /// </summary>
        [Fact]
        public void Rotation_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.Rotation(45f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that size sets value returns builder
        /// </summary>
        [Fact]
        public void Size_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.Size(2f, 3f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that linear velocity sets value returns builder
        /// </summary>
        [Fact]
        public void LinearVelocity_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.LinearVelocity(1f, 2f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that relative position sets value returns builder
        /// </summary>
        [Fact]
        public void RelativePosition_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.RelativePosition(0.5f, 0.5f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that ignore gravity sets value returns builder
        /// </summary>
        [Fact]
        public void IgnoreGravity_SetsValue_ReturnsBuilder()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxColliderBuilder result = builder.IgnoreGravity(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that chaining all properties creates box collider
        /// </summary>
        [Fact]
        public void ChainingAllProperties_CreatesBoxCollider()
        {
            Context context = new Context();
            BoxColliderBuilder builder = new BoxColliderBuilder(context);
            BoxCollider boxCollider = builder
                .BodyType(BodyType.Dynamic)
                .AngularVelocity(0f)
                .Friction(0.5f)
                .Restitution(0.2f)
                .Mass(5f)
                .Size(1f, 1f)
                .IsTrigger(false)
                .Build();
            Assert.NotNull(boxCollider);
        }
    }
}
