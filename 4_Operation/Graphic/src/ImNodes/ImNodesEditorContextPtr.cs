namespace imnodesNET
{
    public class ImNodesEditorContextPtr
    {
        public unsafe ImNodesEditorContextPtr(ImNodesEditorContext* ret)
        {
            NativePtr = ret;
        }

        public unsafe ImNodesEditorContext* NativePtr { get; private set; }
    }
}