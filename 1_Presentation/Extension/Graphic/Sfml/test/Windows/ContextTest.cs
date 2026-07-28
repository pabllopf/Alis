// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextTest.cs
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
    /// The context test class
    /// </summary>
    public class ContextTest
    {
        /// <summary>
        /// Tests that context is assignable from critical finalizer object
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Context_IsAssignableFromCriticalFinalizerObject()
        {
            Assert.True(typeof(System.Runtime.ConstrainedExecution.CriticalFinalizerObject).IsAssignableFrom(typeof(Context)));
        }

        /// <summary>
        /// Tests that constructor creates instance
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_CreatesInstance()
        {
            Context context = new Context();
            Assert.NotNull(context);
        }

        /// <summary>
        /// Tests that settings property returns value
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Settings_ReturnsValue()
        {
            Context context = new Context();
            ContextSettings settings = context.Settings;
            Assert.NotNull(settings);
        }

        /// <summary>
        /// Tests that settings property exists
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Settings_Property_Exists()
        {
            Assert.NotNull(typeof(Context).GetProperty("Settings"));
        }

        /// <summary>
        /// Tests that global property exists
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Global_Property_Exists()
        {
            System.Reflection.PropertyInfo prop = typeof(Context).GetProperty("Global");
            Assert.NotNull(prop);
            Assert.True(prop.GetMethod.IsStatic);
        }

        /// <summary>
        /// Tests that global returns instance
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Global_ReturnsInstance()
        {
            Context global = Context.Global;
            Assert.NotNull(global);
        }

        /// <summary>
        /// Tests that global returns same instance
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Global_ReturnsSameInstance()
        {
            Context g1 = Context.Global;
            Context g2 = Context.Global;
            Assert.Same(g1, g2);
        }

        /// <summary>
        /// Tests that set active method exists
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetActive_Method_Exists()
        {
            Assert.NotNull(typeof(Context).GetMethod("SetActive"));
        }

        /// <summary>
        /// Tests that set active with true returns bool
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetActive_True_ReturnsBool()
        {
            Context context = new Context();
            bool result = context.SetActive(true);
            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that set active with false returns bool
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetActive_False_ReturnsBool()
        {
            Context context = new Context();
            bool result = context.SetActive(false);
            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that to string returns expected
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReturnsExpected()
        {
            Context context = new Context();
            string result = context.ToString();
            Assert.Equal("[Context]", result);
        }

        /// <summary>
        /// Tests that finalizer runs without throwing
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Finalizer_DoesNotThrow()
        {
            System.WeakReference weak = CreateWeakContextRef();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            if (weak.IsAlive)
            {
                System.GC.Collect(2, System.GCCollectionMode.Forced, true, true);
                System.GC.WaitForPendingFinalizers();
                System.GC.Collect(2, System.GCCollectionMode.Forced, true, true);
                System.GC.WaitForPendingFinalizers();
            }

            Assert.False(weak.IsAlive);
        }

        /// <summary>
        /// Creates the weak context ref
        /// </summary>
        /// <returns>The system weak reference</returns>
        private static System.WeakReference CreateWeakContextRef()
        {
            Context context = new Context();
            return new System.WeakReference(context);
        }
    }
}
