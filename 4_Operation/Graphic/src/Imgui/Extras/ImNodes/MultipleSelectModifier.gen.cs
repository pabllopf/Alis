using System;

namespace Alis.Core.Graphic.Imgui.Extras.ImNodes
{
    /// <summary>
    /// The multiple select modifier
    /// </summary>
    public unsafe struct MultipleSelectModifier
    {
        /// <summary>
        /// The modifier
        /// </summary>
        public byte* Modifier;
    }
    /// <summary>
    /// The multiple select modifier ptr
    /// </summary>
    public unsafe struct MultipleSelectModifierPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public MultipleSelectModifier* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSelectModifierPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public MultipleSelectModifierPtr(MultipleSelectModifier* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSelectModifierPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public MultipleSelectModifierPtr(IntPtr nativePtr) => NativePtr = (MultipleSelectModifier*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator MultipleSelectModifierPtr(MultipleSelectModifier* nativePtr) => new MultipleSelectModifierPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator MultipleSelectModifier* (MultipleSelectModifierPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator MultipleSelectModifierPtr(IntPtr nativePtr) => new MultipleSelectModifierPtr(nativePtr);
        /// <summary>
        /// Gets or sets the value of the modifier
        /// </summary>
        public IntPtr Modifier { get => (IntPtr)NativePtr->Modifier; set => NativePtr->Modifier = (byte*)value; }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            imnodesNative.MultipleSelectModifier_destroy((MultipleSelectModifier*)(NativePtr));
        }
    }
}
