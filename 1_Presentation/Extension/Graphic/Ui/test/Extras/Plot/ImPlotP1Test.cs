// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP1Test.cs
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
using System.Linq;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Test.Attributes;

// Type alias to disambiguate between Alis.Extension.Graphic.Ui.ImGuiDragDropFlags and Alis.Extension.Graphic.Ui.Extras.Plot.ImGuiDragDropFlags
using DragDropFlags = Alis.Extension.Graphic.Ui.Extras.Plot.ImGuiDragDropFlags;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides focused unit coverage for API members implemented in <c>ImPlotP1.cs</c>.
    /// </summary>
    public class ImPlotP1Test
    {

        /// <summary>
        /// Tests that begin drag drop target methods should expose expected overloads
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginDragDropTargetMethods_ShouldExposeExpectedOverloads()
        {
            Assert.NotNull(GetPublicStaticMethod("BeginDragDropTargetAxis", new[] { typeof(ImAxis) }));
            Assert.NotNull(GetPublicStaticMethod("BeginDragDropTargetLegend", Type.EmptyTypes));
            Assert.NotNull(GetPublicStaticMethod("BeginDragDropTargetPlot", Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that void no parameter methods should exist
        /// </summary>
        [RequireImNodesSystemFact]
        public void VoidNoParameterMethods_ShouldExist()
        {
            Assert.NotNull(GetPublicStaticMethod("CancelPlotSelection", Type.EmptyTypes));
            Assert.NotNull(GetPublicStaticMethod("EndAlignedPlots", Type.EmptyTypes));
            Assert.NotNull(GetPublicStaticMethod("EndDragDropSource", Type.EmptyTypes));
            Assert.NotNull(GetPublicStaticMethod("ColormapIcon", new[] { typeof(ImPlotColormap) }));
        }

        /// <summary>
        /// Gets the public static method using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="parameterTypes">The parameter types</param>
        /// <returns>The method info</returns>
        private static MethodInfo GetPublicStaticMethod(string name, Type[] parameterTypes)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(method =>
                {
                    if (method.Name != name)
                    {
                        return false;
                    }
                    ParameterInfo[] parameters = method.GetParameters();
                    if (parameters.Length != parameterTypes.Length)
                    {
                        return false;
                    }
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (parameters[i].ParameterType != parameterTypes[i])
                        {
                            return false;
                        }
                    }
                    return true;
                });
        }

        /// <summary>
        /// Gets the public static methods using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The method info array</returns>
        private static MethodInfo[] GetPublicStaticMethods(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name)
                .ToArray();
        }

        /// <summary>
        /// Gets the public static method using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The method info</returns>
        private static MethodInfo GetPublicStaticMethod(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(method => method.Name == name);
        }
    }
}
