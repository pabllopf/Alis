// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Lifetime.cs
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Test.Helpers;
using Xunit;

namespace Alis.Core.Ecs.Test.Framework
{
    /// <summary>
    ///     The lifetime class
    /// </summary>
    public class Lifetime
    {
        /// <summary>
        ///     The destroy action
        /// </summary>
        private readonly Action destroyAction;

        /// <summary>
        ///     The destroy component action
        /// </summary>
        private readonly Action<IGameObject> destroyComponentAction;

        /// <summary>
        ///     The init action
        /// </summary>
        private readonly Action<IGameObject> initAction;

        /// <summary>
        ///     The init component action
        /// </summary>
        private readonly Action<IGameObject> initComponentAction;

        // Delegados reutilizables para los tests
        /// <summary>
        ///     The destroy count
        /// </summary>
        private int destroyCount;

        /// <summary>
        ///     The destroy flag
        /// </summary>
        private bool destroyFlag;

        /// <summary>
        ///     The
        /// </summary>
        private IGameObject e1;

        /// <summary>
        ///     The init flag
        /// </summary>
        private bool initFlag;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Lifetime" /> class
        /// </summary>
        public Lifetime()
        {
            destroyAction = () => destroyCount++;
            initAction = e => e1 = e;
            initComponentAction = e => initFlag = true;
            destroyComponentAction = e => destroyFlag = true;
        }
        
        /// <summary>
        ///     Tests that lifetime called add remove
        /// </summary>
        [Fact]
        public void LifetimeCalled_AddRemove()
        {
            using (Scene scene = new Scene())
            {
                TestForLifetimeInvocation(scene, (w, c) =>
                {
                    GameObject e = w.Create();
                    e.Add(c);
                    e.Remove<LifetimeComponent>();
                });
            }
        }

        /// <summary>
        ///     Tests that lifetime called create delete
        /// </summary>
        [Fact]
        public void LifetimeCalled_CreateDelete()
        {
            using (Scene scene = new Scene())
            {
                TestForLifetimeInvocation(scene, (w, c) =>
                {
                    GameObject e = w.Create(c);
                    e.Delete();
                });
            }
        }

        /// <summary>
        ///     Tests the for lifetime invocation using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="action">The action</param>
        private void TestForLifetimeInvocation(Scene scene, Action<Scene, LifetimeComponent> action)
        {
            initFlag = false;
            destroyFlag = false;
            action(scene, new LifetimeComponent(initComponentAction, destroyComponentAction));
            Assert.True(initFlag);
            Assert.True(destroyFlag);
        }

        /// <summary>
        ///     The lifetime component
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LifetimeComponent(Action<IGameObject> init, Action<IGameObject> destroy) : IOnInit, IOnDestroy
        {
            /// <summary>
            ///     The self
            /// </summary>
            private IGameObject _self;

            /// <summary>
            ///     Inits the self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnInit(IGameObject self) => init?.Invoke(_self = self);

            /// <summary>
            ///     Destroys this instance
            /// </summary>
            public void OnDestroy() => destroy?.Invoke(_self);
        }
    }
}