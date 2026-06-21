// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicManagerTest.cs
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
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Manager.Physic;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Tests for the <see cref="PhysicManager" /> class covering constructors, properties, lifecycle methods, and error
    ///     handling.
    /// </summary>
    public class PhysicManagerTest
    {
        /// <summary>
        ///     Tests that the constructor with Context creates a PhysicManager and assigns the context.
        /// </summary>
        [Fact]
        public void Constructor_WithContext_CreatesPhysicManager()
        {
            Context context = new Context(new Setting());
            PhysicManager physicManager = context.PhysicManager;

            Assert.NotNull(physicManager);
            Assert.Same(context, physicManager.Context);
        }

        /// <summary>
        ///     Tests that the constructor with Context creates a non-null WorldPhysic.
        /// </summary>
        [Fact]
        public void Constructor_WithContext_CreatesWorldPhysic()
        {
            Context context = new Context(new Setting());
            PhysicManager physicManager = context.PhysicManager;

            Assert.NotNull(physicManager.WorldPhysic);
        }

        /// <summary>
        ///     Tests that PhysicManager inherits from AManager.
        /// </summary>
        [Fact]
        public void PhysicManager_InheritsFromAManager()
        {
            Context context = new Context(new Setting());
            PhysicManager physicManager = context.PhysicManager;

            Assert.IsAssignableFrom<AManager>(physicManager);
        }

        /// <summary>
        ///     Tests that WorldPhysic property is gettable and settable.
        /// </summary>
        [Fact]
        public void WorldPhysic_Property_GetSet()
        {
            Context context = new Context(new Setting());
            PhysicManager physicManager = context.PhysicManager;

            Assert.NotNull(physicManager.WorldPhysic);

            PhysicManager otherManager = new PhysicManager(context);

            Assert.NotNull(otherManager);
            Assert.NotSame(physicManager.WorldPhysic, otherManager.WorldPhysic);
        }

        /// <summary>
        ///     Tests that OnUpdate does not throw.
        /// </summary>
        [Fact]
        public void OnUpdate_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            PhysicManager physicManager = context.PhysicManager;

            Exception ex = Record.Exception(() => physicManager.OnUpdate());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that OnExit does not throw.
        /// </summary>
        [Fact]
        public void OnExit_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            PhysicManager physicManager = context.PhysicManager;

            Exception ex = Record.Exception(() => physicManager.OnExit());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that OnInit creates a new WorldPhysic and does not throw.
        /// </summary>
        [Fact]
        public void OnInit_CreatesWorldPhysic()
        {
            Context context = new Context(new Setting());
            PhysicManager physicManager = context.PhysicManager;

            physicManager.OnInit();

            Assert.NotNull(physicManager.WorldPhysic);
        }

        /// <summary>
        ///     Tests that OnAwake with default TargetFrames (60) allows OnPhysicUpdate to execute without throwing.
        /// </summary>
        [Fact]
        public void OnAwake_WithDefaultTargetFrames_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            PhysicManager physicManager = context.PhysicManager;

            physicManager.OnAwake();

            Exception ex = Record.Exception(() => physicManager.OnPhysicUpdate());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that OnAwake with TargetFrames above 240 uses the initial time step and OnPhysicUpdate does not throw.
        /// </summary>
        [Fact]
        public void OnAwake_WithTargetFramesAbove240_DoesNotThrow()
        {
            Setting setting = new Setting();
            GraphicSetting graphic = setting.Graphic;
            graphic.TargetFrames = 241;
            setting.Graphic = graphic;

            Context context = new Context(setting);
            PhysicManager physicManager = context.PhysicManager;

            physicManager.OnAwake();

            Exception ex = Record.Exception(() => physicManager.OnPhysicUpdate());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that OnAwake with TargetFrames at 5 hits the lowest threshold path and OnPhysicUpdate does not throw.
        /// </summary>
        [Fact]
        public void OnAwake_WithTargetFramesAt5_DoesNotThrow()
        {
            Setting setting = new Setting();
            GraphicSetting graphic = setting.Graphic;
            graphic.TargetFrames = 5;
            setting.Graphic = graphic;

            Context context = new Context(setting);
            PhysicManager physicManager = context.PhysicManager;

            physicManager.OnAwake();

            Exception ex = Record.Exception(() => physicManager.OnPhysicUpdate());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that OnAwake with TargetFrames at 120 covers the <= 120 branch and OnPhysicUpdate does not throw.
        /// </summary>
        [Fact]
        public void OnAwake_WithTargetFramesAt120_DoesNotThrow()
        {
            Setting setting = new Setting();
            GraphicSetting graphic = setting.Graphic;
            graphic.TargetFrames = 120;
            setting.Graphic = graphic;

            Context context = new Context(setting);
            PhysicManager physicManager = context.PhysicManager;

            physicManager.OnAwake();

            Exception ex = Record.Exception(() => physicManager.OnPhysicUpdate());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that UnAttach with a null body throws ArgumentNullException.
        /// </summary>
        [Fact]
        public void UnAttach_NullBody_ThrowsArgumentNullException()
        {
            Context context = new Context(new Setting());
            PhysicManager physicManager = context.PhysicManager;

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => physicManager.UnAttach(null));

            Assert.Contains("body", ex.Message);
        }
    }
}
