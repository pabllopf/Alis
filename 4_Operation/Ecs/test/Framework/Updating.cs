// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Updating.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Helpers;
using Xunit;

namespace Alis.Core.Ecs.Test.Framework
{
    /// <summary>
    ///     The updating class
    /// </summary>
    public class Updating
    {
        /// <summary>
        ///     Tests that component filter updates single component
        /// </summary>
        [Fact]
        public void ComponentFilter_UpdatesSingleComponent()
        {
            using (Scene scene = new Scene())
            {
                int count = 0;

                scene.Create(0f, 0, new DelegateBehavior(() => count++));
                scene.Create(0f, 0, new DelegateBehavior(() => count++));
                scene.Create(new DelegateBehavior(() => count++));

                scene.Create(new DelegateBehavior(() => count++), new FilteredBehavior1(() => count++));

                scene.Create(0, new FilteredBehavior1(() => count++));

                scene.UpdateComponent(Component<DelegateBehavior>.Id);

                Assert.Equal(4, count);

                scene.UpdateComponent(Component<DelegateBehavior>.Id);

                Assert.Equal(8, count);

                scene.UpdateComponent(Component<FilteredBehavior1>.Id);

                Assert.Equal(10, count);
            }
        }

        /// <summary>
        ///     Tests that update updates components
        /// </summary>
        [Fact]
        public void Update_UpdatesComponents()
        {
            using (Scene scene = new Scene())
            {
                int count = 0;
                for (int i = 0; i < 10; i++)
                {
                    scene.Create<int, float, DelegateBehavior>(default(int), default(float), new DelegateBehavior(() => count++));
                }

                scene.Update();

                Assert.Equal(10, count);
            }
        }

        /// <summary>
        ///     Tests that update filters components
        /// </summary>
        [Fact]
        public void Update_FiltersComponents()
        {
            using (Scene scene = new Scene())
            {
                int count = 0;
                for (int i = 0; i < 10; i++)
                {
                    scene.Create<int, float, FilteredBehavior1>(default(int), default(float), new FilteredBehavior1(() => count++));
                }

                for (int i = 0; i < 10; i++)
                {
                    scene.Create<int, float, FilteredBehavior2>(default(int), default(float), new FilteredBehavior2(() => count++));
                }

                scene.Update<FilterAttribute1>();

                Assert.Equal(10, count);

                scene.Update<FilterAttribute2>();

                Assert.Equal(20, count);
            }
        }

        /// <summary>
        ///     Tests that update register late filters components
        /// </summary>
        [Fact]
        public void Update_RegisterLate_FiltersComponents()
        {
            int count = 0;

            using (Scene scene = new Scene())
            {
                scene.Update<FilterAttribute1>();

                for (int i = 0; i < 10; i++)
                {
                    scene.Create(new LazyComponent<int>(() => count++));
                    scene.Create(new FilteredBehavior2(() => count++));
                }

                scene.Update<FilterAttribute1>();
                Assert.Equal(10, count);

                for (int i = 0; i < 10; i++)
                {
                    scene.Create(new LazyComponent<double>(() => count++));
                    scene.Create(new FilteredBehavior2(() => count++));
                }

                scene.Update<FilterAttribute1>();
                Assert.Equal(30, count);
            }
        }


        /// <summary>
        ///     Tests that update deferred gameObject creation update updates deferred entities
        /// </summary>
        [Fact]
        public void Update_DeferredEntityCreationUpdate_UpdatesDeferredEntities()
        {
            int count = 0;

            using (Scene scene = new Scene())
            {
                scene.Create(new DelegateBehavior(() => { scene.Create(new DelegateBehavior(() => { count++; })); }));

                scene.Update();

                Assert.Equal(1, count);

                scene.Update();

                Assert.Equal(3, count);
            }
        }

        /// <summary>
        ///     Tests that update deferred gameObject creation update hits recursion limit
        /// </summary>
        [Fact]
        public void Update_DeferredEntityCreationUpdate_HitsRecursionLimit()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new DelegateBehavior(() => { Create(); }));

                Assert.Throws<InvalidOperationException>(() => scene.Update());

                void Create()
                {
                    scene.Create(new DelegateBehavior(() => { Create(); }));
                }
            }
        }

        /// <summary>
        ///     Tests that update filtered deferred gameObject creation update updates deferred entities
        /// </summary>
        [Fact]
        public void Update_FilteredDeferredEntityCreationUpdate_UpdatesDeferredEntities()
        {
            int count = 0;

            using (Scene scene = new Scene())
            {
                scene.Create(new FilteredBehavior1(() => { scene.Create(new FilteredBehavior1(() => { count++; })); }));

                scene.Update<FilterAttribute1>();

                Assert.Equal(1, count);

                scene.Update<FilterAttribute1>();

                Assert.Equal(3, count);
            }
        }
    }

    /// <summary>
    ///     The lazy component
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct LazyComponent<T>(Action a) : IComponent
    {
        /// <summary>
        ///     Updates this instance
        /// </summary>
        [FilterAttribute1]
        public void Update() => a();
    }
}