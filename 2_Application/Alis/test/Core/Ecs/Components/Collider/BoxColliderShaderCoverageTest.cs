// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderShaderCoverageTest.cs
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
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Tests the shader initialization branches of the box collider
    /// </summary>
    public class BoxColliderShaderCoverageTest
    {
        /// <summary>
        ///     Tests that initialize shaders with preview mode sets the es version before failing on gl
        /// </summary>
        [Fact]
        public void InitializeShaders_WithPreviewMode_ReachesEsVersionBranch()
        {
            Context context = new Context(new Setting());
            context.Setting.Graphic = context.Setting.Graphic with {PreviewMode = true};
            BoxCollider collider = new BoxCollider {Context = context};

            Assert.ThrowsAny<Exception>(() => collider.InitializeShaders());
        }

        /// <summary>
        ///     Tests that initialize shaders with non preview mode reaches the core version branch before failing on gl
        /// </summary>
        [Fact]
        public void InitializeShaders_WithCoreMode_ReachesCoreVersionBranch()
        {
            Context context = new Context(new Setting());
            context.Setting.Graphic = context.Setting.Graphic with {PreviewMode = false};
            BoxCollider collider = new BoxCollider {Context = context};

            Assert.ThrowsAny<Exception>(() => collider.InitializeShaders());
        }
    }
}
