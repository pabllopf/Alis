// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogEventPublisherTest.cs
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
using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Tests for DialogEventPublisher
    /// </summary>
    public class DialogEventPublisherTest
    {
        /// <summary>
        ///     Mock observer for testing
        /// </summary>
        private class MockObserver : IDialogEventObserver
        {
            /// <summary>
            /// Gets or sets the value of the last received event
            /// </summary>
            public DialogEvent LastReceivedEvent { get; set; }

            /// <summary>
            /// Gets or sets the value of the event count
            /// </summary>
            public int EventCount { get; set; }

            /// <summary>
            /// Ons the dialog event using the specified dialog event
            /// </summary>
            /// <param name="dialogEvent">The dialog event</param>
            public void OnDialogEvent(DialogEvent dialogEvent)
            {
                LastReceivedEvent = dialogEvent;
                EventCount++;
            }
        }

        /// <summary>
        ///     Tests that subscribe adds observer correctly
        /// </summary>
        [Fact]
        public void Subscribe_AddsObserverCorrectly()
        {
            DialogEventPublisher publisher = new DialogEventPublisher();
            MockObserver observer = new MockObserver();

            publisher.Subscribe(observer);

            Assert.Equal(1, publisher.GetObserverCount());
        }

        /// <summary>
        ///     Tests that subscribe with null observer throws exception
        /// </summary>
        [Fact]
        public void Subscribe_WithNullObserver_ThrowsException()
        {
            DialogEventPublisher publisher = new DialogEventPublisher();
            Assert.Throws<ArgumentNullException>(() => publisher.Subscribe(null));
        }

        /// <summary>
        ///     Tests that unsubscribe removes observer correctly
        /// </summary>
        [Fact]
        public void Unsubscribe_RemovesObserverCorrectly()
        {
            DialogEventPublisher publisher = new DialogEventPublisher();
            MockObserver observer = new MockObserver();

            publisher.Subscribe(observer);
            publisher.Unsubscribe(observer);

            Assert.Equal(0, publisher.GetObserverCount());
        }

        /// <summary>
        ///     Tests that unsubscribe with null observer throws exception
        /// </summary>
        [Fact]
        public void Unsubscribe_WithNullObserver_ThrowsException()
        {
            DialogEventPublisher publisher = new DialogEventPublisher();
            Assert.Throws<ArgumentNullException>(() => publisher.Unsubscribe(null));
        }

        /// <summary>
        ///     Tests that publish notifies all observers
        /// </summary>
        [Fact]
        public void Publish_NotifiesAllObservers()
        {
            DialogEventPublisher publisher = new DialogEventPublisher();
            MockObserver observer1 = new MockObserver();
            MockObserver observer2 = new MockObserver();

            publisher.Subscribe(observer1);
            publisher.Subscribe(observer2);

            DialogEvent testEvent = new DialogEvent(DialogEventType.OnDialogStart, "testDialog");
            publisher.Publish(testEvent);

            Assert.Equal(testEvent, observer1.LastReceivedEvent);
            Assert.Equal(testEvent, observer2.LastReceivedEvent);
            Assert.Equal(1, observer1.EventCount);
            Assert.Equal(1, observer2.EventCount);
        }

        /// <summary>
        ///     Tests that publish with null event throws exception
        /// </summary>
        [Fact]
        public void Publish_WithNullEvent_ThrowsException()
        {
            DialogEventPublisher publisher = new DialogEventPublisher();
            Assert.Throws<ArgumentNullException>(() => publisher.Publish(null));
        }

        /// <summary>
        ///     Tests that clear observers removes all observers
        /// </summary>
        [Fact]
        public void ClearObservers_RemovesAllObservers()
        {
            DialogEventPublisher publisher = new DialogEventPublisher();
            publisher.Subscribe(new MockObserver());
            publisher.Subscribe(new MockObserver());

            publisher.ClearObservers();

            Assert.Equal(0, publisher.GetObserverCount());
        }
    }
}

