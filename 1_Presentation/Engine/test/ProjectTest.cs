using Alis.App.Engine.Entity;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    /// The project test class
    /// </summary>
    public class ProjectTest
    {
        /// <summary>
        /// Tests that constructor should set values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetValues()
        {
            Project project = new Project("TestName", "/test/path", "Connected", "2 days ago", "v1.0.0");

            Assert.Equal("TestName", project.Name);
            Assert.Equal("/test/path", project.Path);
            Assert.Equal("Connected", project.CloudStatus);
            Assert.Equal("2 days ago", project.ModifiedDate);
            Assert.Equal("v1.0.0", project.EditorVersion);
        }

        /// <summary>
        /// Tests that default constructor should set default values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldSetDefaultValues()
        {
            Project project = default;

            Assert.Null(project.Name);
            Assert.Null(project.Path);
            Assert.Null(project.CloudStatus);
            Assert.Null(project.ModifiedDate);
            Assert.Null(project.EditorVersion);
            Assert.Null(project.Version);
            Assert.Null(project.LastModified);
        }

        /// <summary>
        /// Tests that properties should be gettable and settable
        /// </summary>
        [Fact]
        public void Properties_ShouldBeGettableAndSettable()
        {
            Project project = new Project();

            project.Name = "NewName";
            Assert.Equal("NewName", project.Name);

            project.Path = "/new/path";
            Assert.Equal("/new/path", project.Path);

            project.CloudStatus = "Disconnected";
            Assert.Equal("Disconnected", project.CloudStatus);

            project.ModifiedDate = "Today";
            Assert.Equal("Today", project.ModifiedDate);

            project.EditorVersion = "v2.0.0";
            Assert.Equal("v2.0.0", project.EditorVersion);

            project.Version = "2.0.0";
            Assert.Equal("2.0.0", project.Version);

            project.LastModified = "Now";
            Assert.Equal("Now", project.LastModified);
        }

        /// <summary>
        /// Tests that properties should be independent
        /// </summary>
        [Fact]
        public void Properties_ShouldBeIndependent()
        {
            Project project = new Project("A", "/a", "Online", "1d", "v1");
            Project project2 = new Project("B", "/b", "Offline", "2d", "v2");

            Assert.Equal("A", project.Name);
            Assert.Equal("/a", project.Path);
            Assert.Equal("Online", project.CloudStatus);
            Assert.Equal("1d", project.ModifiedDate);
            Assert.Equal("v1", project.EditorVersion);

            Assert.Equal("B", project2.Name);
            Assert.Equal("/b", project2.Path);
            Assert.Equal("Offline", project2.CloudStatus);
            Assert.Equal("2d", project2.ModifiedDate);
            Assert.Equal("v2", project2.EditorVersion);
        }

        /// <summary>
        /// Tests that default values should be as expected
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeAsExpected()
        {
            Project project = default;

            Assert.Null(project.Name);
            Assert.Null(project.Path);
            Assert.Null(project.CloudStatus);
            Assert.Null(project.ModifiedDate);
        }
    }
}