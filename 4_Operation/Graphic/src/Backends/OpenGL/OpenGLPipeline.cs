using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static Alis.Core.Graphic.Backends.OpenGL.OpenGLNative;
using static Alis.Core.Graphic.Backends.OpenGL.OpenGLUtil;

namespace Alis.Core.Graphic.Backends.OpenGL
{
    /// <summary>
    /// The open gl pipeline class
    /// </summary>
    /// <seealso cref="Pipeline"/>
    /// <seealso cref="OpenGLDeferredResource"/>
    internal unsafe class OpenGLPipeline : Pipeline, OpenGLDeferredResource
    {
        /// <summary>
        /// The gl invalid index
        /// </summary>
        private const uint GL_INVALID_INDEX = 0xFFFFFFFF;
        /// <summary>
        /// The gd
        /// </summary>
        private readonly OpenGLGraphicsDevice _gd;

#if !VALIDATE_USAGE
        /// <summary>
        /// Gets the value of the resource layouts
        /// </summary>
        public ResourceLayout[] ResourceLayouts { get; }
#endif

        // Graphics Pipeline
        /// <summary>
        /// Gets the value of the graphics shaders
        /// </summary>
        public Shader[] GraphicsShaders { get; }
        /// <summary>
        /// Gets the value of the vertex layouts
        /// </summary>
        public VertexLayoutDescription[] VertexLayouts { get; }
        /// <summary>
        /// Gets the value of the blend state
        /// </summary>
        public BlendStateDescription BlendState { get; }
        /// <summary>
        /// Gets the value of the depth stencil state
        /// </summary>
        public DepthStencilStateDescription DepthStencilState { get; }
        /// <summary>
        /// Gets the value of the rasterizer state
        /// </summary>
        public RasterizerStateDescription RasterizerState { get; }
        /// <summary>
        /// Gets the value of the primitive topology
        /// </summary>
        public PrimitiveTopology PrimitiveTopology { get; }

        // Compute Pipeline
        /// <summary>
        /// Gets the value of the is compute pipeline
        /// </summary>
        public override bool IsComputePipeline { get; }
        /// <summary>
        /// Gets the value of the compute shader
        /// </summary>
        public Shader ComputeShader { get; }

        /// <summary>
        /// The program
        /// </summary>
        private uint _program;
        /// <summary>
        /// The dispose requested
        /// </summary>
        private bool _disposeRequested;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// The set infos
        /// </summary>
        private SetBindingsInfo[] _setInfos;

        /// <summary>
        /// Gets the value of the vertex strides
        /// </summary>
        public int[] VertexStrides { get; }

        /// <summary>
        /// Gets the value of the program
        /// </summary>
        public uint Program => _program;

