// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ContactListener.cs
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

using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// Implement this class to get contact information. You can use these results for
    /// things like sounds and game logic. You can also get contact results by
    /// traversing the contact lists after the time step. However, you might miss
    /// some contacts because continuous physics leads to sub-stepping.
    /// Additionally you may receive multiple callbacks for the same contact in a
    /// single time step.
    /// You should strive to make your callbacks efficient because there may be
    /// many callbacks per time step.
    /// @warning You cannot create/destroy Box2DX entities inside these callbacks.
    public interface ContactListener
    {
        /// Called when two fixtures begin to touch.
        void BeginContact(Contact contact);

        /// Called when two fixtures cease to touch.
        void EndContact(Contact contact);

        /// This is called after a contact is updated. This allows you to inspect a
        /// contact before it goes to the solver. If you are careful, you can modify the
        /// contact manifold (e.g. disable contact).
        /// A copy of the old manifold is provided so that you can detect changes.
        /// Note: this is called only for awake bodies.
        /// Note: this is called even when the number of contact points is zero.
        /// Note: this is not called for sensors.
        /// Note: if you set the number of contact points to zero, you will not
        /// get an EndContact callback. However, you may get a BeginContact callback
        /// the next step.
        void PreSolve(Contact contact, Manifold oldManifold);

        /// This lets you inspect a contact after the solver is finished. This is useful
        /// for inspecting impulses.
        /// Note: the contact manifold does not include time of impact impulses, which can be
        /// arbitrarily large if the sub-step is small. Hence the impulse is provided explicitly
        /// in a separate data structure.
        /// Note: this is only called for contacts that are touching, solid, and awake.
        void PostSolve(Contact contact, ContactImpulse impulse);
    }
}