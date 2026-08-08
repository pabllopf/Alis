// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RectangleShapeTest.cs
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

using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The rectangle shape test class
    /// </summary>
    public class RectangleShapeTest
    {
        /// <summary>
        /// Tests that rectangle shape is assignable from shape
        /// </summary>
        [RequireCSfmlSystemFact]
        public void RectangleShape_IsAssignableFromShape()
        {
            Assert.True(typeof(Shape).IsAssignableFrom(typeof(RectangleShape)));
        }

        /// <summary>
        /// Tests that rectangle shape implements i drawable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void RectangleShape_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(RectangleShape)));
        }

        /// <summary>
        /// Tests that size property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Property_Exists()
        {
            PropertyInfo prop = typeof(RectangleShape).GetProperty("Size");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
            Assert.Equal(typeof(Vector2F), prop.PropertyType);
        }

        /// <summary>
        /// Tests that get point count method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPointCount_Method_Exists()
        {
            MethodInfo method = typeof(RectangleShape).GetMethod("GetPointCount");
            Assert.NotNull(method);
            Assert.Equal(typeof(uint), method.ReturnType);
        }

        /// <summary>
        /// Tests that get point method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_Method_Exists()
        {
            MethodInfo method = typeof(RectangleShape).GetMethod("GetPoint", new[] { typeof(uint) });
            Assert.NotNull(method);
            Assert.Equal(typeof(Vector2F), method.ReturnType);
        }
    }
}
