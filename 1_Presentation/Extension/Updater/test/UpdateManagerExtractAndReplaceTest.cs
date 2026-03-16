// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManagerExtractAndReplaceTest.cs
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
    /// <summary>
    ///     The update manager extract and replace test class
    /// </summary>
    public class UpdateManagerExtractAndReplaceTest
    {
        /// <summary>
        ///     Tests that is zip package matrix
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="fileName">The file name</param>
        /// <param name="expected">The expected</param>
        [Theory, MemberData(nameof(IsZipPackageCases))]
        public void IsZipPackage_Matrix(int caseId, string fileName, bool expected)
        {
            UpdateManager sut = CreateManagerFast();

            bool result = sut.IsZipPackage(fileName);

            Assert.Equal(expected, result);
            Assert.True(caseId >= 0);
        }

        /// <summary>
        ///     Tests that is dmg package matrix
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="fileName">The file name</param>
        /// <param name="expected">The expected</param>
        [Theory, MemberData(nameof(IsDmgPackageCases))]
        public void IsDmgPackage_Matrix(int caseId, string fileName, bool expected)
        {
            UpdateManager sut = CreateManagerFast();

            bool result = sut.IsDmgPackage(fileName);

            Assert.Equal(expected, result);
            Assert.True(caseId >= 0);
        }

        /// <summary>
        ///     Tests that get package type matrix
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="fileName">The file name</param>
        /// <param name="expected">The expected</param>
        [Theory, MemberData(nameof(GetPackageTypeCases))]
        public void GetPackageType_Matrix(int caseId, string fileName, string expected)
        {
            UpdateManager sut = CreateManagerFast();

            string result = sut.GetPackageType(fileName);

            Assert.Equal(expected, result);
            Assert.True(caseId >= 0);
        }

        /// <summary>
        ///     Tests that report package extraction completed updates state for known types
        /// </summary>
        /// <param name="packageType">The package type</param>
        /// <param name="expectedProgress">The expected progress</param>
        /// <param name="expectedMessage">The expected message</param>
        [Theory, InlineData("zip", 0.8f, "Extracted and replaced .zip file."), InlineData("dmg", 0.8f, "Extracted and replaced .dmg file.")]
        public void ReportPackageExtractionCompleted_UpdatesState_ForKnownTypes(string packageType, float expectedProgress, string expectedMessage)
        {
            UpdateManager sut = CreateManagerFast();

            sut.ReportPackageExtractionCompleted(packageType);

            Assert.Equal(expectedProgress, sut.Progress);
            Assert.Equal(expectedMessage, sut.Message);
        }

        /// <summary>
        ///     Tests that execute package extraction throws for unknown types
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="packageType">The package type</param>
        [Theory, MemberData(nameof(UnknownPackageTypesCases))]
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

        /// <summary>
        ///     Tests that extract and replace throws for invalid extensions
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="fileName">The file name</param>
        [Theory, MemberData(nameof(ExtractAndReplaceInvalidCases))]
        public void ExtractAndReplace_Throws_ForInvalidExtensions(int caseId, string fileName)
        {
            UpdateManager sut = CreateManagerFast();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.ExtractAndReplace(fileName));

            Assert.Contains("invalid extension", ex.Message, StringComparison.OrdinalIgnoreCase);
            Assert.True(caseId >= 0);
        }

        /// <summary>
        ///     Tests that extract and replace throws for null input
        /// </summary>
        [Fact]
        public void ExtractAndReplace_Throws_ForNullInput()
        {
            UpdateManager sut = CreateManagerFast();

            Assert.Throws<NullReferenceException>(() => sut.ExtractAndReplace(null));
        }

        /// <summary>
        ///     Tests that extract and replace extracts zip and reports progress
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="zipName">The zip name</param>
        [Theory, MemberData(nameof(ExtractAndReplaceZipCases))]
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

        /// <summary>
        ///     Tests that extract and replace when name contains zip and dmg prioritizes zip
        /// </summary>
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

        /// <summary>
        ///     Ises the zip package cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
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
                yield return new object[] {i, name, expected};
            }
        }

        /// <summary>
        ///     Ises the dmg package cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
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
                yield return new object[] {i, name, expected};
            }
        }

        /// <summary>
        ///     Gets the package type cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
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

                yield return new object[] {i, fileName, expected};
            }
        }

        /// <summary>
        ///     Unknowns the package types cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> UnknownPackageTypesCases()
        {
            string[] types = {"invalid", "unknown", "", "tar", "pkg", "null-like"};
            for (int i = 0; i < 30; i++)
            {
                yield return new object[] {i, types[i % types.Length]};
            }
        }

        /// <summary>
        ///     Extracts the and replace invalid cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> ExtractAndReplaceInvalidCases()
        {
            string[] invalidExtensions = {"txt", "tar", "7z", "rar", "pkg", "msi", "bin", "json", "gz", "iso"};
            for (int i = 0; i < 40; i++)
            {
                yield return new object[] {i, "invalid-file-" + i + "." + invalidExtensions[i % invalidExtensions.Length]};
            }
        }

        /// <summary>
        ///     Extracts the and replace zip cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> ExtractAndReplaceZipCases()
        {
            for (int i = 0; i < 20; i++)
            {
                string suffix = i % 2 == 0 ? ".zip" : ".zip.tmp";
                yield return new object[] {i, "update-case-" + i + suffix};
            }
        }

        /// <summary>
        ///     Creates the manager fast using the specified version to install
        /// </summary>
        /// <param name="versionToInstall">The version to install</param>
        /// <param name="programFolder">The program folder</param>
        /// <returns>The manager</returns>
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

        /// <summary>
        ///     The temp folder class
        /// </summary>
        /// <seealso cref="IDisposable" />
        private sealed class TempFolder : IDisposable
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TempFolder" /> class
            /// </summary>
            /// <param name="path">The path</param>
            private TempFolder(string path) => Path = path;

            /// <summary>
            ///     Gets the value of the path
            /// </summary>
            public string Path { get; }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public void Dispose()
            {
                if (Directory.Exists(Path))
                {
                    Directory.Delete(Path, true);
                }
            }

            /// <summary>
            ///     Creates
            /// </summary>
            /// <returns>The temp folder</returns>
            public static TempFolder Create()
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-tests", Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(path);
                return new TempFolder(path);
            }
        }
    }
}