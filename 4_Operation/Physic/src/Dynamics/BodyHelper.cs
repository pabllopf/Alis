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
    ///     The body helper class
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
            Fixture fA1 = minContact.FixtureA;
            Fixture fB1 = minContact.FixtureB;
            Body bA0 = fA1.Body;
            Body bB0 = fB1.Body;

            Body[] bodies = {bA0, bB0};

            Sweep backup1 = bA0.Sweep;
            Sweep backup2 = bB0.Sweep;

            bodies = AdvanceBodies(minContact, minAlpha);
            UpdateContact(contactManager, minContact);

            if (!CheckContactSolid(minContact, bodies, backup1, backup2))
            {
                return bodies;
            }

            BuildIsland(island, minContact, bodies);
            GetContacts(contactManager, minAlpha, bodies, island, minContact);

            return bodies;
        }

        /// <summary>
        /// Advances the bodies using the specified min contact
        /// </summary>
        /// <param name="minContact">The min contact</param>
        /// <param name="minAlpha">The min alpha</param>
        /// <returns>The bodies</returns>
        private static Body[] AdvanceBodies(Contact minContact, float minAlpha)
        {
            Fixture fA1 = minContact.FixtureA;
            Fixture fB1 = minContact.FixtureB;
            Body bA0 = fA1.Body;
            Body bB0 = fB1.Body;

            Body[] bodies = {bA0, bB0};

            Sweep backup1 = bA0.Sweep;
            Sweep backup2 = bB0.Sweep;

            bA0.Advance(minAlpha);
            bB0.Advance(minAlpha);

            return bodies;
        }

        /// <summary>
        /// Updates the contact using the specified contact manager
        /// </summary>
        /// <param name="contactManager">The contact manager</param>
        /// <param name="minContact">The min contact</param>
        private static void UpdateContact(ContactManager contactManager, Contact minContact)
        {
            minContact.Update(contactManager);
            minContact.Flags &= ~ContactFlags.ToiFlag;
            ++minContact.ToiCount;
        }

        /// <summary>
        /// Describes whether check contact solid
        /// </summary>
        /// <param name="minContact">The min contact</param>
        /// <param name="bodies">The bodies</param>
        /// <param name="backup1">The backup</param>
        /// <param name="backup2">The backup</param>
        /// <returns>The bool</returns>
        private static bool CheckContactSolid(Contact minContact, Body[] bodies, Sweep backup1, Sweep backup2)
        {
            if (!minContact.Enabled || !minContact.IsTouching)
            {
                minContact.Flags &= ~ContactFlags.EnabledFlag;
                bodies[0].Sweep = backup1;
                bodies[1].Sweep = backup2;
                bodies[0].SynchronizeTransform();
                bodies[1].SynchronizeTransform();
                return false;
            }

            bodies[0].Awake = true;
            bodies[1].Awake = true;

            return true;
        }

        /// <summary>
        /// Builds the island using the specified island
        /// </summary>
        /// <param name="island">The island</param>
        /// <param name="minContact">The min contact</param>
        /// <param name="bodies">The bodies</param>
        private static void BuildIsland(Island island, Contact minContact, Body[] bodies)
        {
            island.Clear();
            island.Add(bodies[0]);
            island.Add(bodies[1]);
            island.Add(minContact);

            bodies[0].Flags |= BodyFlags.IslandFlag;
            bodies[1].Flags |= BodyFlags.IslandFlag;
            minContact.Flags &= ~ContactFlags.IslandFlag;
        }

        /// <summary>
        /// Gets the contacts using the specified contact manager
        /// </summary>
        /// <param name="contactManager">The contact manager</param>
        /// <param name="minAlpha">The min alpha</param>
        /// <param name="bodies">The bodies</param>
        /// <param name="island">The island</param>
        /// <param name="minContact">The min contact</param>
        private static void GetContacts(ContactManager contactManager, float minAlpha, Body[] bodies, Island island, Contact minContact)
        {
            for (int i = 0; i < 2; ++i)
            {
                Body body = bodies[i];
                if (body.BodyType == BodyType.Dynamic)
                {
                    ProcessBodyContacts(body, contactManager, minAlpha, island, minContact);
                }
            }
        }

        /// <summary>
        /// Processes the body contacts using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        /// <param name="contactManager">The contact manager</param>
        /// <param name="minAlpha">The min alpha</param>
        /// <param name="island">The island</param>
        /// <param name="minContact">The min contact</param>
        private static void ProcessBodyContacts(Body body, ContactManager contactManager, float minAlpha, Island island, Contact minContact)
        {
            for (ContactEdge ce = body.ContactList; ce != null; ce = ce.Next)
            {
                ProcessContact(body, ce, contactManager, minAlpha, island, minContact);
            }
        }

        /// <summary>
        /// Processes the contact using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        /// <param name="ce">The ce</param>
        /// <param name="contactManager">The contact manager</param>
        /// <param name="minAlpha">The min alpha</param>
        /// <param name="island">The island</param>
        /// <param name="minContact">The min contact</param>
        private static void ProcessContact(Body body, ContactEdge ce, ContactManager contactManager, float minAlpha, Island island, Contact minContact)
        {
            Contact contact = ce.Contact;

            if (contact.IslandFlag)
            {
                return;
            }

            Body other = ce.Other;
            if ((other.BodyType == BodyType.Dynamic) &&
                !body.IsBullet && !other.IsBullet)
            {
                return;
            }

            bool sensorA = contact.FixtureA.IsSensorPrivate;
            bool sensorB = contact.FixtureB.IsSensorPrivate;
            if (sensorA || sensorB)
            {
                return;
            }

            Sweep backup = other.Sweep;
            if (!other.IsIsland)
            {
                other.Advance(minAlpha);
            }

            contact.Update(contactManager);

            if (!contact.Enabled)
            {
                other.Sweep = backup;
                other.SynchronizeTransform();
                return;
            }

            if (!contact.IsTouching)
            {
                other.Sweep = backup;
                other.SynchronizeTransform();
                return;
            }

            minContact.Flags |= ContactFlags.IslandFlag;
            island.Add(contact);

            if (other.IsIsland)
            {
                return;
            }

            other.Flags |= BodyFlags.IslandFlag;

            if (other.BodyType != BodyType.Static)
            {
                other.Awake = true;
            }

            island.Add(other);
        }
    }
}