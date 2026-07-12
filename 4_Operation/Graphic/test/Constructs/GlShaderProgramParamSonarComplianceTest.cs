// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderProgramParamSonarComplianceTest.cs
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
using Alis.Core.Graphic.OpenGL.Constructs;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     Regression tests preventing SonarCloud S1186 (empty methods) from reappearing.
    /// </summary>
    public class GlShaderProgramParamSonarComplianceTest
    {
        /// <summary>
        ///     Tests that EnsureType method exists and is accessible.
        /// </summary>
        [Fact]
        public void EnsureType_Method_Exists()
        {
            Type paramType = typeof(GlShaderProgramParam);
            MethodInfo method = paramType.GetMethod("EnsureType", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Tests that EnsureType method body is not empty.
        /// </summary>
        [Fact]
        public void EnsureType_MethodBody_NotEmpty()
        {
            Type paramType = typeof(GlShaderProgramParam);
            MethodInfo method = paramType.GetMethod("EnsureType", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(method);
            MethodBody body = method.GetMethodBody();
            Assert.NotNull(body);
            Assert.NotEmpty(body.GetILAsByteArray());
        }
    }
}
