// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextExecutionTests.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     The context execution tests class
    /// </summary>
    public class ContextExecutionTests
    {
        /// <summary>
        ///     Tests that the finalizer runs when the context is not disposed
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Finalizer_Runs_WhenNotDisposed()
        {
            Context context = new Context();
            context = null;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that the finalizer runs when the context was used before collection
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Finalizer_Runs_AfterContextUsage()
        {
            System.WeakReference reference = CreateWeakContextReference();

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            if (reference.IsAlive)
            {
                System.GC.Collect(2, System.GCCollectionMode.Forced, true, true);
                System.GC.WaitForPendingFinalizers();
                System.GC.Collect(2, System.GCCollectionMode.Forced, true, true);
                System.GC.WaitForPendingFinalizers();
            }

            Assert.False(reference.IsAlive);
        }

        /// <summary>
        ///     Creates a weak reference to a used context
        /// </summary>
        /// <returns>The weak reference</returns>
        private static System.WeakReference CreateWeakContextReference()
        {
            Context context = new Context();
            context.SetActive(true);
            ContextSettings settings = context.Settings;
            _ = settings;
            return new System.WeakReference(context);
        }
    }
}
