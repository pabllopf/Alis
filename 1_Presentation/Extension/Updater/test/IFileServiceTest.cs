

using Alis.Extension.Updater.Services.Files;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    ///     The file service test class
    /// </summary>
    public class IFileServiceTest
    {
        /// <summary>
        ///     Tests that file service implements i file service
        /// </summary>
        [Fact]
        public void FileService_Implements_IFileService()
        {
            FileService service = new FileService();
            Assert.IsAssignableFrom<IFileService>(service);
        }
    }
}