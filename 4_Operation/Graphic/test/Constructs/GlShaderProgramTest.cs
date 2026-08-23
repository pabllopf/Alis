// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderProgramTest.cs
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
using Alis.Core.Graphic.OpenGL.Constructs;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     Tests for the GlShaderProgram class handling shader compilation and linking.
    /// </summary>
    public class GlShaderProgramTest
    {
        /// <summary>
        ///     Tests that GlShaderProgram class is sealed.
        /// </summary>
        [Fact]
        public void GlShaderProgram_IsSealed_CannotBeInherited()
        {
            Type programType = typeof(GlShaderProgram);

            Assert.True(programType.IsSealed);
        }

        /// <summary>
        ///     Tests that GlShaderProgram class is public.
        /// </summary>
        [Fact]
        public void GlShaderProgram_IsPublic_CanBeAccessed()
        {
            Type programType = typeof(GlShaderProgram);

            Assert.True(programType.IsPublic);
        }

        /// <summary>
        ///     Tests that GlShaderProgram implements IDisposable interface.
        /// </summary>
        [Fact]
        public void GlShaderProgram_ImplementsIDisposable_InterfaceIsCorrect()
        {
            Type programType = typeof(GlShaderProgram);

            Assert.True(typeof(IDisposable).IsAssignableFrom(programType));
        }

    }
}