// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DefaultTest.cs
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

using Xunit;
using System.Collections.Generic;
using Alis.App.Hub.Entity;
using Alis.App.Hub.Windows.Sections;

namespace Alis.App.Hub.Test
{
    /// <summary>
    ///     Tests for Hub entities and section models
    /// </summary>
    public class HubModelsTest
    {
        /// <summary>
        ///     Tests that Project constructor stores required values and keeps optional defaults
        /// </summary>
        [Fact]
        public void Project_Constructor_ShouldSetProvidedValuesAndDefaults()
        {
            Project project = new Project("MyGame", "/tmp/mygame", "Synced", "2026-03-14", "2026.1.0");

            Assert.Equal("MyGame", project.Name);
            Assert.Equal("/tmp/mygame", project.Path);
            Assert.Equal("Synced", project.CloudStatus);
            Assert.Equal("2026-03-14", project.ModifiedDate);
            Assert.Equal("2026.1.0", project.EditorVersion);
            Assert.Equal("1.0.0", project.Version);
            Assert.Equal("Never", project.LastModified);
        }

        /// <summary>
        ///     Tests that InstalledVersion constructor maps immutable properties
        /// </summary>
        [Fact]
        public void InstalledVersion_Constructor_ShouldSetReadOnlyProperties()
        {
            InstalledVersion version = new InstalledVersion("1.2.0", "2026-01-01", "/opt/alis");

            Assert.Equal("1.2.0", version.Version);
            Assert.Equal("2026-01-01", version.ReleaseDate);
            Assert.Equal("/opt/alis", version.InstallPath);
        }

        /// <summary>
        ///     Tests that LearningResource constructor maps immutable properties
        /// </summary>
        [Fact]
        public void LearningResource_Constructor_ShouldSetReadOnlyProperties()
        {
            LearningResource resource = new LearningResource("Docs", "Reference docs", "https://example.dev/docs");

            Assert.Equal("Docs", resource.Title);
            Assert.Equal("Reference docs", resource.Description);
            Assert.Equal("https://example.dev/docs", resource.Url);
        }

        /// <summary>
        ///     Tests that ReleaseElement default constructor initializes an empty dictionary
        /// </summary>
        [Fact]
        public void ReleaseElement_DefaultConstructor_ShouldCreateEmptyDictionary()
        {
            ReleaseElement element = new ReleaseElement();

            Assert.NotNull(element.Element);
            Assert.Empty(element.Element);
        }

        /// <summary>
        ///     Tests that ReleasesInfo default constructor initializes an empty list
        /// </summary>
        [Fact]
        public void ReleasesInfo_DefaultConstructor_ShouldCreateEmptyList()
        {
            ReleasesInfo info = new ReleasesInfo();

            Assert.NotNull(info.Releases);
            Assert.Empty(info.Releases);
        }

        /// <summary>
        ///     Tests that ReleasesInfo keeps the provided release list
        /// </summary>
        [Fact]
        public void ReleasesInfo_WithProvidedList_ShouldExposeList()
        {
            List<ReleaseElement> releases = new List<ReleaseElement>
            {
                new ReleaseElement(new Dictionary<object, object> { {"version", "1.0.0"} })
            };

            ReleasesInfo info = new ReleasesInfo(releases);

            Assert.Single(info.Releases);
            Assert.Same(releases, info.Releases);
        }

        /// <summary>
        ///     Tests that Gallery constructor creates ten deterministic items
        /// </summary>
        [Fact]
        public void Gallery_DefaultConstructor_ShouldCreateTenItems()
        {
            Gallery gallery = new Gallery();

            Assert.Equal(10, gallery.Items.Count);
            Assert.Equal("Item 1", gallery.Items[0].Title);
            Assert.Equal("Description for Item 1", gallery.Items[0].Description);
            Assert.Equal("https://www.example.com/1", gallery.Items[0].Url);
            Assert.Equal(100, gallery.Items[0].Height);
            Assert.Equal(100, gallery.Items[0].Width);
            Assert.Equal("Hub_logo.bmp", gallery.Items[0].ImagePath);

            Assert.Equal("Item 10", gallery.Items[9].Title);
            Assert.Equal("https://www.example.com/10", gallery.Items[9].Url);
        }
    }
}