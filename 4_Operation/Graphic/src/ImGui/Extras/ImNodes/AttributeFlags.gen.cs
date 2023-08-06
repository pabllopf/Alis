namespace imnodesNET
{
    /// <summary>
    /// The attribute flags enum
    /// </summary>
    [System.Flags]
    public enum AttributeFlags
    {
        /// <summary>
        /// The none attribute flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The enable link detach with drag click attribute flags
        /// </summary>
        EnableLinkDetachWithDragClick = 1,
        /// <summary>
        /// The enable link creation on snap attribute flags
        /// </summary>
        EnableLinkCreationOnSnap = 2,
    }
}
