using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The objective runtime class
    /// </summary>
    public static unsafe class ObjectiveCRuntime
    {
        /// <summary>
        /// The obj library
        /// </summary>
        private const string ObjCLibrary = "/usr/lib/libobjc.A.dylib";

        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, float a);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, double a);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, CGRect a);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, uint b);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, NSRange b);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLSize a, MTLSize b);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="e">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr c, UIntPtr d, MTLSize e);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLClearColor a);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, CGSize a);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, UIntPtr b, UIntPtr c);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, void* a, UIntPtr b, UIntPtr c);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="e">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLPrimitiveType a, UIntPtr b, UIntPtr c, UIntPtr d, UIntPtr e);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLPrimitiveType a, UIntPtr b, UIntPtr c, UIntPtr d);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, NSRange a);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, UIntPtr a);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLCommandBufferHandler a);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, UIntPtr b);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLViewport a);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLScissorRect a);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, void* a, uint b, UIntPtr c);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, void* a, UIntPtr b);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="e">The </param>
        /// <param name="f">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLPrimitiveType a, UIntPtr b, MTLIndexType c, IntPtr d, UIntPtr e, UIntPtr f);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, MTLPrimitiveType a, MTLBuffer b, UIntPtr c);

        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="e">The </param>
        /// <param name="f">The </param>
        /// <param name="g">The </param>
        /// <param name="h">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(
            IntPtr receiver,
            Selector selector,
            MTLPrimitiveType a,
            UIntPtr b,
            MTLIndexType c,
            IntPtr d,
            UIntPtr e,
            UIntPtr f,
            IntPtr g,
            UIntPtr h);

        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="e">The </param>
        /// <param name="f">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(
            IntPtr receiver,
            Selector selector,
            MTLPrimitiveType a,
            MTLIndexType b,
            MTLBuffer c,
            UIntPtr d,
            MTLBuffer e,
            UIntPtr f);

        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="e">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(
            IntPtr receiver,
            Selector selector,
            MTLBuffer a,
            UIntPtr b,
            MTLBuffer c,
            UIntPtr d,
            UIntPtr e);

        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="e">The </param>
        /// <param name="f">The </param>
        /// <param name="g">The </param>
        /// <param name="h">The </param>
        /// <param name="i">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(
            IntPtr receiver,
            Selector selector,
            IntPtr a,
            UIntPtr b,
            UIntPtr c,
            UIntPtr d,
            MTLSize e,
            IntPtr f,
            UIntPtr g,
            UIntPtr h,
            MTLOrigin i);

        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="e">The </param>
        /// <param name="f">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(
            IntPtr receiver,
            Selector selector,
            MTLRegion a,
            UIntPtr b,
            UIntPtr c,
            IntPtr d,
            UIntPtr e,
            UIntPtr f);

        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="e">The </param>
        /// <param name="f">The </param>
        /// <param name="g">The </param>
        /// <param name="h">The </param>
        /// <param name="i">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(
            IntPtr receiver,
            Selector selector,
            MTLTexture a,
            UIntPtr b,
            UIntPtr c,
            MTLOrigin d,
            MTLSize e,
            MTLBuffer f,
            UIntPtr g,
            UIntPtr h,
            UIntPtr i);

        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="sourceTexture">The source texture</param>
        /// <param name="sourceSlice">The source slice</param>
        /// <param name="sourceLevel">The source level</param>
        /// <param name="sourceOrigin">The source origin</param>
        /// <param name="sourceSize">The source size</param>
        /// <param name="destinationTexture">The destination texture</param>
        /// <param name="destinationSlice">The destination slice</param>
        /// <param name="destinationLevel">The destination level</param>
        /// <param name="destinationOrigin">The destination origin</param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(
            IntPtr receiver,
            Selector selector,
            MTLTexture sourceTexture,
            UIntPtr sourceSlice,
            UIntPtr sourceLevel,
            MTLOrigin sourceOrigin,
            MTLSize sourceSize,
            MTLTexture destinationTexture,
            UIntPtr destinationSlice,
            UIntPtr destinationLevel,
            MTLOrigin destinationOrigin);

        /// <summary>
        /// Bytes the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The byte</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern byte* bytePtr_objc_msgSend(IntPtr receiver, Selector selector);
        /// <summary>
        /// Cgs the size objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The cg size</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern CGSize CGSize_objc_msgSend(IntPtr receiver, Selector selector);


        /// <summary>
        /// Bytes the objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The byte</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern byte byte_objc_msgSend(IntPtr receiver, Selector selector);
        /// <summary>
        /// Bools the 8 objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The bool</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern Bool8 bool8_objc_msgSend(IntPtr receiver, Selector selector);
        /// <summary>
        /// Bools the 8 objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <returns>The bool</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern Bool8 bool8_objc_msgSend(IntPtr receiver, Selector selector, UIntPtr a);
        /// <summary>
        /// Bools the 8 objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <returns>The bool</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern Bool8 bool8_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a);
        /// <summary>
        /// Bools the 8 objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern Bool8 bool8_objc_msgSend(IntPtr receiver, Selector selector, UIntPtr a, IntPtr b);
        /// <summary>
        /// Bools the 8 objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <returns>The bool</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern Bool8 bool8_objc_msgSend(IntPtr receiver, Selector selector, uint a);
        /// <summary>
        /// Uints the objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The uint</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern uint uint_objc_msgSend(IntPtr receiver, Selector selector);
        /// <summary>
        /// Floats the objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The float</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern float float_objc_msgSend(IntPtr receiver, Selector selector);
        /// <summary>
        /// Cgs the float objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The cg float</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]

        public static extern CGFloat CGFloat_objc_msgSend(IntPtr receiver, Selector selector);
        /// <summary>
        /// Doubles the objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The double</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern double double_objc_msgSend(IntPtr receiver, Selector selector);
        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector);
        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a);
        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="error">The error</param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, out NSError error);
        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, uint a, uint b, NSRange c, NSRange d);
        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="error">The error</param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, MTLComputePipelineDescriptor a, uint b, IntPtr c, out NSError error);
        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, uint a);
        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, UIntPtr a);

        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="error">The error</param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, out NSError error);
        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, UIntPtr b);
        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, UIntPtr b, MTLResourceOptions c);
        /// <summary>
        /// Ints the ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, void* a, UIntPtr b, MTLResourceOptions c);
        /// <summary>
        /// Us the int ptr objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern UIntPtr UIntPtr_objc_msgSend(IntPtr receiver, Selector selector);

        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The</returns>
        public static T objc_msgSend<T>(IntPtr receiver, Selector selector) where T : struct
        {
            IntPtr value = IntPtr_objc_msgSend(receiver, selector);
            return Unsafe.AsRef<T>(&value);
        }
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <returns>The</returns>
        public static T objc_msgSend<T>(IntPtr receiver, Selector selector, IntPtr a) where T : struct
        {
            IntPtr value = IntPtr_objc_msgSend(receiver, selector, a);
            return Unsafe.AsRef<T>(&value);
        }
        /// <summary>
        /// Strings the objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The string</returns>
        public static string string_objc_msgSend(IntPtr receiver, Selector selector)
        {
            return objc_msgSend<NSString>(receiver, selector).GetValue();
        }

        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="b">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, byte b);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="b">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, Bool8 b);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="b">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, uint b);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, float a, float b, float c, float d);
        /// <summary>
        /// Objcs the msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <param name="b">The </param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern void objc_msgSend(IntPtr receiver, Selector selector, IntPtr b);

        /// <summary>
        /// Objcs the msg send stret using the specified ret ptr
        /// </summary>
        /// <param name="retPtr">The ret ptr</param>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend_stret")]
        public static extern void objc_msgSend_stret(void* retPtr, IntPtr receiver, Selector selector);
        /// <summary>
        /// Objcs the msg send stret using the specified receiver
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The ret</returns>
        public static T objc_msgSend_stret<T>(IntPtr receiver, Selector selector) where T : struct
        {
            T ret = default(T);
            objc_msgSend_stret(Unsafe.AsPointer(ref ret), receiver, selector);
            return ret;
        }

        /// <summary>
        /// Mtls the clear color objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The mtl clear color</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern MTLClearColor MTLClearColor_objc_msgSend(IntPtr receiver, Selector selector);

        /// <summary>
        /// Mtls the size objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The mtl size</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern MTLSize MTLSize_objc_msgSend(IntPtr receiver, Selector selector);

        /// <summary>
        /// Cgs the rect objc msg send using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <param name="selector">The selector</param>
        /// <returns>The cg rect</returns>
        [DllImport(ObjCLibrary, EntryPoint = "objc_msgSend")]
        public static extern CGRect CGRect_objc_msgSend(IntPtr receiver, Selector selector);

        // TODO: This should check the current processor type, struct size, etc.
        // At the moment there is no need because all existing occurences of
        // this can safely use the non-stret versions everywhere.
        /// <summary>
        /// Describes whether use stret
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public static bool UseStret<T>() => false;

        /// <summary>
        /// Sels the register name using the specified name ptr
        /// </summary>
        /// <param name="namePtr">The name ptr</param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary)]
        public static extern IntPtr sel_registerName(byte* namePtr);

        /// <summary>
        /// Sels the get name using the specified selector
        /// </summary>
        /// <param name="selector">The selector</param>
        /// <returns>The byte</returns>
        [DllImport(ObjCLibrary)]
        public static extern byte* sel_getName(IntPtr selector);

        /// <summary>
        /// Objcs the get using the specified name ptr
        /// </summary>
        /// <param name="namePtr">The name ptr</param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary)]
        public static extern IntPtr objc_getClass(byte* namePtr);

        /// <summary>
        /// Objects the get using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The obj class</returns>
        [DllImport(ObjCLibrary)]
        public static extern ObjCClass object_getClass(IntPtr obj);

        /// <summary>
        /// Classes the get property using the specified cls
        /// </summary>
        /// <param name="cls">The cls</param>
        /// <param name="namePtr">The name ptr</param>
        /// <returns>The int ptr</returns>
        [DllImport(ObjCLibrary)]
        public static extern IntPtr class_getProperty(ObjCClass cls, byte* namePtr);

        /// <summary>
        /// Classes the get name using the specified cls
        /// </summary>
        /// <param name="cls">The cls</param>
        /// <returns>The byte</returns>
        [DllImport(ObjCLibrary)]
        public static extern byte* class_getName(ObjCClass cls);

        /// <summary>
        /// Properties the copy attribute value using the specified property
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="attributeNamePtr">The attribute name ptr</param>
        /// <returns>The byte</returns>
        [DllImport(ObjCLibrary)]
        public static extern byte* property_copyAttributeValue(IntPtr property, byte* attributeNamePtr);

        /// <summary>
        /// Methods the get name using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <returns>The selector</returns>
        [DllImport(ObjCLibrary)]
        public static extern Selector method_getName(ObjectiveCMethod method);

        /// <summary>
        /// Classes the copy method list using the specified cls
        /// </summary>
        /// <param name="cls">The cls</param>
        /// <param name="outCount">The out count</param>
        /// <returns>The objective method</returns>
        [DllImport(ObjCLibrary)]
        public static extern ObjectiveCMethod* class_copyMethodList(ObjCClass cls, out uint outCount);

        /// <summary>
        /// Frees the receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        [DllImport(ObjCLibrary)]
        public static extern void free(IntPtr receiver);
        /// <summary>
        /// Retains the receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        public static void retain(IntPtr receiver) => objc_msgSend(receiver, "retain");
        /// <summary>
        /// Releases the receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        public static void release(IntPtr receiver) => objc_msgSend(receiver, "release");
        /// <summary>
        /// Gets the retain count using the specified receiver
        /// </summary>
        /// <param name="receiver">The receiver</param>
        /// <returns>The ulong</returns>
        public static ulong GetRetainCount(IntPtr receiver) => (ulong)UIntPtr_objc_msgSend(receiver, "retainCount");
    }
}
