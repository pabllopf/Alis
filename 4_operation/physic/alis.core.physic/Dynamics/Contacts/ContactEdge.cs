// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactEdge.cs
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

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     A contact edge is used to connect bodies and contacts together
    ///     in a contact graph where each body is a node and each contact
    ///     is an edge. A contact edge belongs to a doubly linked list
    ///     maintained in each attached body. Each contact has two contact
    ///     nodes, one for each attached body.
    /// </summary>
    public class ContactEdge
    {
        /// <summary>
        ///     The contact.
        /// </summary>
        public Contact Contact;

        /// <summary>
        ///     The next contact edge in the body's contact list.
        /// </summary>
        public ContactEdge Next;

        /// <summary>
        ///     Provides quick access to the other body attached.
        /// </summary>
        public Body Other;

        /// <summary>
        ///     The previous contact edge in the body's contact list.
        /// </summary>
        public ContactEdge Prev;
    }
}