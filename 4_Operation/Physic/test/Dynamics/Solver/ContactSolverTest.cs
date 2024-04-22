// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolverTest.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Dynamics.Solver;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Solver
{
    /// <summary>
    ///     The contact solver test class
    /// </summary>
    public class ContactSolverTest
    {
        /// <summary>
        ///     Tests that reset test
        /// </summary>
        [Fact]
        public void ResetTest()
        {
            ContactSolver contactSolver = new ContactSolver();
            TimeStep timeStep = new TimeStep();
            List<Contact> contactList = new List<Contact>();
            List<Position> positionList = new List<Position>();
            List<Velocity> velocitiesList = new List<Velocity>();
            
            contactSolver.Reset(timeStep, 0, contactList, positionList, velocitiesList);
            
            // Add your Asserts here
        }
        
        /// <summary>
        ///     Tests that initialize velocity constraints test
        /// </summary>
        [Fact]
        public void InitializeVelocityConstraintsTest()
        {
            ContactSolver contactSolver = new ContactSolver();
            
            contactSolver.InitializeVelocityConstraints();
            
            // Add your Asserts here
        }
        
        /// <summary>
        ///     Tests that warm start test
        /// </summary>
        [Fact]
        public void WarmStartTest()
        {
            ContactSolver contactSolver = new ContactSolver();
            
            contactSolver.WarmStart();
            
            // Add your Asserts here
        }
        
        /// <summary>
        ///     Tests that solve velocity constraints test
        /// </summary>
        [Fact]
        public void SolveVelocityConstraintsTest()
        {
            ContactSolver contactSolver = new ContactSolver();
            
            contactSolver.SolveVelocityConstraints();
            
            // Add your Asserts here
        }
        
        /// <summary>
        ///     Tests that store impulses test
        /// </summary>
        [Fact]
        public void StoreImpulsesTest()
        {
            ContactSolver contactSolver = new ContactSolver();
            
            contactSolver.StoreImpulses();
            
            // Add your Asserts here
        }
        
        /// <summary>
        ///     Tests that solve position constraints test
        /// </summary>
        [Fact]
        public void SolvePositionConstraintsTest()
        {
            ContactSolver contactSolver = new ContactSolver();
            
            bool result = contactSolver.SolvePositionConstraints();
            
            // Add your Asserts here
        }
        
        /// <summary>
        ///     Tests that solve toi position constraints test
        /// </summary>
        [Fact]
        public void SolveToiPositionConstraintsTest()
        {
            ContactSolver contactSolver = new ContactSolver();
            
            bool result = contactSolver.SolveToiPositionConstraints(0, 0);
            
            // Add your Asserts here
        }
    }
}