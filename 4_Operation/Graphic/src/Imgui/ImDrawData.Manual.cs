namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw data ptr
    /// </summary>
    public unsafe partial struct ImDrawDataPtr
    {
        /// <summary>
        /// Gets the value of the cmd lists range
        /// </summary>
        public RangePtrAccessor<ImDrawListPtr> CmdListsRange => new RangePtrAccessor<ImDrawListPtr>(CmdLists.ToPointer(), CmdListsCount);
    }
}
