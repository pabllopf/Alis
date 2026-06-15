// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HubEdgeCaseTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Reflection;
using Alis.App.Hub.Entity;
using Xunit;

namespace Alis.App.Hub.Test
{
    /// <summary>
    ///     Edge-case tests for Hub entities covering null inputs, empty strings, and boundary values.
    /// </summary>
    public class HubEdgeCaseTests
    {
        #region Project Edge Cases

        /// <summary>
        ///     Tests that Project with null inputs stores null values without throwing
        /// </summary>
        [Fact]
        public void Project_WithNullInputs_ShouldStoreNullValues()
        {
            Project project = new Project(null, null, null, null, null);

            Assert.Null(project.Name);
            Assert.Null(project.Path);
            Assert.Null(project.CloudStatus);
            Assert.Null(project.ModifiedDate);
            Assert.Null(project.EditorVersion);
        }

        /// <summary>
        ///     Tests that Project with empty strings stores empty values
        /// </summary>
        [Fact]
        public void Project_WithEmptyStrings_ShouldStoreEmptyValues()
        {
            Project project = new Project("", "", "", "", "");

            Assert.Equal(string.Empty, project.Name);
            Assert.Equal(string.Empty, project.Path);
            Assert.Equal(string.Empty, project.CloudStatus);
            Assert.Equal(string.Empty, project.ModifiedDate);
            Assert.Equal(string.Empty, project.EditorVersion);
        }

        /// <summary>
        ///     Tests that Project with minimal valid values stores them correctly
        /// </summary>
        [Fact]
        public void Project_WithMinimalValidValues_ShouldStoreAllValues()
        {
            Project project = new Project("A", "B", "C", "D", "E");

            Assert.Equal("A", project.Name);
            Assert.Equal("B", project.Path);
            Assert.Equal("C", project.CloudStatus);
            Assert.Equal("D", project.ModifiedDate);
            Assert.Equal("E", project.EditorVersion);
        }

        /// <summary>
        ///     Tests that Project default values for Version and LastModified are "1.0.0" and "Never"
        /// </summary>
        [Fact]
        public void Project_DefaultValues_ShouldBeOneDotZeroAndNever()
        {
            Project project = new Project("A", "B", "C", "D", "E");

            Assert.Equal("1.0.0", project.Version);
            Assert.Equal("Never", project.LastModified);
        }

        /// <summary>
        ///     Tests that Project setters can override default Version and LastModified
        /// </summary>
        [Fact]
        public void Project_Setters_ShouldOverrideDefaultVersionAndLastModified()
        {
            Project project = new Project("A", "B", "C", "D", "E")
            {
                Version = "2.5.0",
                LastModified = "Today"
            };

            Assert.Equal("2.5.0", project.Version);
            Assert.Equal("Today", project.LastModified);
        }

        /// <summary>
        ///     Tests that Project with whitespace-only strings stores them as-is
        /// </summary>
        [Fact]
        public void Project_WithWhitespaceStrings_ShouldStoreWhitespaceAsIs()
        {
            Project project = new Project("   ", "  \t\n", "   ", "  ", "   ");

            Assert.Equal("   ", project.Name);
            Assert.Equal("  \t\n", project.Path);
            Assert.Equal("   ", project.CloudStatus);
            Assert.Equal("  ", project.ModifiedDate);
            Assert.Equal("   ", project.EditorVersion);
        }

        #endregion

        #region InstalledVersion Edge Cases

        /// <summary>
        ///     Tests that InstalledVersion with null inputs stores null values without throwing
        /// </summary>
        [Fact]
        public void InstalledVersion_WithNullInputs_ShouldStoreNullValues()
        {
            InstalledVersion version = new InstalledVersion(null, null, null);

            Assert.Null(version.Version);
            Assert.Null(version.ReleaseDate);
            Assert.Null(version.InstallPath);
        }

        /// <summary>
        ///     Tests that InstalledVersion with empty strings stores empty values
        /// </summary>
        [Fact]
        public void InstalledVersion_WithEmptyStrings_ShouldStoreEmptyValues()
        {
            InstalledVersion version = new InstalledVersion("", "", "");

            Assert.Equal(string.Empty, version.Version);
            Assert.Equal(string.Empty, version.ReleaseDate);
            Assert.Equal(string.Empty, version.InstallPath);
        }

