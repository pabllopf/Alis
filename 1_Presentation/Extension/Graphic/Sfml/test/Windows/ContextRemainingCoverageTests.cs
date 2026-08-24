// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Coverage tests for the <see cref="Context"/> settings and description members.
    /// </summary>
    public class ContextRemainingCoverageTests
    {
        /// <summary>
        /// Tests that the creation settings are readable
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Settings_IsReadable()
        {
            Context context = new Context();
            try
            {
                Assert.NotNull(context.Settings);
            }
            finally
            {
                System.GC.SuppressFinalize(context);
            }
        }

        /// <summary>
        /// Tests that the string description identifies a context
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_IdentifiesContext()
        {
            Context context = new Context();
            try
            {
                Assert.Equal("[Context]", context.ToString());
            }
            finally
            {
                System.GC.SuppressFinalize(context);
            }
        }

        /// <summary>
        /// Tests that the finalizer destroys the native context without crashing
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Finalizer_DestroysNativeContext()
        {
            Context context = new Context();
            context.SetActive(false);
            context = null;
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
        }
    }
}