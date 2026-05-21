

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
        public int GetObserverCount() => _observers.Count;

        /// <summary>
        ///     Clears all subscribed observers
        /// </summary>
        public void ClearObservers()
        {
            _observers.Clear();
        }
    }
}