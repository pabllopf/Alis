namespace imnodesNET
{
    public unsafe struct ImNodesContextPtr
    {
        public unsafe ImNodesContextPtr(ImNodesContext* ret)
        {
            NativePtr = ret;
        }

        public unsafe ImNodesContext* NativePtr { get; private set; }
    }
}