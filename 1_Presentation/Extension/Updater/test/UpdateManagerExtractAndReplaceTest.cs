using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;
using Moq;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    public class UpdateManagerExtractAndReplaceTest
    {
        [Theory]
        [MemberData(nameof(IsZipPackageCases))]
        public void IsZipPackage_Matrix(int caseId, string fileName, bool expected)
        {
            UpdateManager sut = CreateManagerFast();

            bool result = sut.IsZipPackage(fileName);

            Assert.Equal(expected, result);
            Assert.True(caseId >= 0);
        }

        [Theory]
        [MemberData(nameof(IsDmgPackageCases))]
        public void IsDmgPackage_Matrix(int caseId, string fileName, bool expected)
        {
            UpdateManager sut = CreateManagerFast();

            bool result = sut.IsDmgPackage(fileName);

            Assert.Equal(expected, result);
            Assert.True(caseId >= 0);
        }

        [Theory]
        [MemberData(nameof(GetPackageTypeCases))]
        public void GetPackageType_Matrix(int caseId, string fileName, string expected)
        {
            UpdateManager sut = CreateManagerFast();

            string result = sut.GetPackageType(fileName);

            Assert.Equal(expected, result);
            Assert.True(caseId >= 0);
        }

        [Theory]
        [InlineData("zip", 0.8f, "Extracted and replaced .zip file.")]
        [InlineData("dmg", 0.8f, "Extracted and replaced .dmg file.")]
        public void ReportPackageExtractionCompleted_UpdatesState_ForKnownTypes(string packageType, float expectedProgress, string expectedMessage)
        {
            UpdateManager sut = CreateManagerFast();

            sut.ReportPackageExtractionCompleted(packageType);

            Assert.Equal(expectedProgress, sut.Progress);
            Assert.Equal(expectedMessage, sut.Message);
        }

        [Theory]
        [MemberData(nameof(UnknownPackageTypesCases))]
        public void ExecutePackageExtraction_Throws_ForUnknownTypes(int caseId, string packageType)
        {
            using TempFolder temp = TempFolder.Create();
            string programFolder = Path.Combine(temp.Path, "program");
            UpdateManager sut = CreateManagerFast(programFolder: programFolder);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                sut.ExecutePackageExtraction(Path.Combine(temp.Path, "file.unknown"), packageType));

            Assert.Contains("invalid extension", ex.Message, StringComparison.OrdinalIgnoreCase);
            Assert.True(caseId >= 0);
        }

        [Theory]
        [MemberData(nameof(ExtractAndReplaceInvalidCases))]
        public void ExtractAndReplace_Throws_ForInvalidExtensions(int caseId, string fileName)
        {
            UpdateManager sut = CreateManagerFast();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.ExtractAndReplace(fileName));

            Assert.Contains("invalid extension", ex.Message, StringComparison.OrdinalIgnoreCase);
            Assert.True(caseId >= 0);
        }

        [Fact]
        public void ExtractAndReplace_Throws_ForNullInput()
        {
            UpdateManager sut = CreateManagerFast();

            Assert.Throws<NullReferenceException>(() => sut.ExtractAndReplace(null));
        }

        [Theory]
        [MemberData(nameof(ExtractAndReplaceZipCases))]
        public void ExtractAndReplace_ExtractsZip_AndReportsProgress(int caseId, string zipName)
        {
            using TempFolder temp = TempFolder.Create();
            string programFolder = Path.Combine(temp.Path, "program");
            string zipPath = Path.Combine(temp.Path, zipName);

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry("content/file-" + caseId + ".txt", CompressionLevel.Fastest);
                using StreamWriter writer = new StreamWriter(entry.Open());
                writer.Write("payload-" + caseId);
            }

            UpdateManager sut = CreateManagerFast(programFolder: programFolder);
            sut.ExtractAndReplace(zipPath);

            Assert.Equal(0.8f, sut.Progress);
            Assert.Equal("Extracted and replaced .zip file.", sut.Message);
            Assert.True(File.Exists(Path.Combine(programFolder, "content", "file-" + caseId + ".txt")));
        }

        [Fact]
        public void ExtractAndReplace_WhenNameContainsZipAndDmg_PrioritizesZip()
        {
            using TempFolder temp = TempFolder.Create();
            string programFolder = Path.Combine(temp.Path, "program");
            string zipPath = Path.Combine(temp.Path, "bundle.zip.dmg");

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry("priority/check.txt", CompressionLevel.Fastest);
                using StreamWriter writer = new StreamWriter(entry.Open());
                writer.Write("zip-priority");
            }

            UpdateManager sut = CreateManagerFast(programFolder: programFolder);
            sut.ExtractAndReplace(zipPath);

            Assert.Equal("Extracted and replaced .zip file.", sut.Message);
            Assert.True(File.Exists(Path.Combine(programFolder, "priority", "check.txt")));
        }

        public static IEnumerable<object[]> IsZipPackageCases()
        {
            string[] names =
            {
                "update.zip", "pkg.zip.tmp", "zip-package.bin", "image.dmg", "archive.tar", "README", "zip.zip", "ZIP.zip"
            };

            for (int i = 0; i < 40; i++)
            {
                string name = names[i % names.Length] + "-" + i;
                if (i % names.Length == 0)
                {
                    name = "update-" + i + ".zip";
                }

                bool expected = name.Contains(".zip");
                yield return new object[] { i, name, expected };
            }
        }

        public static IEnumerable<object[]> IsDmgPackageCases()
        {
            string[] names =
            {
                "update.dmg", "pkg.dmg.tmp", "image.zip", "archive.tar", "DMG.dmg", "installer.pkg", "notes.txt"
            };

            for (int i = 0; i < 40; i++)
            {
                string name = names[i % names.Length] + "-" + i;
                if (i % names.Length == 0)
                {
                    name = "update-" + i + ".dmg";
                }

                bool expected = name.Contains(".dmg");
                yield return new object[] { i, name, expected };
            }
        }

        public static IEnumerable<object[]> GetPackageTypeCases()
        {
            for (int i = 0; i < 60; i++)
            {
                string fileName;
                string expected;

                switch (i % 6)
                {
                    case 0:
                        fileName = "update-" + i + ".zip";
                        expected = "zip";
                        break;
                    case 1:
                        fileName = "update-" + i + ".dmg";
                        expected = "dmg";
                        break;
                    case 2:
                        fileName = "bundle-" + i + ".zip.dmg";
                        expected = "zip";
                        break;
                    case 3:
                        fileName = "bundle-" + i + ".dmg.zip";
                        expected = "zip";
                        break;
                    case 4:
                        fileName = "readme-" + i + ".txt";
                        expected = "invalid";
                        break;
                    default:
                        fileName = "package-" + i + ".ZIP";
                        expected = "invalid";
                        break;
                }

                yield return new object[] { i, fileName, expected };
            }
        }

        public static IEnumerable<object[]> UnknownPackageTypesCases()
        {
            string[] types = { "invalid", "unknown", "", "tar", "pkg", "null-like" };
            for (int i = 0; i < 30; i++)
            {
                yield return new object[] { i, types[i % types.Length] };
            }
        }

        public static IEnumerable<object[]> ExtractAndReplaceInvalidCases()
        {
            string[] invalidExtensions = { "txt", "tar", "7z", "rar", "pkg", "msi", "bin", "json", "gz", "iso" };
            for (int i = 0; i < 40; i++)
            {
                yield return new object[] { i, "invalid-file-" + i + "." + invalidExtensions[i % invalidExtensions.Length] };
            }
        }

        public static IEnumerable<object[]> ExtractAndReplaceZipCases()
        {
            for (int i = 0; i < 20; i++)
            {
                string suffix = i % 2 == 0 ? ".zip" : ".zip.tmp";
                yield return new object[] { i, "update-case-" + i + suffix };
            }
        }

        private static UpdateManager CreateManagerFast(string versionToInstall = "latest", string programFolder = null)
        {
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(new Uri("http://127.0.0.1:55000/"));
            api.Setup(x => x.GetLatestReleaseAsync()).ReturnsAsync(new Dictionary<string, object>());

            IFileService fileService = Mock.Of<IFileService>();
            UpdateManager manager = new UpdateManager(
                api.Object,
                versionToInstall,
                fileService,
                programFolder ?? Path.Combine(Path.GetTempPath(), "alis-updater", Guid.NewGuid().ToString("N")));
            manager.ContinueDelayMilliseconds = 0;
            return manager;
        }

        private sealed class TempFolder : IDisposable
        {
            private TempFolder(string path)
            {
                Path = path;
            }

            public string Path { get; }

            public static TempFolder Create()
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-tests", Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(path);
                return new TempFolder(path);
            }

            public void Dispose()
            {
                if (Directory.Exists(Path))
                {
                    Directory.Delete(Path, true);
                }
            }
        }
    }
}


