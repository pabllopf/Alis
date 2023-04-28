// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyHelper.cs
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

using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.TOI;
using Alis.Core.Physic.Dynamics.Solver;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// The body helper class
    /// </summary>
    internal static class BodyHelper
    {
        /// <summary>
        /// Advances the body using the specified contact manager
        /// </summary>
        /// <param name="contactManager">The contact manager</param>
        /// <param name="island">The island</param>
        /// <param name="minContact">The min contact</param>
        /// <param name="minAlpha">The min alpha</param>
        /// <returns>The bodies</returns>
        internal static Body[] AdvanceBody(ContactManager contactManager, Island island, Contact minContact, float minAlpha)
        {
            // Advance the bodies to the TOI.
            Fixture fA1 = minContact.FixtureA;
            Fixture fB1 = minContact.FixtureB;
            Body bA0 = fA1.Body;
            Body bB0 = fB1.Body;
            
            Body[] bodies = {bA0, bB0};

            Sweep backup1 = bA0.Sweep;
            Sweep backup2 = bB0.Sweep;

            bA0.Advance(minAlpha);
            bB0.Advance(minAlpha);

            // The TOI contact likely has some new contact points.
            minContact.Update(contactManager);
            minContact.Flags &= ~ContactFlags.ToiFlag;
            ++minContact.ToiCount;

            // Is the contact solid?
            if (!minContact.Enabled || !minContact.IsTouching)
            {
                // Restore the sweeps.
                minContact.Flags &= ~ContactFlags.EnabledFlag;
                bA0.Sweep = backup1;
                bB0.Sweep = backup2;
                bA0.SynchronizeTransform();
                bB0.SynchronizeTransform();
                return bodies;
            }

            bA0.Awake = true;
            bB0.Awake = true;

            // Build the island
            island.Clear();
            island.Add(bA0);
            island.Add(bB0);
            island.Add(minContact);

            bA0.Flags |= BodyFlags.IslandFlag;
            bB0.Flags |= BodyFlags.IslandFlag;
            minContact.Flags &= ~ContactFlags.IslandFlag;

            // Get contacts on bodyA and bodyB;
            for (int i = 0; i < 2; ++i)
            {
                Body body = bodies[i];
                if (body.BodyType == BodyType.Dynamic)
                {
                    for (ContactEdge ce = body.ContactList; ce != null; ce = ce.Next)
                    {
                        Contact contact = ce.Contact;

                        // Has this contact already been added to the island?
                        if (contact.IslandFlag)
                        {
                            continue;
                        }

                        // Only add static, kinematic, or bullet bodies.
                        Body other = ce.Other;
                        if ((other.BodyType == BodyType.Dynamic) &&
                            !body.IsBullet && !other.IsBullet)
                        {
                            continue;
                        }

                        // Skip sensors.
                        bool sensorA = contact.FixtureA.IsSensorPrivate;
                        bool sensorB = contact.FixtureB.IsSensorPrivate;
                        if (sensorA || sensorB)
                        {
                            continue;
                        }

                        // Tentatively advance the body to the TOI.
                        Sweep backup = other.Sweep;
                        if (!other.IsIsland)
                        {
                            other.Advance(minAlpha);
                        }

                        // Update the contact points
                        contact.Update(contactManager);

                        // Was the contact disabled by the user?
                        if (!contact.Enabled)
                        {
                            other.Sweep = backup;
                            other.SynchronizeTransform();
                            continue;
                        }

                        // Are there contact points?
                        if (!contact.IsTouching)
                        {
                            other.Sweep = backup;
                            other.SynchronizeTransform();
                            continue;
                        }

                        // Add the contact to the island
                        minContact.Flags |= ContactFlags.IslandFlag;
                        island.Add(contact);

                        // Has the other body already been added to the island?
                        if (other.IsIsland)
                        {
                            continue;
                        }

                        // Add the other body to the island.
                        other.Flags |= BodyFlags.IslandFlag;

                        if (other.BodyType != BodyType.Static)
                        {
                            other.Awake = true;
                        }

                        island.Add(other);
                    }
                }
            }

            return bodies;
        }
    }
}