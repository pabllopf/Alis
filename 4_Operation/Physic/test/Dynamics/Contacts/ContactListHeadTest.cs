// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactListHeadTest.cs
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
using System.Linq;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact list head test class
    /// </summary>
    public class ContactListHeadTest
    {
        /// <summary>
        ///     Tests that contact list head should inherit from contact
        /// </summary>
        [Fact]
        public void ContactListHead_ShouldInheritFromContact()
        {
            ContactListHead head = new ContactListHead();
            
            Assert.IsAssignableFrom<Contact>(head);
        }

        /// <summary>
        ///     Tests that contact list head should implement i enumerable
        /// </summary>
        [Fact]
        public void ContactListHead_ShouldImplementIEnumerable()
        {
            ContactListHead head = new ContactListHead();
            
            Assert.IsAssignableFrom<IEnumerable<Contact>>(head);
        }

        /// <summary>
        ///     Tests that constructor should initialize circular linked list
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeCircularLinkedList()
        {
            ContactListHead head = new ContactListHead();
            
            Assert.Equal(head, head.Prev);
            Assert.Equal(head, head.Next);
        }

        /// <summary>
        ///     Tests that get enumerator should not iterate empty list
        /// </summary>
        [Fact]
        public void GetEnumerator_ShouldNotIterate_EmptyList()
        {
            ContactListHead head = new ContactListHead();
            
            int count = 0;
            foreach (Contact contact in head)
            {
                count++;
            }
            
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that contact list head should support linq operations
        /// </summary>
        [Fact]
        public void ContactListHead_ShouldSupportLinqOperations()
        {
            ContactListHead head = new ContactListHead();
            
            var list = head.ToList();
            
            Assert.NotNull(list);
            Assert.Empty(list);
        }

        /// <summary>
        ///     Tests that contact list head should be reference type
        /// </summary>
        [Fact]
        public void ContactListHead_ShouldBeReferenceType()
        {
            ContactListHead head1 = new ContactListHead();
            ContactListHead head2 = head1;
            
            Assert.Same(head1, head2);
        }

        /// <summary>
        ///     Tests that multiple instances should be independent
        /// </summary>
        [Fact]
        public void MultipleInstances_ShouldBeIndependent()
        {
            ContactListHead head1 = new ContactListHead();
            ContactListHead head2 = new ContactListHead();
            
            Assert.NotSame(head1, head2);
            Assert.Equal(head1, head1.Next);
            Assert.Equal(head2, head2.Next);
        }

        /// <summary>
        ///     Tests that contact list head should support foreach iteration
        /// </summary>
        [Fact]
        public void ContactListHead_ShouldSupportForeachIteration()
        {
            ContactListHead head = new ContactListHead();
            bool canIterate = true;
            
            try
            {
                foreach (Contact contact in head)
                {
                    // Empty iteration
                }
            }
            catch
            {
                canIterate = false;
            }
            
            Assert.True(canIterate);
        }

        /// <summary>
        ///     Tests that contact list head should initialize with null fixtures
        /// </summary>
        [Fact]
        public void ContactListHead_ShouldInitializeWithNullFixtures()
        {
            ContactListHead head = new ContactListHead();
            
            Assert.Null(head.FixtureA);
            Assert.Null(head.FixtureB);
        }

        /// <summary>
        ///     Tests that contact list head should allow enumeration multiple times
        /// </summary>
        [Fact]
        public void ContactListHead_ShouldAllowEnumerationMultipleTimes()
        {
            ContactListHead head = new ContactListHead();
            
            int count1 = 0;
            foreach (Contact contact in head) count1++;
            
            int count2 = 0;
            foreach (Contact contact in head) count2++;
            
            Assert.Equal(count1, count2);
        }
    }
}

