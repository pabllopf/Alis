using System;
using System.Runtime.InteropServices;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl device
    /// </summary>
    public unsafe struct MTLDevice
    {
        /// <summary>
        /// The metal framework
        /// </summary>
        private const string MetalFramework = "/System/Library/Frameworks/Metal.framework/Metal";

        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(MTLDevice device) => device.NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="MTLDevice"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public MTLDevice(IntPtr nativePtr) => NativePtr = nativePtr;

        /// <summary>
        /// Gets the value of the name
        /// </summary>
        public string name => string_objc_msgSend(NativePtr, sel_name);
        /// <summary>
        /// Gets the value of the max threads per threadgroup
        /// </summary>
        public MTLSize maxThreadsPerThreadgroup
        {
            get
            {
                if (UseStret<MTLSize>())
                {
                    return objc_msgSend_stret<MTLSize>(this, sel_maxThreadsPerThreadgroup);
                }
                else
                {
                    return MTLSize_objc_msgSend(this, sel_maxThreadsPerThreadgroup);
                }
            }
        }

        /// <summary>
        /// News the library with source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="options">The options</param>
        /// <exception cref="Exception"></exception>
        /// <returns>The mtl library</returns>
        public MTLLibrary newLibraryWithSource(string source, MTLCompileOptions options)
        {
            NSString sourceNSS = NSString.New(source);

            IntPtr library = IntPtr_objc_msgSend(NativePtr, sel_newLibraryWithSource,
                sourceNSS,
                options,
                out NSError error);

            release(sourceNSS.NativePtr);

            if (library == IntPtr.Zero)
            {
                throw new Exception("Shader compilation failed: " + error.localizedDescription);
            }

            return new MTLLibrary(library);
        }

        /// <summary>
        /// News the library with data using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <exception cref="Exception"></exception>
        /// <returns>The mtl library</returns>
        public MTLLibrary newLibraryWithData(DispatchData data)
        {
            IntPtr library = IntPtr_objc_msgSend(NativePtr, sel_newLibraryWithData, data.NativePtr, out NSError error);

            if (library == IntPtr.Zero)
            {
                throw new Exception("Unable to load Metal library: " + error.localizedDescription);
            }

            return new MTLLibrary(library);
        }

        /// <summary>
        /// News the render pipeline state with descriptor using the specified desc
        /// </summary>
        /// <param name="desc">The desc</param>
        /// <exception cref="Exception"></exception>
        /// <returns>The mtl render pipeline state</returns>
        public MTLRenderPipelineState newRenderPipelineStateWithDescriptor(MTLRenderPipelineDescriptor desc)
        {
            IntPtr ret = IntPtr_objc_msgSend(NativePtr, sel_newRenderPipelineStateWithDescriptor,
                desc.NativePtr,
                out NSError error);

            if (error.NativePtr != IntPtr.Zero)
            {
                throw new Exception("Failed to create new MTLRenderPipelineState: " + error.localizedDescription);
            }

            return new MTLRenderPipelineState(ret);
        }

        /// <summary>
        /// News the compute pipeline state with descriptor using the specified descriptor
        /// </summary>
        /// <param name="descriptor">The descriptor</param>
        /// <exception cref="Exception"></exception>
        /// <returns>The mtl compute pipeline state</returns>
        public MTLComputePipelineState newComputePipelineStateWithDescriptor(
            MTLComputePipelineDescriptor descriptor)
        {
            IntPtr ret = IntPtr_objc_msgSend(NativePtr, sel_newComputePipelineStateWithDescriptor,
                descriptor,
                0,
                IntPtr.Zero,
                out NSError error);

            if (error.NativePtr != IntPtr.Zero)
            {
                throw new Exception("Failed to create new MTLRenderPipelineState: " + error.localizedDescription);
            }

            return new MTLComputePipelineState(ret);
        }

        /// <summary>
        /// News the command queue
        /// </summary>
        /// <returns>The mtl command queue</returns>
        public MTLCommandQueue newCommandQueue() => objc_msgSend<MTLCommandQueue>(NativePtr, sel_newCommandQueue);

        /// <summary>
        /// News the buffer using the specified pointer
        /// </summary>
        /// <param name="pointer">The pointer</param>
        /// <param name="length">The length</param>
        /// <param name="options">The options</param>
        /// <returns>The mtl buffer</returns>
        public MTLBuffer newBuffer(void* pointer, UIntPtr length, MTLResourceOptions options)
        {
            IntPtr buffer = IntPtr_objc_msgSend(NativePtr, sel_newBufferWithBytes,
                pointer,
                length,
                options);
            return new MTLBuffer(buffer);
        }

        /// <summary>
        /// News the buffer with length options using the specified length
        /// </summary>
        /// <param name="length">The length</param>
        /// <param name="options">The options</param>
        /// <returns>The mtl buffer</returns>
        public MTLBuffer newBufferWithLengthOptions(UIntPtr length, MTLResourceOptions options)
        {
            IntPtr buffer = IntPtr_objc_msgSend(NativePtr, sel_newBufferWithLength, length, options);
            return new MTLBuffer(buffer);
        }

        /// <summary>
        /// News the texture with descriptor using the specified descriptor
        /// </summary>
        /// <param name="descriptor">The descriptor</param>
        /// <returns>The mtl texture</returns>
        public MTLTexture newTextureWithDescriptor(MTLTextureDescriptor descriptor)
            => objc_msgSend<MTLTexture>(NativePtr, sel_newTextureWithDescriptor, descriptor.NativePtr);

        /// <summary>
        /// News the sampler state with descriptor using the specified descriptor
        /// </summary>
        /// <param name="descriptor">The descriptor</param>
        /// <returns>The mtl sampler state</returns>
        public MTLSamplerState newSamplerStateWithDescriptor(MTLSamplerDescriptor descriptor)
            => objc_msgSend<MTLSamplerState>(NativePtr, sel_newSamplerStateWithDescriptor, descriptor.NativePtr);

        /// <summary>
        /// News the depth stencil state with descriptor using the specified descriptor
        /// </summary>
        /// <param name="descriptor">The descriptor</param>
        /// <returns>The mtl depth stencil state</returns>
        public MTLDepthStencilState newDepthStencilStateWithDescriptor(MTLDepthStencilDescriptor descriptor)
            => objc_msgSend<MTLDepthStencilState>(NativePtr, sel_newDepthStencilStateWithDescriptor, descriptor.NativePtr);

        /// <summary>
        /// Supportses the texture sample count using the specified sample count
        /// </summary>
        /// <param name="sampleCount">The sample count</param>
        /// <returns>The bool</returns>
        public Bool8 supportsTextureSampleCount(UIntPtr sampleCount)
            => bool8_objc_msgSend(NativePtr, sel_supportsTextureSampleCount, sampleCount);

        /// <summary>
        /// Supportses the feature set using the specified feature set
        /// </summary>
        /// <param name="featureSet">The feature set</param>
        /// <returns>The bool</returns>
        public Bool8 supportsFeatureSet(MTLFeatureSet featureSet)
            => bool8_objc_msgSend(NativePtr, sel_supportsFeatureSet, (uint)featureSet);

        /// <summary>
        /// Gets the value of the is depth 24 stencil 8 pixel format supported
        /// </summary>
        public Bool8 isDepth24Stencil8PixelFormatSupported
            => bool8_objc_msgSend(NativePtr, sel_isDepth24Stencil8PixelFormatSupported);

        /// <summary>
        /// Mtls the create system default device
        /// </summary>
        /// <returns>The mtl device</returns>
        [DllImport(MetalFramework)]
        public static extern MTLDevice MTLCreateSystemDefaultDevice();

        /// <summary>
        /// Mtls the copy all devices
        /// </summary>
        /// <returns>The ns array</returns>
        [DllImport(MetalFramework)]
        public static extern NSArray MTLCopyAllDevices();

        /// <summary>
        /// The sel name
        /// </summary>
        private static readonly Selector sel_name = "name";
        /// <summary>
        /// The sel maxthreadsperthreadgroup
        /// </summary>
        private static readonly Selector sel_maxThreadsPerThreadgroup = "maxThreadsPerThreadgroup";
        /// <summary>
        /// The sel newlibrarywithsource
        /// </summary>
        private static readonly Selector sel_newLibraryWithSource = "newLibraryWithSource:options:error:";
        /// <summary>
        /// The sel newlibrarywithdata
        /// </summary>
        private static readonly Selector sel_newLibraryWithData = "newLibraryWithData:error:";
        /// <summary>
        /// The sel newrenderpipelinestatewithdescriptor
        /// </summary>
        private static readonly Selector sel_newRenderPipelineStateWithDescriptor = "newRenderPipelineStateWithDescriptor:error:";
        /// <summary>
        /// The sel newcomputepipelinestatewithdescriptor
        /// </summary>
        private static readonly Selector sel_newComputePipelineStateWithDescriptor = "newComputePipelineStateWithDescriptor:options:reflection:error:";
        /// <summary>
        /// The sel newcommandqueue
        /// </summary>
        private static readonly Selector sel_newCommandQueue = "newCommandQueue";
        /// <summary>
        /// The sel newbufferwithbytes
        /// </summary>
        private static readonly Selector sel_newBufferWithBytes = "newBufferWithBytes:length:options:";
        /// <summary>
        /// The sel newbufferwithlength
        /// </summary>
        private static readonly Selector sel_newBufferWithLength = "newBufferWithLength:options:";
        /// <summary>
        /// The sel newtexturewithdescriptor
        /// </summary>
        private static readonly Selector sel_newTextureWithDescriptor = "newTextureWithDescriptor:";
        /// <summary>
        /// The sel newsamplerstatewithdescriptor
        /// </summary>
        private static readonly Selector sel_newSamplerStateWithDescriptor = "newSamplerStateWithDescriptor:";
        /// <summary>
        /// The sel newdepthstencilstatewithdescriptor
        /// </summary>
        private static readonly Selector sel_newDepthStencilStateWithDescriptor = "newDepthStencilStateWithDescriptor:";
        /// <summary>
        /// The sel supportstexturesamplecount
        /// </summary>
        private static readonly Selector sel_supportsTextureSampleCount = "supportsTextureSampleCount:";
        /// <summary>
        /// The sel supportsfeatureset
        /// </summary>
        private static readonly Selector sel_supportsFeatureSet = "supportsFeatureSet:";
        /// <summary>
        /// The sel isdepth24stencil8pixelformatsupported
        /// </summary>
        private static readonly Selector sel_isDepth24Stencil8PixelFormatSupported = "isDepth24Stencil8PixelFormatSupported";
    }
}