// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EngineSurfaceComprehensiveTest.cs
// 
//  Author:Pablo Perdomo Falcon
//  Web:https://www.pabllopf.dev/
// 
//  --------------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.App.Engine;
using Alis.App.Engine.Configuration;
using Alis.App.Engine.Core;
using Alis.App.Engine.Demos;
using Alis.App.Engine.Entity;
using Alis.App.Engine.Fonts;
using Alis.App.Engine.Icons;
using Alis.App.Engine.Shaders;
using Alis.App.Engine.Shortcut;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Deterministic API-surface tests for Engine module without booting native rendering runtime.
    /// </summary>
    public class EngineSurfaceComprehensiveTest
    {
        [Fact]
        public void Engine_Type_ShouldExposePublicRunMethod()
        {
            Type type = typeof(Engine);
            MethodInfo run = type.GetMethod("Run", BindingFlags.Public | BindingFlags.Instance);

            Assert.True(type.IsClass);
            Assert.True(type.IsPublic);
            Assert.NotNull(run);
            Assert.Equal(typeof(void), run.ReturnType);
            Assert.Empty(run.GetParameters());
        }

        [Fact]
        public void Program_InternalType_ShouldExposeMainSignature()
        {
            Type programType = typeof(Engine).Assembly.GetType("Alis.App.Engine.Program", throwOnError: true);
            MethodInfo main = programType.GetMethod("Main", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(programType);
            Assert.True(programType.IsClass);
            Assert.True(programType.IsAbstract);
            Assert.True(programType.IsSealed);

            Assert.NotNull(main);
            Assert.Equal(typeof(void), main.ReturnType);

            ParameterInfo[] parameters = main.GetParameters();
            Assert.Single(parameters);
            Assert.Equal(typeof(string[]), parameters[0].ParameterType);
        }

        [Fact]
        public void MarkerInterfaces_ShouldExistWithExpectedVisibility()
        {
            Assert.True(typeof(IFont).IsInterface);
            Assert.True(typeof(IIcon).IsInterface);
            Assert.True(typeof(IConfiguration).IsInterface);
            Assert.True(typeof(IRenderable).IsInterface);
            Assert.True(typeof(IHasSpaceWork).IsInterface);
            Assert.True(typeof(IDemo).IsInterface);
            Assert.True(typeof(IShader).IsInterface);
        }

        [Fact]
        public void LayoutConfiguration_ShouldImplementIConfiguration()
        {
            Assert.Contains(typeof(IConfiguration), typeof(LayoutConfiguration).GetInterfaces());
        }

        [Fact]
        public void IconImplementations_ShouldImplementIIcon()
        {
            Assert.Contains(typeof(IIcon), typeof(FolderIcon).GetInterfaces());
            Assert.Contains(typeof(IIcon), typeof(SegoeIcon).GetInterfaces());
        }

        [Fact]
        public void FontClasses_ShouldBeInstantiablePublicClasses()
        {
            object jetbrain = Activator.CreateInstance(typeof(JetbrainFont));
            object hack = Activator.CreateInstance(typeof(HackFont));

            Assert.NotNull(jetbrain);
            Assert.NotNull(hack);
            Assert.True(typeof(JetbrainFont).IsPublic);
            Assert.True(typeof(HackFont).IsPublic);
        }

        [Fact]
        public void DemoInterface_ShouldDefineInitializeStartRun()
        {
            MethodInfo initialize = typeof(IDemo).GetMethod("Initialize");
            MethodInfo start = typeof(IDemo).GetMethod("Start");
            MethodInfo run = typeof(IDemo).GetMethod("Run");

            Assert.NotNull(initialize);
            Assert.NotNull(start);
            Assert.NotNull(run);
            Assert.Equal(typeof(void), initialize.ReturnType);
            Assert.Equal(typeof(void), start.ReturnType);
            Assert.Equal(typeof(void), run.ReturnType);
        }

        [Fact]
        public void ShaderImplementations_ShouldProvideNonEmptyCode()
        {
            IShader vertex = new VertexShader();
            IShader fragment = new FragmentShader();

            Assert.False(string.IsNullOrWhiteSpace(vertex.ShaderCode));
            Assert.False(string.IsNullOrWhiteSpace(fragment.ShaderCode));
            Assert.Contains("#version", vertex.ShaderCode);
            Assert.Contains("#version", fragment.ShaderCode);
        }

        [Fact]
        public void VertexShader_Code_ShouldContainExpectedSymbols()
        {
            string code = new VertexShader().ShaderCode;

            Assert.Contains("ProjMtx", code);
            Assert.Contains("Position", code);
            Assert.Contains("Frag_UV", code);
            Assert.Contains("gl_Position", code);
        }

        [Fact]
        public void FragmentShader_Code_ShouldContainExpectedSymbols()
        {
            string code = new FragmentShader().ShaderCode;

            Assert.Contains("Texture", code);
            Assert.Contains("Frag_Color", code);
            Assert.Contains("Out_Color", code);
            Assert.Contains("texture(", code);
        }

        [Fact]
        public void Project_Constructor_ShouldAssignPrimaryFields()
        {
            Project project = new Project("Game", "/tmp", "Connected", "Today", "2026.1");

            Assert.Equal("Game", project.Name);
            Assert.Equal("/tmp", project.Path);
            Assert.Equal("Connected", project.CloudStatus);
            Assert.Equal("Today", project.ModifiedDate);
            Assert.Equal("2026.1", project.EditorVersion);
        }

        [Fact]
        public void Project_ParameterlessInitialization_ShouldUseStructDefaults()
        {
            Project project = new Project();

            Assert.Null(project.Name);
            Assert.Null(project.Path);
            Assert.Null(project.CloudStatus);
            Assert.Null(project.ModifiedDate);
            Assert.Null(project.EditorVersion);
            Assert.Null(project.Version);
            Assert.Null(project.LastModified);
        }

        [Fact]
        public void Project_Setters_ShouldMutateOptionalFields()
        {
            Project project = new Project("A", "B", "C", "D", "E")
            {
                Version = "9.9.9",
                LastModified = "Now"
            };

            Assert.Equal("9.9.9", project.Version);
            Assert.Equal("Now", project.LastModified);
        }

        [Theory]
        [InlineData(nameof(Project.Name), "_name_")]
        [InlineData(nameof(Project.Path), "_path_")]
        [InlineData(nameof(Project.CloudStatus), "_cloudStatus_")]
        [InlineData(nameof(Project.ModifiedDate), "_modifiedDate_")]
        [InlineData(nameof(Project.EditorVersion), "_editorVersion_")]
        [InlineData(nameof(Project.Version), "_version_")]
        [InlineData(nameof(Project.LastModified), "_lastModified_")]
        public void Project_Properties_ShouldHaveExpectedJsonNativeAttribute(string propertyName, string expectedName)
        {
            PropertyInfo property = typeof(Project).GetProperty(propertyName);
            JsonNativePropertyNameAttribute attribute = property.GetCustomAttribute<JsonNativePropertyNameAttribute>();

            Assert.NotNull(attribute);
            Assert.Equal(expectedName, attribute.Name);
        }

        [Fact]
        public void Project_Type_ShouldBeSerializableSequentialStruct()
        {
            Type projectType = typeof(Project);

            Assert.True(projectType.IsValueType);
            Assert.NotNull(projectType.GetCustomAttribute<SerializableAttribute>());

            StructLayoutAttribute layout = projectType.StructLayoutAttribute;
            Assert.NotNull(layout);
            Assert.Equal(LayoutKind.Sequential, layout.Value);
            Assert.Equal(1, layout.Pack);
        }

        [Fact]
        public void Shortcuts_ShouldInitializeWithNonEmptyValues()
        {
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.NewScene));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.OpenScene));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Save));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.SaveAs));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Undo));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Redo));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Play));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Pause));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Cut));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Copy));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Paste));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Duplicate));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Delete));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Search));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.AboutAlis));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Preferences));
            Assert.False(string.IsNullOrWhiteSpace(Shortcuts.QuitAlis));
        }

        [Fact]
        public void Shortcuts_ShouldUseExpectedPlatformPrefixOrDeleteKey()
        {
            if (OperatingSystem.IsMacOS())
            {
                Assert.StartsWith("Cmd+", Shortcuts.NewScene);
                Assert.Equal("Cmd+Backspace", Shortcuts.Delete);
            }
            else if (OperatingSystem.IsLinux() || OperatingSystem.IsWindows())
            {
                Assert.StartsWith("Ctrl+", Shortcuts.NewScene);
                Assert.Equal("Del", Shortcuts.Delete);
            }
            else
            {
                // Unknown platform in runtime context: only verify deterministic non-empty initialization.
                Assert.False(string.IsNullOrWhiteSpace(Shortcuts.NewScene));
                Assert.False(string.IsNullOrWhiteSpace(Shortcuts.Delete));
            }
        }

        [Fact]
        public void InternalActiveButtonEnum_ShouldContainExpectedMembers()
        {
            Type enumType = typeof(Engine).Assembly.GetType("Alis.App.Engine.Windows.ActiveButton", throwOnError: true);
            string[] names = Enum.GetNames(enumType);

            Assert.True(enumType.IsEnum);
            Assert.Equal(7, names.Length);
            Assert.Contains("None", names);
            Assert.Contains("HandSpock", names);
            Assert.Contains("ArrowsAlt", names);
            Assert.Contains("Cogs", names);
            Assert.Contains("InfoCircle", names);
            Assert.Contains("Grid", names);
            Assert.Contains("User", names);
        }

        [Fact]
        public void InternalIWindow_ShouldInheritFromExpectedEngineCoreInterfaces()
        {
            Type iwindowType = typeof(Engine).Assembly.GetType("Alis.App.Engine.Windows.IWindow", throwOnError: true);
            Type[] interfaces = iwindowType.GetInterfaces();

            Assert.True(iwindowType.IsInterface);
            Assert.Contains(typeof(IRenderable), interfaces);
            Assert.Contains(typeof(IHasSpaceWork), interfaces);
            Assert.NotNull(iwindowType.GetMethod("Initialize"));
            Assert.NotNull(iwindowType.GetMethod("Start"));
        }

        [Fact]
        public void ShaderStructs_ShouldBeReadonlyValueTypes()
        {
            Assert.True(typeof(VertexShader).IsValueType);
            Assert.True(typeof(FragmentShader).IsValueType);

            Assert.True(typeof(VertexShader).CustomAttributes.Any(a => a.AttributeType.Name.Contains("IsReadOnly")));
            Assert.True(typeof(FragmentShader).CustomAttributes.Any(a => a.AttributeType.Name.Contains("IsReadOnly")));
        }
    }
}