        /// <summary>
        /// Gets the uniform buffer count using the specified set slot
        /// </summary>
        /// <param name="setSlot">The set slot</param>
        /// <returns>The uint</returns>
        public uint GetUniformBufferCount(uint setSlot) => _setInfos[setSlot].UniformBufferCount;
        /// <summary>
        /// Gets the shader storage buffer count using the specified set slot
        /// </summary>
        /// <param name="setSlot">The set slot</param>
        /// <returns>The uint</returns>
        public uint GetShaderStorageBufferCount(uint setSlot) => _setInfos[setSlot].ShaderStorageBufferCount;

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposeRequested;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLPipeline"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public OpenGLPipeline(OpenGLGraphicsDevice gd, ref GraphicsPipelineDescription description)
            : base(ref description)
        {
            _gd = gd;
            GraphicsShaders = Util.ShallowClone(description.ShaderSet.Shaders);
            VertexLayouts = Util.ShallowClone(description.ShaderSet.VertexLayouts);
            BlendState = description.BlendState.ShallowClone();
            DepthStencilState = description.DepthStencilState;
            RasterizerState = description.RasterizerState;
            PrimitiveTopology = description.PrimitiveTopology;

            int numVertexBuffers = description.ShaderSet.VertexLayouts.Length;
            VertexStrides = new int[numVertexBuffers];
            for (int i = 0; i < numVertexBuffers; i++)
            {
                VertexStrides[i] = (int)description.ShaderSet.VertexLayouts[i].Stride;
            }

#if !VALIDATE_USAGE
            ResourceLayouts = Util.ShallowClone(description.ResourceLayouts);
#endif
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLPipeline"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public OpenGLPipeline(OpenGLGraphicsDevice gd, ref ComputePipelineDescription description)
            : base(ref description)
        {
            _gd = gd;
            IsComputePipeline = true;
            ComputeShader = description.ComputeShader;
            VertexStrides = Array.Empty<int>();
#if !VALIDATE_USAGE
            ResourceLayouts = Util.ShallowClone(description.ResourceLayouts);
#endif
        }

        /// <summary>
        /// Gets or sets the value of the created
        /// </summary>
        public bool Created { get; private set; }

        /// <summary>
        /// Ensures the resources created
        /// </summary>
        public void EnsureResourcesCreated()
        {
            if (!Created)
            {
                CreateGLResources();
            }
        }

        /// <summary>
        /// Creates the gl resources
        /// </summary>
        private void CreateGLResources()
        {
            if (!IsComputePipeline)
            {
                CreateGraphicsGLResources();
            }
            else
            {
                CreateComputeGLResources();
            }

            Created = true;
        }

        /// <summary>
        /// Creates the graphics gl resources
        /// </summary>
        /// <exception cref="VeldridException">Error linking GL program: {log}</exception>
        private void CreateGraphicsGLResources()
        {
            _program = glCreateProgram();
            CheckLastError();
            foreach (Shader stage in GraphicsShaders)
            {
                OpenGLShader glShader = Util.AssertSubtype<Shader, OpenGLShader>(stage);
                glShader.EnsureResourcesCreated();
                glAttachShader(_program, glShader.Shader);
                CheckLastError();
            }

            uint slot = 0;
            foreach (VertexLayoutDescription layoutDesc in VertexLayouts)
            {
                for (int i = 0; i < layoutDesc.Elements.Length; i++)
                {
                    BindAttribLocation(slot, layoutDesc.Elements[i].Name);
                    slot += 1;
                }
            }

            glLinkProgram(_program);
            CheckLastError();

#if DEBUG && GL_VALIDATE_VERTEX_INPUT_ELEMENTS
            slot = 0;
            foreach (VertexLayoutDescription layoutDesc in VertexLayouts)
            {
                for (int i = 0; i < layoutDesc.Elements.Length; i++)
                {
                    int location = GetAttribLocation(layoutDesc.Elements[i].Name);
                    if (location == -1)
                    {
                        throw new VeldridException("There was no attribute variable with the name " + layoutDesc.Elements[i].Name);
                    }

                    slot += 1;
                }
            }
#endif

            int linkStatus;
            glGetProgramiv(_program, GetProgramParameterName.LinkStatus, &linkStatus);
            CheckLastError();
            if (linkStatus != 1)
            {
                byte* infoLog = stackalloc byte[4096];
                uint bytesWritten;
                glGetProgramInfoLog(_program, 4096, &bytesWritten, infoLog);
                CheckLastError();
                string log = Encoding.UTF8.GetString(infoLog, (int)bytesWritten);
                throw new VeldridException($"Error linking GL program: {log}");
            }

            ProcessResourceSetLayouts(ResourceLayouts);
        }

        /// <summary>
        /// Gets the attrib location using the specified element name
        /// </summary>
        /// <param name="elementName">The element name</param>
        /// <returns>The location</returns>
        int GetAttribLocation(string elementName)
        {
            int byteCount = Encoding.UTF8.GetByteCount(elementName) + 1;
            byte* elementNamePtr = stackalloc byte[byteCount];
            fixed (char* charPtr = elementName)
            {
                int bytesWritten = Encoding.UTF8.GetBytes(charPtr, elementName.Length, elementNamePtr, byteCount);
                Debug.Assert(bytesWritten == byteCount - 1);
            }
            elementNamePtr[byteCount - 1] = 0; // Add null terminator.

            int location = glGetAttribLocation(_program, elementNamePtr);
            return location;
        }

        /// <summary>
        /// Binds the attrib location using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="elementName">The element name</param>
        void BindAttribLocation(uint slot, string elementName)
        {
            int byteCount = Encoding.UTF8.GetByteCount(elementName) + 1;
            byte* elementNamePtr = stackalloc byte[byteCount];
            fixed (char* charPtr = elementName)
            {
                int bytesWritten = Encoding.UTF8.GetBytes(charPtr, elementName.Length, elementNamePtr, byteCount);
                Debug.Assert(bytesWritten == byteCount - 1);
            }
            elementNamePtr[byteCount - 1] = 0; // Add null terminator.

            glBindAttribLocation(_program, slot, elementNamePtr);
            CheckLastError();
        }

        /// <summary>
        /// Processes the resource set layouts using the specified layouts
        /// </summary>
        /// <param name="layouts">The layouts</param>
        private void ProcessResourceSetLayouts(ResourceLayout[] layouts)
        {
            int resourceLayoutCount = layouts.Length;
            _setInfos = new SetBindingsInfo[resourceLayoutCount];
            int lastTextureLocation = -1;
            int relativeTextureIndex = -1;
            int relativeImageIndex = -1;
            uint storageBlockIndex = 0; // Tracks OpenGL ES storage buffers.
            for (uint setSlot = 0; setSlot < resourceLayoutCount; setSlot++)
            {
                ResourceLayout setLayout = layouts[setSlot];
                OpenGLResourceLayout glSetLayout = Util.AssertSubtype<ResourceLayout, OpenGLResourceLayout>(setLayout);
                ResourceLayoutElementDescription[] resources = glSetLayout.Elements;

                Dictionary<uint, OpenGLUniformBinding> uniformBindings = new Dictionary<uint, OpenGLUniformBinding>();
                Dictionary<uint, OpenGLTextureBindingSlotInfo> textureBindings = new Dictionary<uint, OpenGLTextureBindingSlotInfo>();
                Dictionary<uint, OpenGLSamplerBindingSlotInfo> samplerBindings = new Dictionary<uint, OpenGLSamplerBindingSlotInfo>();
                Dictionary<uint, OpenGLShaderStorageBinding> storageBufferBindings = new Dictionary<uint, OpenGLShaderStorageBinding>();

                List<int> samplerTrackedRelativeTextureIndices = new List<int>();
                for (uint i = 0; i < resources.Length; i++)
                {
                    ResourceLayoutElementDescription resource = resources[i];
                    if (resource.Kind == ResourceKind.UniformBuffer)
                    {
                        uint blockIndex = GetUniformBlockIndex(resource.Name);
                        if (blockIndex != GL_INVALID_INDEX)
                        {
                            int blockSize;
                            glGetActiveUniformBlockiv(_program, blockIndex, ActiveUniformBlockParameter.UniformBlockDataSize, &blockSize);
                            CheckLastError();
                            uniformBindings[i] = new OpenGLUniformBinding(_program, blockIndex, (uint)blockSize);
                        }
                    }
                    else if (resource.Kind == ResourceKind.TextureReadOnly)
                    {
                        int location = GetUniformLocation(resource.Name);
                        relativeTextureIndex += 1;
                        textureBindings[i] = new OpenGLTextureBindingSlotInfo() { RelativeIndex = relativeTextureIndex, UniformLocation = location };
                        lastTextureLocation = location;
                        samplerTrackedRelativeTextureIndices.Add(relativeTextureIndex);
                    }
                    else if (resource.Kind == ResourceKind.TextureReadWrite)
                    {
                        int location = GetUniformLocation(resource.Name);
                        relativeImageIndex += 1;
                        textureBindings[i] = new OpenGLTextureBindingSlotInfo() { RelativeIndex = relativeImageIndex, UniformLocation = location };
                    }
                    else if (resource.Kind == ResourceKind.StructuredBufferReadOnly
                        || resource.Kind == ResourceKind.StructuredBufferReadWrite)
                    {
                        uint storageBlockBinding;
                        if (_gd.BackendType == GraphicsBackend.OpenGL)
                        {
                            storageBlockBinding = GetProgramResourceIndex(resource.Name, ProgramInterface.ShaderStorageBlock);
                        }
                        else
                        {
                            storageBlockBinding = storageBlockIndex;
                            storageBlockIndex += 1;
                        }

                        storageBufferBindings[i] = new OpenGLShaderStorageBinding(storageBlockBinding);
                    }
                    else
                    {
                        Debug.Assert(resource.Kind == ResourceKind.Sampler);

                        int[] relativeIndices = samplerTrackedRelativeTextureIndices.ToArray();
                        samplerTrackedRelativeTextureIndices.Clear();
                        samplerBindings[i] = new OpenGLSamplerBindingSlotInfo()
                        {
                            RelativeIndices = relativeIndices
                        };
                    }
                }

                _setInfos[setSlot] = new SetBindingsInfo(uniformBindings, textureBindings, samplerBindings, storageBufferBindings);
            }
        }

        /// <summary>
        /// Gets the uniform block index using the specified resource name
        /// </summary>
        /// <param name="resourceName">The resource name</param>
        /// <returns>The block index</returns>
        uint GetUniformBlockIndex(string resourceName)
        {
            int byteCount = Encoding.UTF8.GetByteCount(resourceName) + 1;
            byte* resourceNamePtr = stackalloc byte[byteCount];
            fixed (char* charPtr = resourceName)
            {
                int bytesWritten = Encoding.UTF8.GetBytes(charPtr, resourceName.Length, resourceNamePtr, byteCount);
                Debug.Assert(bytesWritten == byteCount - 1);
            }
            resourceNamePtr[byteCount - 1] = 0; // Add null terminator.

            uint blockIndex = glGetUniformBlockIndex(_program, resourceNamePtr);
            CheckLastError();
#if DEBUG && GL_VALIDATE_SHADER_RESOURCE_NAMES
            if (blockIndex == GL_INVALID_INDEX)
            {
                uint uniformBufferIndex = 0;
                uint bufferNameByteCount = 64;
                byte* bufferNamePtr = stackalloc byte[(int)bufferNameByteCount];
                var names = new List<string>();
                while (true)
                {
                    uint actualLength;
                    glGetActiveUniformBlockName(_program, uniformBufferIndex, bufferNameByteCount, &actualLength, bufferNamePtr);

                    if (glGetError() != 0)
                    {
                        break;
                    }

                    string name = Encoding.UTF8.GetString(bufferNamePtr, (int)actualLength);
                    names.Add(name);
                    uniformBufferIndex++;
                }

                throw new VeldridException($"Unable to bind uniform buffer \"{resourceName}\" by name. Valid names for this pipeline are: {string.Join(", ", names)}");
            }
#endif
            return blockIndex;
        }

        /// <summary>
        /// Gets the uniform location using the specified resource name
        /// </summary>
        /// <param name="resourceName">The resource name</param>
        /// <returns>The location</returns>
        int GetUniformLocation(string resourceName)
        {
            int byteCount = Encoding.UTF8.GetByteCount(resourceName) + 1;
            byte* resourceNamePtr = stackalloc byte[byteCount];
            fixed (char* charPtr = resourceName)
            {
                int bytesWritten = Encoding.UTF8.GetBytes(charPtr, resourceName.Length, resourceNamePtr, byteCount);
                Debug.Assert(bytesWritten == byteCount - 1);
            }
            resourceNamePtr[byteCount - 1] = 0; // Add null terminator.

            int location = glGetUniformLocation(_program, resourceNamePtr);
            CheckLastError();

#if DEBUG && GL_VALIDATE_SHADER_RESOURCE_NAMES
            if (location == -1)
            {
                ReportInvalidUniformName(resourceName);
            }
#endif
            return location;
        }

        /// <summary>
        /// Gets the program resource index using the specified resource name
        /// </summary>
        /// <param name="resourceName">The resource name</param>
        /// <param name="resourceType">The resource type</param>
        /// <returns>The binding</returns>
        uint GetProgramResourceIndex(string resourceName, ProgramInterface resourceType)
        {
            int byteCount = Encoding.UTF8.GetByteCount(resourceName) + 1;

            byte* resourceNamePtr = stackalloc byte[byteCount];
            fixed (char* charPtr = resourceName)
            {
                int bytesWritten = Encoding.UTF8.GetBytes(charPtr, resourceName.Length, resourceNamePtr, byteCount);
                Debug.Assert(bytesWritten == byteCount - 1);
            }
            resourceNamePtr[byteCount - 1] = 0; // Add null terminator.

            uint binding = glGetProgramResourceIndex(_program, resourceType, resourceNamePtr);
            CheckLastError();
#if DEBUG && GL_VALIDATE_SHADER_RESOURCE_NAMES
            if (binding == GL_INVALID_INDEX)
            {
                ReportInvalidResourceName(resourceName, resourceType);
            }
#endif
            return binding;
        }

#if DEBUG && GL_VALIDATE_SHADER_RESOURCE_NAMES
        void ReportInvalidUniformName(string uniformName)
        {
            uint uniformIndex = 0;
            uint resourceNameByteCount = 64;
            byte* resourceNamePtr = stackalloc byte[(int)resourceNameByteCount];

            var names = new List<string>();
            while (true)
            {
                uint actualLength;
                int size;
                uint type;
                glGetActiveUniform(_program, uniformIndex, resourceNameByteCount,
                    &actualLength, &size, &type, resourceNamePtr);

                if (glGetError() != 0)
                {
                    break;
                }

                string name = Encoding.UTF8.GetString(resourceNamePtr, (int)actualLength);
                names.Add(name);
                uniformIndex++;
            }

            throw new VeldridException($"Unable to bind uniform \"{uniformName}\" by name. Valid names for this pipeline are: {string.Join(", ", names)}");
        }

        void ReportInvalidResourceName(string resourceName, ProgramInterface resourceType)
        {
            // glGetProgramInterfaceiv and glGetProgramResourceName are only available in 4.3+
            if (_gd.ApiVersion.Major < 4 || (_gd.ApiVersion.Major == 4 && _gd.ApiVersion.Minor < 3))
            {
                return;
            }

            int maxLength = 0;
            int resourceCount = 0;
            glGetProgramInterfaceiv(_program, resourceType, ProgramInterfaceParameterName.MaxNameLength, &maxLength);
            glGetProgramInterfaceiv(_program, resourceType, ProgramInterfaceParameterName.ActiveResources, &resourceCount);
            byte* resourceNamePtr = stackalloc byte[maxLength];

            var names = new List<string>();
            for (uint resourceIndex = 0; resourceIndex < resourceCount; resourceIndex++)
            {
                uint actualLength;
                glGetProgramResourceName(_program, resourceType, resourceIndex, (uint)maxLength, &actualLength, resourceNamePtr);

                if (glGetError() != 0)
                {
                    break;
                }

                string name = Encoding.UTF8.GetString(resourceNamePtr, (int)actualLength);
                names.Add(name);
            }

            throw new VeldridException($"Unable to bind {resourceType} \"{resourceName}\" by name. Valid names for this pipeline are: {string.Join(", ", names)}");
        }
#endif

        /// <summary>
        /// Creates the compute gl resources
        /// </summary>
        /// <exception cref="VeldridException">Error linking GL program: {log}</exception>
        private void CreateComputeGLResources()
        {
            _program = glCreateProgram();
            CheckLastError();
            OpenGLShader glShader = Util.AssertSubtype<Shader, OpenGLShader>(ComputeShader);
            glShader.EnsureResourcesCreated();
            glAttachShader(_program, glShader.Shader);
            CheckLastError();

            glLinkProgram(_program);
            CheckLastError();

            int linkStatus;
            glGetProgramiv(_program, GetProgramParameterName.LinkStatus, &linkStatus);
            CheckLastError();
            if (linkStatus != 1)
            {
                byte* infoLog = stackalloc byte[4096];
                uint bytesWritten;
                glGetProgramInfoLog(_program, 4096, &bytesWritten, infoLog);
                CheckLastError();
                string log = Encoding.UTF8.GetString(infoLog, (int)bytesWritten);
                throw new VeldridException($"Error linking GL program: {log}");
            }

            ProcessResourceSetLayouts(ResourceLayouts);
        }

        /// <summary>
        /// Describes whether this instance get uniform binding for slot
        /// </summary>
        /// <param name="set">The set</param>
        /// <param name="slot">The slot</param>
        /// <param name="binding">The binding</param>
        /// <returns>The bool</returns>
        public bool GetUniformBindingForSlot(uint set, uint slot, out OpenGLUniformBinding binding)
        {
            Debug.Assert(_setInfos != null, "EnsureResourcesCreated must be called before accessing resource set information.");
            SetBindingsInfo setInfo = _setInfos[set];
            return setInfo.GetUniformBindingForSlot(slot, out binding);
        }

        /// <summary>
        /// Describes whether this instance get texture binding info
        /// </summary>
        /// <param name="set">The set</param>
        /// <param name="slot">The slot</param>
        /// <param name="binding">The binding</param>
        /// <returns>The bool</returns>
        public bool GetTextureBindingInfo(uint set, uint slot, out OpenGLTextureBindingSlotInfo binding)
        {
            Debug.Assert(_setInfos != null, "EnsureResourcesCreated must be called before accessing resource set information.");
            SetBindingsInfo setInfo = _setInfos[set];
            return setInfo.GetTextureBindingInfo(slot, out binding);
        }

        /// <summary>
        /// Describes whether this instance get sampler binding info
        /// </summary>
        /// <param name="set">The set</param>
        /// <param name="slot">The slot</param>
        /// <param name="binding">The binding</param>
        /// <returns>The bool</returns>
        public bool GetSamplerBindingInfo(uint set, uint slot, out OpenGLSamplerBindingSlotInfo binding)
        {
            Debug.Assert(_setInfos != null, "EnsureResourcesCreated must be called before accessing resource set information.");
            SetBindingsInfo setInfo = _setInfos[set];
            return setInfo.GetSamplerBindingInfo(slot, out binding);
        }

        /// <summary>
        /// Describes whether this instance get storage buffer binding for slot
        /// </summary>
        /// <param name="set">The set</param>
        /// <param name="slot">The slot</param>
        /// <param name="binding">The binding</param>
        /// <returns>The bool</returns>
        public bool GetStorageBufferBindingForSlot(uint set, uint slot, out OpenGLShaderStorageBinding binding)
        {
            Debug.Assert(_setInfos != null, "EnsureResourcesCreated must be called before accessing resource set information.");
            SetBindingsInfo setInfo = _setInfos[set];
            return setInfo.GetStorageBufferBindingForSlot(slot, out binding);

        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposeRequested)
            {
                _disposeRequested = true;
                _gd.EnqueueDisposal(this);
            }
        }

