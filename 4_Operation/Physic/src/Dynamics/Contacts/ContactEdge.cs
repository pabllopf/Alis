namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     A contact edge is used to connect bodies and contacts together
    ///     in a contact graph where each body is a node and each contact
    ///     is an edge. A contact edge belongs to a doubly linked list
    ///     maintained in each attached body. Each contact has two contact
    ///     nodes, one for each attached body.
    /// </summary>
    public sealed class ContactEdge
    {
        /// <summary>
        ///     The contact
        /// </summary>
        public Contact Contact { get; internal set; }

        /// <summary>
        ///     Provides quick access to the other body attached.
        /// </summary>
        public Body Other { get; internal set; }

        /// <summary>
        ///     The next contact edge in the body's contact list
        /// </summary>
        public ContactEdge Next { get; internal set; }

        /// <summary>
        ///     The previous contact edge in the body's contact list
        /// </summary>
        public ContactEdge Prev { get; internal set; }
    }
}