        /// <summary>
        ///     Tests that InstalledVersion with valid values stores them correctly
        /// </summary>
        [Fact]
        public void InstalledVersion_WithValidValues_ShouldStoreAllValues()
        {
            InstalledVersion version = new InstalledVersion("v2.0.0", "2026-12-31", "/usr/local/alis");

            Assert.Equal("v2.0.0", version.Version);
            Assert.Equal("2026-12-31", version.ReleaseDate);
            Assert.Equal("/usr/local/alis", version.InstallPath);
        }

        /// <summary>
        ///     Tests that InstalledVersion properties are read-only (no setters)
        /// </summary>
        [Fact]
        public void InstalledVersion_Properties_ShouldBeReadOnly()
        {
            PropertyInfo versionProperty = typeof(InstalledVersion).GetProperty(nameof(InstalledVersion.Version));
            PropertyInfo releaseDateProperty = typeof(InstalledVersion).GetProperty(nameof(InstalledVersion.ReleaseDate));
            PropertyInfo installPathProperty = typeof(InstalledVersion).GetProperty(nameof(InstalledVersion.InstallPath));

            Assert.NotNull(versionProperty);
            Assert.NotNull(releaseDateProperty);
            Assert.NotNull(installPathProperty);

            // All properties should have only a getter (no setter)
            Assert.False(versionProperty!.CanWrite);
            Assert.False(releaseDateProperty!.CanWrite);
            Assert.False(installPathProperty!.CanWrite);
        }

        #endregion

        #region LearningResource Edge Cases

        /// <summary>
        ///     Tests that LearningResource with null inputs stores null values without throwing
        /// </summary>
        [Fact]
        public void LearningResource_WithNullInputs_ShouldStoreNullValues()
        {
            LearningResource resource = new LearningResource(null, null, null);

            Assert.Null(resource.Title);
            Assert.Null(resource.Description);
            Assert.Null(resource.Url);
        }

        /// <summary>
        ///     Tests that LearningResource with empty strings stores empty values
        /// </summary>
        [Fact]
        public void LearningResource_WithEmptyStrings_ShouldStoreEmptyValues()
        {
            LearningResource resource = new LearningResource("", "", "");

            Assert.Equal(string.Empty, resource.Title);
            Assert.Equal(string.Empty, resource.Description);
            Assert.Equal(string.Empty, resource.Url);
        }

        /// <summary>
        ///     Tests that LearningResource with valid values stores them correctly
        /// </summary>
        [Fact]
        public void LearningResource_WithValidValues_ShouldStoreAllValues()
        {
            LearningResource resource = new LearningResource("Guide", "A comprehensive guide", "https://guide.dev");

            Assert.Equal("Guide", resource.Title);
            Assert.Equal("A comprehensive guide", resource.Description);
            Assert.Equal("https://guide.dev", resource.Url);
        }

        /// <summary>
        ///     Tests that LearningResource properties are read-only (no setters)
        /// </summary>
        [Fact]
        public void LearningResource_Properties_ShouldBeReadOnly()
        {
            PropertyInfo titleProperty = typeof(LearningResource).GetProperty(nameof(LearningResource.Title));
            PropertyInfo descProperty = typeof(LearningResource).GetProperty(nameof(LearningResource.Description));
            PropertyInfo urlProperty = typeof(LearningResource).GetProperty(nameof(LearningResource.Url));

            Assert.NotNull(titleProperty);
            Assert.NotNull(descProperty);
            Assert.NotNull(urlProperty);

            // All properties should have only a getter (no setter)
            Assert.False(titleProperty!.CanWrite);
            Assert.False(descProperty!.CanWrite);
            Assert.False(urlProperty!.CanWrite);
        }

        #endregion

        #region GalleryItem Edge Cases

        /// <summary>
        ///     Tests that GalleryItem with null inputs stores null values without throwing
        /// </summary>
        [Fact]
        public void GalleryItem_WithNullInputs_ShouldStoreNullValues()
        {
            GalleryItem item = new GalleryItem(null, null, null, null, 0, 0);

            Assert.Null(item.ImagePath);
            Assert.Null(item.Title);
            Assert.Null(item.Description);
            Assert.Null(item.Url);
            Assert.Equal(0, item.Height);
            Assert.Equal(0, item.Width);
        }

        /// <summary>
        ///     Tests that GalleryItem with empty strings stores empty values
        /// </summary>
        [Fact]
        public void GalleryItem_WithEmptyStrings_ShouldStoreEmptyValues()
        {
            GalleryItem item = new GalleryItem("", "", "", "", 0, 0);

            Assert.Equal(string.Empty, item.ImagePath);
            Assert.Equal(string.Empty, item.Title);
            Assert.Equal(string.Empty, item.Description);
            Assert.Equal(string.Empty, item.Url);
            Assert.Equal(0, item.Height);
            Assert.Equal(0, item.Width);
        }

