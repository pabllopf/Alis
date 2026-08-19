// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolverExecutionTests.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     Executes the multithreaded solve paths and lock contention paths of
    ///     <see cref="ContactSolver" /> by resetting it with zero thresholds.
    /// </summary>
    public class ContactSolverExecutionTests
    {
        
        
        /// <summary>
        ///     Tests that acquire contact locks with a contended lock spins until both locks are held.
        /// </summary>
        [Fact]
        public void AcquireContactLocks_WithContendedLock_AcquiresBothLocks()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = true };
            int[] locks = new int[2];
            locks[1] = 1;
            solver.Reset(ref step, 2, new[] {contact, contact}, new SolverPosition[2], new SolverVelocity[2], locks, 0, 0);

            Task acquireTask = Task.Run(() => solver.AcquireContactLocks(0, 1));
            Thread.Sleep(50);
            locks[1] = 0;

            Assert.True(acquireTask.Wait(TimeSpan.FromSeconds(5)));
            Assert.Equal(1, locks[0]);
            Assert.Equal(1, locks[1]);
        }
        
      
    }
}
