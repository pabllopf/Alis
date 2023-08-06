using System;

namespace Alis.Core.Graphic.ImGui.Extras.ImNodes
{
    /// <summary>
    /// The link detach with modifier click
    /// </summary>
    public unsafe partial struct LinkDetachWithModifierClick
    {
        /// <summary>
        /// The modifier
        /// </summary>
        public byte* Modifier;
    }
    /// <summary>
    /// The link detach with modifier click ptr
    /// </summary>
    public unsafe partial struct LinkDetachWithModifierClickPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public LinkDetachWithModifierClick* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkDetachWithModifierClickPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public LinkDetachWithModifierClickPtr(LinkDetachWithModifierClick* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkDetachWithModifierClickPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public LinkDetachWithModifierClickPtr(IntPtr nativePtr) => NativePtr = (LinkDetachWithModifierClick*)nativePtr;
        public static implicit operator LinkDetachWithModifierClickPtr(LinkDetachWithModifierClick* nativePtr) => new LinkDetachWithModifierClickPtr(nativePtr);
        public static implicit operator LinkDetachWithModifierClick* (LinkDetachWithModifierClickPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator LinkDetachWithModifierClickPtr(IntPtr nativePtr) => new LinkDetachWithModifierClickPtr(nativePtr);
        /// <summary>
        /// Gets or sets the value of the modifier
        /// </summary>
        public IntPtr Modifier { get => (IntPtr)NativePtr->Modifier; set => NativePtr->Modifier = (byte*)value; }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            imnodesNative.LinkDetachWithModifierClick_destroy((LinkDetachWithModifierClick*)(NativePtr));
        }
    }
}