        /// <summary>
        /// Destroys the gl resources
        /// </summary>
        public void DestroyGLResources()
        {
            if (!_disposed)
            {
                _disposed = true;
                glDeleteProgram(_program);
                CheckLastError();
            }
        }
    }

    /// <summary>
    /// The set bindings info
    /// </summary>
    internal struct SetBindingsInfo
    {
        /// <summary>
        /// The uniform bindings
        /// </summary>
        private readonly Dictionary<uint, OpenGLUniformBinding> _uniformBindings;
        /// <summary>
        /// The texture bindings
        /// </summary>
        private readonly Dictionary<uint, OpenGLTextureBindingSlotInfo> _textureBindings;
        /// <summary>
        /// The sampler bindings
        /// </summary>
        private readonly Dictionary<uint, OpenGLSamplerBindingSlotInfo> _samplerBindings;
        /// <summary>
        /// The storage buffer bindings
        /// </summary>
        private readonly Dictionary<uint, OpenGLShaderStorageBinding> _storageBufferBindings;

        /// <summary>
        /// Gets the value of the uniform buffer count
        /// </summary>
        public uint UniformBufferCount { get; }
        /// <summary>
        /// Gets the value of the shader storage buffer count
        /// </summary>
        public uint ShaderStorageBufferCount { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetBindingsInfo"/> class
        /// </summary>
        /// <param name="uniformBindings">The uniform bindings</param>
        /// <param name="textureBindings">The texture bindings</param>
        /// <param name="samplerBindings">The sampler bindings</param>
        /// <param name="storageBufferBindings">The storage buffer bindings</param>
        public SetBindingsInfo(
            Dictionary<uint, OpenGLUniformBinding> uniformBindings,
            Dictionary<uint, OpenGLTextureBindingSlotInfo> textureBindings,
            Dictionary<uint, OpenGLSamplerBindingSlotInfo> samplerBindings,
            Dictionary<uint, OpenGLShaderStorageBinding> storageBufferBindings)
        {
            _uniformBindings = uniformBindings;
            UniformBufferCount = (uint)uniformBindings.Count;
            _textureBindings = textureBindings;
            _samplerBindings = samplerBindings;
            _storageBufferBindings = storageBufferBindings;
            ShaderStorageBufferCount = (uint)storageBufferBindings.Count;
        }

        /// <summary>
        /// Describes whether this instance get texture binding info
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="binding">The binding</param>
        /// <returns>The bool</returns>
        public bool GetTextureBindingInfo(uint slot, out OpenGLTextureBindingSlotInfo binding)
        {
            return _textureBindings.TryGetValue(slot, out binding);
        }

        /// <summary>
        /// Describes whether this instance get sampler binding info
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="binding">The binding</param>
        /// <returns>The bool</returns>
        public bool GetSamplerBindingInfo(uint slot, out OpenGLSamplerBindingSlotInfo binding)
        {
            return _samplerBindings.TryGetValue(slot, out binding);
        }

        /// <summary>
        /// Describes whether this instance get uniform binding for slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="binding">The binding</param>
        /// <returns>The bool</returns>
        public bool GetUniformBindingForSlot(uint slot, out OpenGLUniformBinding binding)
        {
            return _uniformBindings.TryGetValue(slot, out binding);
        }

        /// <summary>
        /// Describes whether this instance get storage buffer binding for slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="binding">The binding</param>
        /// <returns>The bool</returns>
        public bool GetStorageBufferBindingForSlot(uint slot, out OpenGLShaderStorageBinding binding)
        {
            return _storageBufferBindings.TryGetValue(slot, out binding);
        }
    }

