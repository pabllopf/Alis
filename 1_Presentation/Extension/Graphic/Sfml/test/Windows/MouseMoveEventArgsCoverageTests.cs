// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseMoveEventArgsCoverageTests.cs
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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     The mouse move event args coverage tests class
    /// </summary>
    public class MouseMoveEventArgsCoverageTests
    {
        /// <summary>
        ///     Tests that constructor copies coordinates from source event
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_CopiesCoordinatesFromSourceEvent()
        {
            MouseMoveEvent source = new MouseMoveEvent
            {
                X = -15,
                Y = 42
            };

            MouseMoveEventArgs args = new MouseMoveEventArgs(source);

            Assert.Equal(-15, args.X);
            Assert.Equal(42, args.Y);
        }

        /// <summary>
        ///     Tests that constructor copies default coordinates when event is untouched
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_CopiesDefaultCoordinatesFromUntouchedEvent()
        {
            MouseMoveEvent source = new MouseMoveEvent();

            MouseMoveEventArgs args = new MouseMoveEventArgs(source);

            Assert.Equal(0, args.X);
            Assert.Equal(0, args.Y);
        }

        /// <summary>
        ///     Tests that instance is assignable to event args base type
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_InstanceIsAssignableToEventArgs()
        {
            MouseMoveEventArgs args = new MouseMoveEventArgs(new MouseMoveEvent());

            EventArgs asBase = args;

            Assert.Same(args, asBase);
        }

        /// <summary>
        ///     Tests that x property round trips assigned values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void X_PropertyRoundTripsAssignedValues()
        {
            MouseMoveEventArgs args = new MouseMoveEventArgs(new MouseMoveEvent());

            args.X = int.MaxValue;

            Assert.Equal(int.MaxValue, args.X);
        }

        /// <summary>
        ///     Tests that y property round trips assigned values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Y_PropertyRoundTripsAssignedValues()
        {
            MouseMoveEventArgs args = new MouseMoveEventArgs(new MouseMoveEvent());

            args.Y = int.MinValue;

            Assert.Equal(int.MinValue, args.Y);
        }

        /// <summary>
        ///     Tests that to string includes coordinates formatting
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_IncludesCoordinatesFormatting()
        {
            MouseMoveEvent source = new MouseMoveEvent
            {
                X = 7,
                Y = 9
            };

            MouseMoveEventArgs args = new MouseMoveEventArgs(source);

            Assert.Equal("[MouseMoveEventArgs] X(7) Y(9)", args.ToString());
        }

        /// <summary>
        ///     Tests that to string reflects updated property values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReflectsUpdatedPropertyValues()
        {
            MouseMoveEventArgs args = new MouseMoveEventArgs(new MouseMoveEvent());

            args.X = -3;
            args.Y = 5;

            Assert.Equal("[MouseMoveEventArgs] X(-3) Y(5)", args.ToString());
        }
    }
}
