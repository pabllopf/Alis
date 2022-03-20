// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TestBodyFactory.cs
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
using Alis.Core.Physics2D.Dynamics.World;
using NUnit.Framework;

namespace Alis.Core.Physics2D.Test.Factories
{
    /// <summary>
    ///     The test body factory class
    /// </summary>
    public class TestBodyFactory
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
        ///     Tests that test create body
        /// </summary>
        [Test]
        public void TestCreateBody()
        {
        }

        /// <summary>
        ///     Tests that test create circle
        /// </summary>
        [Test]
        public void TestCreateCircle()
        {
        }

        /// <summary>
        ///     Tests that test create edge
        /// </summary>
        [Test]
        public void TestCreateEdge()
        {
        }

        /// <summary>
        ///     Tests that create body
        /// </summary>
        [Test]
        public void CreateBody()
        {
        }
    }
}