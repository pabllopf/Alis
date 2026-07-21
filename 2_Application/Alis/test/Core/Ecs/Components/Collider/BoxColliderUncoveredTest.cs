// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderUncoveredTest.cs
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
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    public class BoxColliderUncoveredTest
    {
        [Fact]
        public void OnCollision_CalledOnScene_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Transform(new Vector2F(0f, 0f), 0f));
            BoxCollider collider = new BoxCollider();
            go.Add<BoxCollider>(collider);
        }

        [Fact]
        public void OnSeparation_CalledOnScene_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Transform(new Vector2F(0f, 0f), 0f));
            BoxCollider collider = new BoxCollider();
            go.Add<BoxCollider>(collider);
        }

        [Fact]
        public void RenderBoxCollider_WithoutGl_ThrowsException()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Transform(new Vector2F(0f, 0f), 0f));
            BoxCollider collider = new BoxCollider();

            typeof(BoxCollider)
                .GetField("IsInit", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(collider, true);

            Exception exception = Record.Exception(() =>
                collider.RenderBoxCollider(gameObject, Vector2F.Zero, new Vector2F(1920f, 1080f), 100f));

            Assert.NotNull(exception);
        }
    }
}
