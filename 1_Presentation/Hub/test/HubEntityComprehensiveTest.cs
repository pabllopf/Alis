// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HubEntityComprehensiveTest.cs
// 
//  Author:Pablo Perdomo Falcon
//  Web:https://www.pabllopf.dev/
// 
//  --------------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.App.Hub.Entity;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.App.Hub.Test
{
    /// <summary>
    ///     Comprehensive tests for deterministic entity models in Hub module.
    /// </summary>
    public class HubEntityComprehensiveTest
    {
        /// <summary>
        /// Tests that project constructor should assign mandatory fields
        /// </summary>
        [Fact]
        public void Project_Constructor_ShouldAssignMandatoryFields()
        {
            Project project = new Project("MyGame", "/tmp/game", "Synced", "2026-04-04", "2026.1.0");

            Assert.Equal("MyGame", project.Name);
            Assert.Equal("/tmp/game", project.Path);
            Assert.Equal("Synced", project.CloudStatus);
            Assert.Equal("2026-04-04", project.ModifiedDate);
            Assert.Equal("2026.1.0", project.EditorVersion);
        }

        /// <summary>
        /// Tests that project parameterless initialization should use struct default values
        /// </summary>
        [Fact]
        public void Project_ParameterlessInitialization_ShouldUseStructDefaultValues()
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

        /// <summary>
        /// Tests that project setters should allow overriding optional fields
        /// </summary>
        [Fact]
        public void Project_Setters_ShouldAllowOverridingOptionalFields()
        {
            Project project = new Project("A", "B", "C", "D", "E")
            {
                Version = "2.0.0",
                LastModified = "Today",
                Name = "Renamed"
            };

            Assert.Equal("Renamed", project.Name);
            Assert.Equal("2.0.0", project.Version);
            Assert.Equal("Today", project.LastModified);
        }

        /// <summary>
        /// Tests that project properties should expose expected json native property names
        /// </summary>
        /// <param name="propertyName">The property name</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [InlineData(nameof(Project.Name), "_name_")]
        [InlineData(nameof(Project.Path), "_path_")]
        [InlineData(nameof(Project.CloudStatus), "_cloudStatus_")]
        [InlineData(nameof(Project.ModifiedDate), "_modifiedDate_")]
        [InlineData(nameof(Project.EditorVersion), "_editorVersion_")]
        [InlineData(nameof(Project.Version), "_version_")]
        [InlineData(nameof(Project.LastModified), "_lastModified_")]
        public void Project_Properties_ShouldExposeExpectedJsonNativePropertyNames(string propertyName, string expected)
        {
            PropertyInfo property = typeof(Project).GetProperty(propertyName);
            JsonNativePropertyNameAttribute attribute = property.GetCustomAttribute<JsonNativePropertyNameAttribute>();

            Assert.NotNull(attribute);
            Assert.Equal(expected, attribute.Name);
        }

        /// <summary>
        /// Tests that installed version constructor should assign read only properties
        /// </summary>
        [Fact]
        public void InstalledVersion_Constructor_ShouldAssignReadOnlyProperties()
        {
            InstalledVersion version = new InstalledVersion("1.2.3", "2026-03-01", "/Applications/Alis");

            Assert.Equal("1.2.3", version.Version);
            Assert.Equal("2026-03-01", version.ReleaseDate);
            Assert.Equal("/Applications/Alis", version.InstallPath);
        }

        /// <summary>
        /// Tests that learning resource constructor should assign read only properties
        /// </summary>
        [Fact]
        public void LearningResource_Constructor_ShouldAssignReadOnlyProperties()
        {
            LearningResource resource = new LearningResource("Docs", "Official docs", "https://example.com/docs");

            Assert.Equal("Docs", resource.Title);
            Assert.Equal("Official docs", resource.Description);
            Assert.Equal("https://example.com/docs", resource.Url);
        }

        /// <summary>
        /// Tests that gallery item constructor should assign all properties
        /// </summary>
        [Fact]
        public void GalleryItem_Constructor_ShouldAssignAllProperties()
        {
            GalleryItem item = new GalleryItem("img.bmp", "Title", "Desc", "https://site", 200, 300);

            Assert.Equal("img.bmp", item.ImagePath);
            Assert.Equal("Title", item.Title);
            Assert.Equal("Desc", item.Description);
            Assert.Equal("https://site", item.Url);
            Assert.Equal(200, item.Height);
            Assert.Equal(300, item.Width);
        }

        /// <summary>
        /// Tests that gallery item setters should mutate properties
        /// </summary>
        [Fact]
        public void GalleryItem_Setters_ShouldMutateProperties()
        {
            GalleryItem item = new GalleryItem("a", "b", "c", "d", 1, 2)
            {
                ImagePath = "new.bmp",
                Title = "New",
                Description = "New desc",
                Url = "https://new",
                Height = 999,
                Width = 555
            };

            Assert.Equal("new.bmp", item.ImagePath);
            Assert.Equal("New", item.Title);
            Assert.Equal("New desc", item.Description);
            Assert.Equal("https://new", item.Url);
            Assert.Equal(999, item.Height);
            Assert.Equal(555, item.Width);
        }

        /// <summary>
        /// Tests that gallery constructor should create exactly 10 items
        /// </summary>
        [Fact]
        public void Gallery_Constructor_ShouldCreateExactly10Items()
        {
            Gallery gallery = new Gallery();

            Assert.NotNull(gallery.Items);
            Assert.Equal(10, gallery.Items.Count);
            Assert.All(gallery.Items, item => Assert.NotNull(item));
        }

        /// <summary>
        /// Tests that gallery items should have expected generated titles and descriptions
        /// </summary>
        [Fact]
        public void Gallery_Items_ShouldHaveExpectedGeneratedTitlesAndDescriptions()
        {
            Gallery gallery = new Gallery();

            for (int i = 0; i < 10; i++)
            {
                GalleryItem item = gallery.Items[i];
                Assert.Equal($"Item {i + 1}", item.Title);
                Assert.Equal($"Description for Item {i + 1}", item.Description);
                Assert.Equal($"https://www.example.com/{i + 1}", item.Url);
            }
        }

        /// <summary>
        /// Tests that gallery items should use expected dimensions and image pattern
        /// </summary>
        [Fact]
        public void Gallery_Items_ShouldUseExpectedDimensionsAndImagePattern()
        {
            Gallery gallery = new Gallery();

            Assert.All(gallery.Items, item =>
            {
                Assert.Equal(100, item.Height);
                Assert.Equal(100, item.Width);
                Assert.Equal("Hub_logo.bmp", item.ImagePath);
            });
        }

        /// <summary>
        /// Tests that gallery items list should allow external mutations
        /// </summary>
        [Fact]
        public void Gallery_ItemsList_ShouldAllowExternalMutations()
        {
            Gallery gallery = new Gallery();
            int initialCount = gallery.Items.Count;

            gallery.Items.Add(new GalleryItem("x", "y", "z", "u", 1, 1));

            Assert.Equal(initialCount + 1, gallery.Items.Count);
        }

        /// <summary>
        /// Tests that project type should be serializable sequential struct
        /// </summary>
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

        /// <summary>
        /// Tests that hub entity types should expose expected public surface
        /// </summary>
        [Fact]
        public void HubEntity_Types_ShouldExposeExpectedPublicSurface()
        {
            Assert.True(typeof(Project).GetProperties(BindingFlags.Public | BindingFlags.Instance).Length >= 7);
            Assert.True(typeof(InstalledVersion).GetProperties(BindingFlags.Public | BindingFlags.Instance).Length == 3);
            Assert.True(typeof(LearningResource).GetProperties(BindingFlags.Public | BindingFlags.Instance).Length == 3);
            Assert.True(typeof(GalleryItem).GetProperties(BindingFlags.Public | BindingFlags.Instance).Length == 6);
            Assert.Single(typeof(Gallery).GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Where(f => f.Name == "Items"));
        }
    }
}
