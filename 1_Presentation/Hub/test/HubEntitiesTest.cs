// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HubEntitiesTest.cs
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

using Alis.App.Hub.Entity;
using Xunit;

namespace Alis.App.Hub.Test
{
    public class HubEntitiesTest
    {
        [Fact]
        public void Project_ParameterizedConstructor_SetsDefaults()
        {
            Project project = new Project("TestProj", "/path/to/proj", "Synced", "2024-01-01", "2024.1.0");
            Assert.Equal("TestProj", project.Name);
            Assert.Equal("/path/to/proj", project.Path);
            Assert.Equal("Synced", project.CloudStatus);
            Assert.Equal("2024-01-01", project.ModifiedDate);
            Assert.Equal("2024.1.0", project.EditorVersion);
            Assert.Equal("1.0.0", project.Version);
            Assert.Equal("Never", project.LastModified);
        }

        [Fact]
        public void Project_PropertySetters_WorkCorrectly()
        {
            Project project = default;
            project.Name = "Updated";
            project.Path = "/new/path";
            project.CloudStatus = "Offline";
            project.ModifiedDate = "2024-06-15";
            project.EditorVersion = "2024.2.0";
            project.Version = "2.0.0";
            project.LastModified = "2024-06-15T12:00:00Z";
            Assert.Equal("Updated", project.Name);
            Assert.Equal("/new/path", project.Path);
            Assert.Equal("Offline", project.CloudStatus);
            Assert.Equal("2024-06-15", project.ModifiedDate);
            Assert.Equal("2024.2.0", project.EditorVersion);
            Assert.Equal("2.0.0", project.Version);
            Assert.Equal("2024-06-15T12:00:00Z", project.LastModified);
        }

        [Fact]
        public void InstalledVersion_Constructor_SetsProperties()
        {
            InstalledVersion version = new InstalledVersion("1.0.0", "2024-01-01", "/usr/local/alis");
            Assert.Equal("1.0.0", version.Version);
            Assert.Equal("2024-01-01", version.ReleaseDate);
            Assert.Equal("/usr/local/alis", version.InstallPath);
        }

        [Fact]
        public void GalleryItem_Constructor_SetsProperties()
        {
            GalleryItem item = new GalleryItem("img.png", "Title", "Description", "https://example.com", 100, 200);
            Assert.Equal("img.png", item.ImagePath);
            Assert.Equal("Title", item.Title);
            Assert.Equal("Description", item.Description);
            Assert.Equal("https://example.com", item.Url);
            Assert.Equal(100, item.Height);
            Assert.Equal(200, item.Width);
        }

        [Fact]
        public void GalleryItem_PropertySetters_WorkCorrectly()
        {
            GalleryItem item = new GalleryItem("a.png", "A", "B", "http://url", 1, 1);
            item.ImagePath = "b.png";
            item.Title = "New Title";
            item.Description = "New Desc";
            item.Url = "http://new.url";
            item.Height = 50;
            item.Width = 60;
            Assert.Equal("b.png", item.ImagePath);
            Assert.Equal("New Title", item.Title);
            Assert.Equal("New Desc", item.Description);
            Assert.Equal("http://new.url", item.Url);
            Assert.Equal(50, item.Height);
            Assert.Equal(60, item.Width);
        }

        [Fact]
        public void Gallery_Constructor_CreatesTenItems()
        {
            Gallery gallery = new Gallery();
            Assert.NotNull(gallery.Items);
            Assert.Equal(10, gallery.Items.Count);
        }

        [Fact]
        public void Gallery_Items_HaveValidData()
        {
            Gallery gallery = new Gallery();
            for (int i = 0; i < gallery.Items.Count; i++)
            {
                GalleryItem item = gallery.Items[i];
                Assert.False(string.IsNullOrWhiteSpace(item.ImagePath));
                Assert.False(string.IsNullOrWhiteSpace(item.Title));
                Assert.False(string.IsNullOrWhiteSpace(item.Description));
                Assert.False(string.IsNullOrWhiteSpace(item.Url));
                Assert.True(item.Height > 0);
                Assert.True(item.Width > 0);
            }
        }

        [Fact]
        public void Project_Struct_IsSerializable()
        {
            Project project = new Project("Name", "Path", "Status", "Date", "Version");
            string serialized = $"{project.Name}|{project.Path}|{project.CloudStatus}|{project.EditorVersion}";
            Assert.Equal("Name|Path|Status|Version", serialized);
        }
    }
}
