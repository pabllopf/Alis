// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectExtensionsTests.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Helpers;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The gameObject extensions tests class
    /// </summary>
    public class GameObjectExtensionsTests
    {
        /// <summary>
        ///     Tests that deconstruct deconstructs gameObject
        /// </summary>
        [Fact]
        public void Deconstruct_DeconstructsEntity()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(new Class1(), new Struct1(), 1, 2.0, "3");

                e.Deconstruct(
                    out Ref<Class1> class1,
                    out Ref<Struct1> struct1,
                    out Ref<int> int1,
                    out Ref<double> double1,
                    out Ref<string> string1);

                Assert.Equal(e.Get<Class1>(), class1.Value);
                Assert.Equal(e.Get<Struct1>(), struct1.Value);
                Assert.Equal(e.Get<int>(), int1.Value);
                Assert.Equal(e.Get<double>(), double1.Value);
                Assert.Equal(e.Get<string>(), string1.Value);
            }
        }

        /// <summary>
        ///     Tests that deconstruct null ref exception
        /// </summary>
        [Fact]
        public void Deconstruct_NullRefException()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(new Class1(), new Struct1(), 1, 2.0, "3");

                Assert.Throws<NullReferenceException>(() => e.Deconstruct(out Ref<Class2> _));
            }
        }
    }
}