        /// <summary>
        ///     Tests that GalleryItem with zero dimensions stores zero values
        /// </summary>
        [Fact]
        public void GalleryItem_WithZeroDimensions_ShouldStoreZeroValues()
        {
            GalleryItem item = new GalleryItem("img.bmp", "Title", "Desc", "https://url", 0, 0);

            Assert.Equal("img.bmp", item.ImagePath);
            Assert.Equal("Title", item.Title);
            Assert.Equal("Desc", item.Description);
            Assert.Equal("https://url", item.Url);
            Assert.Equal(0, item.Height);
            Assert.Equal(0, item.Width);
        }

        /// <summary>
        ///     Tests that GalleryItem with large dimensions stores them correctly
        /// </summary>
        [Fact]
        public void GalleryItem_WithLargeDimensions_ShouldStoreLargeValues()
        {
            GalleryItem item = new GalleryItem("large.bmp", "Big Title", "Big Description", "https://big.dev", 1920, 1080);

            Assert.Equal("large.bmp", item.ImagePath);
            Assert.Equal("Big Title", item.Title);
            Assert.Equal("Big Description", item.Description);
            Assert.Equal("https://big.dev", item.Url);
            Assert.Equal(1920, item.Height);
            Assert.Equal(1080, item.Width);
        }

        /// <summary>
        ///     Tests that GalleryItem setters can mutate all properties
        /// </summary>
        [Fact]
        public void GalleryItem_Setters_ShouldMutateAllProperties()
        {
            GalleryItem item = new GalleryItem("old.bmp", "Old Title", "Old Desc", "https://old.dev", 100, 200);

            item.ImagePath = "new.bmp";
            item.Title = "New Title";
            item.Description = "New Description";
            item.Url = "https://new.dev";
            item.Height = 500;
            item.Width = 800;

            Assert.Equal("new.bmp", item.ImagePath);
            Assert.Equal("New Title", item.Title);
            Assert.Equal("New Description", item.Description);
            Assert.Equal("https://new.dev", item.Url);
            Assert.Equal(500, item.Height);
            Assert.Equal(800, item.Width);
        }

        #endregion

        #region Gallery Edge Cases

        /// <summary>
        ///     Tests that Gallery items list is not null and has exactly 10 items
        /// </summary>
        [Fact]
        public void Gallery_ItemsList_ShouldNotBeNullAndHaveExactly10Items()
        {
            Gallery gallery = new Gallery();

            Assert.NotNull(gallery.Items);
            Assert.Equal(10, gallery.Items.Count);
        }

        /// <summary>
        ///     Tests that all Gallery items are not null
        /// </summary>
        [Fact]
        public void Gallery_AllItems_ShouldNotBeNull()
        {
            Gallery gallery = new Gallery();

            Assert.All(gallery.Items, item => Assert.NotNull(item));
        }

        /// <summary>
        ///     Tests that Gallery items have sequential numbering in titles and URLs
        /// </summary>
        [Fact]
        public void Gallery_Items_ShouldHaveSequentialNumbering()
        {
            Gallery gallery = new Gallery();

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal($"Item {i + 1}", gallery.Items[i].Title);
                Assert.Equal($"https://www.example.com/{i + 1}", gallery.Items[i].Url);
            }
        }

        /// <summary>
        ///     Tests that Gallery items have consistent dimensions and image path
        /// </summary>
        [Fact]
        public void Gallery_Items_ShouldHaveConsistentDimensionsAndImagePath()
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
        ///     Tests that Gallery items list is mutable externally
        /// </summary>
        [Fact]
        public void Gallery_ItemsList_ShouldBeMutableExternally()
        {
            Gallery gallery = new Gallery();
            int initialCount = gallery.Items.Count;

            gallery.Items.Add(new GalleryItem("custom.bmp", "Custom", "Custom Desc", "https://custom.dev", 50, 50));
            gallery.Items.RemoveAt(0);

            Assert.Equal(initialCount, gallery.Items.Count);
        }

        /// <summary>
        ///     Tests that Gallery items descriptions follow the expected pattern
        /// </summary>
        [Fact]
        public void Gallery_Items_ShouldHaveExpectedDescriptionPattern()
        {
            Gallery gallery = new Gallery();

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal($"Description for Item {i + 1}", gallery.Items[i].Description);
            }
        }

        #endregion
    }
}
