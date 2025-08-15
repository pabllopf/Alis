// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactListHead.cs
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

using System.Collections;
using System.Collections.Generic;


namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     Head of a circular doubly linked list.
    /// </summary>
    public class ContactListHead : Contact, IEnumerable<Contact>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactListHead" /> class
        /// </summary>
        internal ContactListHead() : base(null, 0, null, 0)
        {
            Prev = this;
            Next = this;
        }

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of contact</returns>
        IEnumerator<Contact> IEnumerable<Contact>.GetEnumerator() => new ContactEnumerator(this);

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => new ContactEnumerator(this);


        /// <summary>
        ///     The contact enumerator
        /// </summary>
        private struct ContactEnumerator : IEnumerator<Contact>
        {
            /// <summary>
            ///     The head
            /// </summary>
            private ContactListHead _head;

            /// <summary>
            ///     Gets or sets the value of the current
            /// </summary>
            public Contact Current { get; private set; }

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            object IEnumerator.Current => Current;


            /// <summary>
            ///     Initializes a new instance of the <see cref="ContactEnumerator" /> class
            /// </summary>
            /// <param name="contact">The contact</param>
            public ContactEnumerator(ContactListHead contact)
            {
                _head = contact;
                Current = _head;
            }

            /// <summary>
            ///     Resets this instance
            /// </summary>
            public void Reset()
            {
                Current = _head;
            }

            /// <summary>
            ///     Describes whether this instance move next
            /// </summary>
            /// <returns>The bool</returns>
            public bool MoveNext()
            {
                Current = Current.Next;
                return Current != _head;
            }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public void Dispose()
            {
                _head = null;
                Current = null;
            }
        }
    }
}