// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogEventPublisher.cs
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
using System.Collections.Generic;

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Publishes dialog events to registered observers (Observer pattern)
    /// </summary>
    public class DialogEventPublisher
    {
        /// <summary>
        ///     The observers collection
        /// </summary>
        private readonly List<IDialogEventObserver> _observers = new List<IDialogEventObserver>();

        /// <summary>
        ///     Subscribes an observer to dialog events
        /// </summary>
        /// <param name="observer">The observer to subscribe</param>
        /// <exception cref="ArgumentNullException">Thrown when observer is null</exception>
        public void Subscribe(IDialogEventObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        /// <summary>
        ///     Unsubscribes an observer from dialog events
        /// </summary>
        /// <param name="observer">The observer to unsubscribe</param>
        /// <exception cref="ArgumentNullException">Thrown when observer is null</exception>
        public void Unsubscribe(IDialogEventObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            _observers.Remove(observer);
        }

        /// <summary>
        ///     Publishes a dialog event to all subscribed observers
        /// </summary>
        /// <param name="dialogEvent">The event to publish</param>
        /// <exception cref="ArgumentNullException">Thrown when dialogEvent is null</exception>
        public void Publish(DialogEvent dialogEvent)
        {
            if (dialogEvent == null)
            {
                throw new ArgumentNullException(nameof(dialogEvent));
            }

            foreach (IDialogEventObserver observer in _observers)
            {
                observer.OnDialogEvent(dialogEvent);
            }
        }

        /// <summary>
        ///     Gets the number of subscribed observers
        /// </summary>
        /// <returns>The count of observers</returns>
        public int GetObserverCount()
        {
            return _observers.Count;
        }

        /// <summary>
        ///     Clears all subscribed observers
        /// </summary>
        public void ClearObservers()
        {
            _observers.Clear();
        }
    }
}

