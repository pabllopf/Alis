using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Kernel.Events
{
    /// <summary>
    ///     A collection of <see cref="IGenericAction{GameObject}" /> instances which can be added to or removed from.
    /// </summary>
    public class GenericEvent
    {
        /// <summary>
        ///     The first
        /// </summary>
        private IGenericAction<GameObject> _first;

        /// <summary>
        ///     The gameObject
        /// </summary>
        private FrugalStack<IGenericAction<GameObject>> _invokationList = new FrugalStack<IGenericAction<GameObject>>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="GenericEvent" /> class
        /// </summary>
        internal GenericEvent()
        {
        }

        /// <summary>
        ///     Gets the value of the has listeners
        /// </summary>
        internal bool HasListeners => _first is not null;

        /// <summary>
        ///     Adds the action
        /// </summary>
        /// <param name="action">The action</param>
        internal void Add(IGenericAction<GameObject> action)
        {
            if (_first is null)
                _first = action;
            else
                _invokationList.Push(action);
        }

        /// <summary>
        ///     Removes the action
        /// </summary>
        /// <param name="action">The action</param>
        internal void Remove(IGenericAction<GameObject> action)
        {
            if (_first == action)
            {
                _first = null;
                if (_invokationList.TryPop(out IGenericAction<GameObject> v))
                    _first = v;
            }
            else
            {
                _invokationList.Remove(action);
            }
        }

        /// <summary>
        ///     Invokes the gameObject
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="arg">The arg</param>
        internal void Invoke<T>(GameObject gameObject, ref T arg)
        {
            if (_first is not null)
            {
                _first.Invoke(gameObject, ref arg);
                foreach (IGenericAction<GameObject> item in _invokationList.AsSpan())
                    item.Invoke(gameObject, ref arg);
            }
        }


        //https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/operator-overloads
        //I don't think its violating "DO NOT be cute when defining operator overloads." since its what event does.
        /// <summary>
        ///     Adds an <see cref="IGenericAction{GameObject}" /> to this event instance
        /// </summary>
        /// <param name="left">The event collection to add to.</param>
        /// <param name="right">The event to add</param>
        /// <returns>The event itself. When <paramref name="left" /> is null, the return value is also null.</returns>
        public static GenericEvent operator +(GenericEvent left, IGenericAction<GameObject> right)
        {
            if (left is null)
                return null;

            if (left._first is null)
                left._first = right;
            else
                left._invokationList.Push(right);
            return left;
        }

        /// <summary>
        ///     Unsubscribes an <see cref="IGenericAction{GameObject}" /> to this event instance
        /// </summary>
        /// <param name="left">The event collection to unsubscribe from.</param>
        /// <param name="right">The event to unsubscribe</param>
        /// <returns>The event itself. When <paramref name="left" /> is null, the return value is also null.</returns>
        public static GenericEvent operator -(GenericEvent left, IGenericAction<GameObject> right)
        {
            if (left is null)
                return null;

            left.Remove(right);
            return left;
        }
    }
}