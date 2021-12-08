// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TestWorld.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Numerics;
using Alis.Core.Systems.Physics2D.Definitions;
using Alis.Core.Systems.Physics2D.Dynamics;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test
{
    /// <summary>
    ///     The test world class
    /// </summary>
    public class TestWorld
    {
        /// <summary>
        ///     The world
        /// </summary>
        public World world;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup() => world = new World(Vector2.Zero);

        /// <summary>
        ///     Tests that test add body
        /// </summary>
        /// <param name="expected">The expected</param>
        /// <param name="count">The count</param>
        [Test, TestCase(0, 0), TestCase(1, 1), TestCase(2, 2)]
        public void Test_AddBody(int expected, int count)
        {
            for (int i = 0; i < count; i++)
            {
                world.AddBody(new Body(new BodyDef()));
            }

            Assert.AreEqual(expected, world.BodyList.Count);
        }
    }
}