    /// <summary>
    /// The open gl texture binding slot info
    /// </summary>
    internal struct OpenGLTextureBindingSlotInfo
    {
        /// <summary>
        /// The relative index of this binding with relation to the other textures used by a shader.
        /// Generally, this is the texture unit that the binding will be placed into.
        /// </summary>
        public int RelativeIndex;
        /// <summary>
        /// The uniform location of the binding in the shader program.
        /// </summary>
        public int UniformLocation;
    }

    /// <summary>
    /// The open gl sampler binding slot info
    /// </summary>
    internal struct OpenGLSamplerBindingSlotInfo
    {
        /// <summary>
        /// The relative indices of this binding with relation to the other textures used by a shader.
        /// Generally, these are the texture units that the sampler will be bound to.
        /// </summary>
        public int[] RelativeIndices;
    }

    /// <summary>
    /// The open gl uniform binding class
    /// </summary>
    internal class OpenGLUniformBinding
    {
        /// <summary>
        /// Gets the value of the program
        /// </summary>
        public uint Program { get; }
        /// <summary>
        /// Gets the value of the block location
        /// </summary>
        public uint BlockLocation { get; }
        /// <summary>
        /// Gets the value of the block size
        /// </summary>
        public uint BlockSize { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLUniformBinding"/> class
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="blockLocation">The block location</param>
        /// <param name="blockSize">The block size</param>
        public OpenGLUniformBinding(uint program, uint blockLocation, uint blockSize)
        {
            Program = program;
            BlockLocation = blockLocation;
            BlockSize = blockSize;
        }
    }

    /// <summary>
    /// The open gl shader storage binding class
    /// </summary>
    internal class OpenGLShaderStorageBinding
    {
        /// <summary>
        /// Gets the value of the storage block binding
        /// </summary>
        public uint StorageBlockBinding { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLShaderStorageBinding"/> class
        /// </summary>
        /// <param name="storageBlockBinding">The storage block binding</param>
        public OpenGLShaderStorageBinding(uint storageBlockBinding)
        {
            StorageBlockBinding = storageBlockBinding;
        }
    }
}
