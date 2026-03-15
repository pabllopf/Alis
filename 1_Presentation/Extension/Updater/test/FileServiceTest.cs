using System;
using Xunit;
using Alis.Extension.Updater.Services.Files;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    /// The file service test class
    /// </summary>
    public class FileServiceTest
    {
        /// <summary>
        /// Tests that backup throws not implemented exception
        /// </summary>
        [Fact]
        public void Backup_ThrowsNotImplementedException()
        {
            FileService sut = new FileService();
            Assert.Throws<NotImplementedException>(() => sut.Backup("/tmp"));
        }

        /// <summary>
        /// Tests that clean temp files throws not implemented exception
        /// </summary>
        [Fact]
        public void CleanTempFiles_ThrowsNotImplementedException()
        {
            FileService sut = new FileService();
            Assert.Throws<NotImplementedException>(() => sut.CleanTempFiles("/tmp"));
        }

        /// <summary>
        /// Tests that extract and replace throws not implemented exception
        /// </summary>
        [Fact]
        public void ExtractAndReplace_ThrowsNotImplementedException()
        {
            FileService sut = new FileService();
            Assert.Throws<NotImplementedException>(() => sut.ExtractAndReplace("archive.zip", "/tmp"));
        }
    }
}
