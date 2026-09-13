// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SizeEventArgsCoverageTests.cs
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
    ///     The size event args coverage tests class
    /// </summary>
    public class SizeEventArgsCoverageTests
    {
        /// <summary>
        ///     Tests that constructor copies dimensions from source event
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_CopiesDimensionsFromSourceEvent()
        {
            SizeEvent source = new SizeEvent
            {
                Width = 1920u,
                Height = 1080u
            };

            SizeEventArgs args = new SizeEventArgs(source);

            Assert.Equal(1920u, args.Width);
            Assert.Equal(1080u, args.Height);
        }

        /// <summary>
        ///     Tests that constructor copies default dimensions when event is untouched
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_CopiesDefaultDimensionsFromUntouchedEvent()
        {
            SizeEvent source = new SizeEvent();

            SizeEventArgs args = new SizeEventArgs(source);

            Assert.Equal(0u, args.Width);
            Assert.Equal(0u, args.Height);
        }

        /// <summary>
        ///     Tests that instance is assignable to event args base type
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_InstanceIsAssignableToEventArgs()
        {
            SizeEventArgs args = new SizeEventArgs(new SizeEvent());

            EventArgs asBase = args;

            Assert.Same(args, asBase);
        }

        /// <summary>
        ///     Tests that width property round trips assigned values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Width_PropertyRoundTripsAssignedValues()
        {
            SizeEventArgs args = new SizeEventArgs(new SizeEvent());

            args.Width = uint.MaxValue;

            Assert.Equal(uint.MaxValue, args.Width);
        }

        /// <summary>
        ///     Tests that height property round trips assigned values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Height_PropertyRoundTripsAssignedValues()
        {
            SizeEventArgs args = new SizeEventArgs(new SizeEvent());

            args.Height = uint.MaxValue;

            Assert.Equal(uint.MaxValue, args.Height);
        }

        /// <summary>
        ///     Tests that to string includes dimensions formatting
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_IncludesDimensionsFormatting()
        {
            SizeEvent source = new SizeEvent
            {
                Width = 800u,
                Height = 600u
            };

            SizeEventArgs args = new SizeEventArgs(source);

            Assert.Equal("[SizeEventArgs] Width(800) Height(600)", args.ToString());
        }

        /// <summary>
        ///     Tests that to string reflects updated property values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReflectsUpdatedPropertyValues()
        {
            SizeEventArgs args = new SizeEventArgs(new SizeEvent());

            args.Width = 12u;
            args.Height = 34u;

            Assert.Equal("[SizeEventArgs] Width(12) Height(34)", args.ToString());
        }
    }
}
