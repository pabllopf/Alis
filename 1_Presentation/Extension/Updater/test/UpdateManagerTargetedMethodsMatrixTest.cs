// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManagerTargetedMethodsMatrixTest.cs
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
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;
using Moq;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    ///     The update manager targeted methods matrix test class
    /// </summary>
    public class UpdateManagerTargetedMethodsMatrixTest
    {
        /// <summary>
        ///     Tests that report platform detection sets expected progress and message
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        [Theory, MemberData(nameof(ReportPlatformDetectionCases))]
        public void ReportPlatformDetection_SetsExpectedProgressAndMessage(int caseId, string platform, string architecture)
        {
            UpdateManager sut = CreateManagerFast();
            int eventCalls = 0;
            float eventProgress = -1f;
            string eventMessage = null;

            sut.UpdateProgressChanged += (progress, message) =>
            {
                eventCalls++;
                eventProgress = progress;
                eventMessage = message;
            };

            sut.ReportPlatformDetection(platform, architecture);

            Assert.Equal(1, eventCalls);
            Assert.Equal(0.1f, sut.Progress);
            Assert.Equal(0.1f, eventProgress);
            Assert.Equal(platform + "-" + architecture + " platform detected", sut.Message);
            Assert.Equal(sut.Message, eventMessage);
            Assert.True(caseId >= 0);
        }

        /// <summary>
        ///     Tests that get selected asset returns expected entry
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        /// <param name="matchingName">The matching name</param>
        /// <param name="includeMatch">The include match</param>
        /// <param name="nullEntries">The null entries</param>
        /// <param name="unrelatedEntries">The unrelated entries</param>
        [Theory, MemberData(nameof(GetSelectedAssetCases))]
        public void GetSelectedAsset_ReturnsExpectedEntry(
            int caseId,
            string platform,
            string architecture,
            string matchingName,
            bool includeMatch,
            int nullEntries,
            int unrelatedEntries)
        {
            UpdateManager sut = CreateManagerFast();
            Dictionary<string, object> release = new Dictionary<string, object>
            {
                {"assets", BuildAssets(caseId, platform, architecture, matchingName, includeMatch, nullEntries, unrelatedEntries)}
            };

            Dictionary<string, object> selected = sut.GetSelectedAsset(release, platform, architecture);

            if (includeMatch)
            {
                Assert.NotNull(selected);
                Assert.Equal(matchingName, selected["name"]);
            }
            else
            {
                Assert.Null(selected);
            }
        }

        /// <summary>
        ///     Tests that handle missing compatible package always returns false and sets state
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        [Theory, MemberData(nameof(HandleMissingCompatiblePackageCases))]
        public void HandleMissingCompatiblePackage_AlwaysReturnsFalseAndSetsState(int caseId, string platform, string architecture)
        {
            UpdateManager sut = CreateManagerFast();
            int eventCalls = 0;

            sut.UpdateProgressChanged += (_, _) => eventCalls++;

            bool result = sut.HandleMissingCompatiblePackage(platform, architecture);

            Assert.False(result);
            Assert.Equal(0f, sut.Progress);
            Assert.Equal("No compatible package found.", sut.Message);
            Assert.Equal(1, eventCalls);
            Assert.True(caseId >= 0);
        }

        /// <summary>
        ///     Tests that report download preparation emits expected final progress and message
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        /// <param name="version">The version</param>
        [Theory, MemberData(nameof(ReportDownloadPreparationCases))]
        public void ReportDownloadPreparation_EmitsExpectedFinalProgressAndMessage(int caseId, string platform, string architecture, string version)
        {
            UpdateManager sut = CreateManagerFast();
            int eventCalls = 0;
            float lastProgress = -1f;
            string lastMessage = null;

            sut.UpdateProgressChanged += (progress, message) =>
            {
                eventCalls++;
                lastProgress = progress;
                lastMessage = message;
            };

            sut.ReportDownloadPreparation(platform, architecture, version);

            Assert.Equal(2, eventCalls);
            Assert.Equal(0.3f, sut.Progress);
            Assert.Equal(0.3f, lastProgress);
            Assert.Equal($"Downloading package for {platform}-{architecture}...", sut.Message);
            Assert.Equal(sut.Message, lastMessage);
            Assert.True(caseId >= 0);
        }

        /// <summary>
        ///     Reports the platform detection cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> ReportPlatformDetectionCases()
        {
            string[] platforms = {"win", "linux", "osx", "android", "ios"};
            string[] architectures = {"x64", "x86", "arm64", "arm", "wasm"};

            for (int i = 0; i < 20; i++)
            {
                yield return new object[]
                {
                    i,
                    platforms[i % platforms.Length],
                    architectures[i / platforms.Length % architectures.Length]
                };
            }
        }

        /// <summary>
        ///     Gets the selected asset cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetSelectedAssetCases()
        {
            string[] platforms = {"win", "linux", "osx", "android", "ios"};
            string[] architectures = {"x64", "x86", "arm64", "arm", "wasm"};

            for (int i = 0; i < 50; i++)
            {
                string platform = platforms[i % platforms.Length];
                string architecture = architectures[i / platforms.Length % architectures.Length];
                bool includeMatch = i % 5 != 0;
                int nullEntries = i % 4;
                int unrelatedEntries = 2 + i % 3;
                string matchingName = "alis-" + platform + "-stable-" + architecture + "-" + i + ".zip";

                yield return new object[]
                {
                    i,
                    platform,
                    architecture,
                    matchingName,
                    includeMatch,
                    nullEntries,
                    unrelatedEntries
                };
            }
        }

        /// <summary>
        ///     Handles the missing compatible package cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> HandleMissingCompatiblePackageCases()
        {
            string[] platforms = {"win", "linux", "osx", "android", "ios"};
            string[] architectures = {"x64", "x86", "arm64", "arm", "wasm"};

            for (int i = 0; i < 25; i++)
            {
                yield return new object[]
                {
                    i,
                    platforms[i % platforms.Length],
                    architectures[i / platforms.Length % architectures.Length]
                };
            }
        }

        /// <summary>
        ///     Reports the download preparation cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> ReportDownloadPreparationCases()
        {
            string[] platforms = {"win", "linux", "osx", "android", "ios"};
            string[] architectures = {"x64", "x86", "arm64", "arm", "wasm"};
            string[] versions = {"latest", "v1.0.0", "v2.1.5", "nightly", "preview-20260315"};

            for (int i = 0; i < 25; i++)
            {
                yield return new object[]
                {
                    i,
                    platforms[i % platforms.Length],
                    architectures[i / platforms.Length % architectures.Length],
                    versions[i % versions.Length]
                };
            }
        }

        /// <summary>
        ///     Builds the assets using the specified case id
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        /// <param name="matchingName">The matching name</param>
        /// <param name="includeMatch">The include match</param>
        /// <param name="nullEntries">The null entries</param>
        /// <param name="unrelatedEntries">The unrelated entries</param>
        /// <returns>The object array</returns>
        private static object[] BuildAssets(
            int caseId,
            string platform,
            string architecture,
            string matchingName,
            bool includeMatch,
            int nullEntries,
            int unrelatedEntries)
        {
            List<object> assets = new List<object>();

            for (int i = 0; i < unrelatedEntries; i++)
            {
                assets.Add(Asset("unrelated-" + caseId + "-" + i + "-desktop-generic.zip", "https://example.invalid/unrelated"));
            }

            for (int i = 0; i < nullEntries; i++)
            {
                assets.Add(Asset(null, "https://example.invalid/null"));
            }

            if (includeMatch)
            {
                int insertIndex = assets.Count == 0 ? 0 : caseId % (assets.Count + 1);
                assets.Insert(insertIndex, Asset(matchingName, "https://example.invalid/match"));
            }

            return assets.ToArray();
        }

        /// <summary>
        ///     Assets the name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="url">The url</param>
        /// <returns>A dictionary of string and object</returns>
        private static Dictionary<string, object> Asset(string name, string url) => new Dictionary<string, object>
        {
            {"name", name},
            {"browser_download_url", url}
        };

        /// <summary>
        ///     Creates the manager fast using the specified version to install
        /// </summary>
        /// <param name="versionToInstall">The version to install</param>
        /// <returns>The manager</returns>
        private static UpdateManager CreateManagerFast(string versionToInstall = "latest")
        {
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(new Uri("http://127.0.0.1:55000/"));
            api.Setup(x => x.GetLatestReleaseAsync()).ReturnsAsync(new Dictionary<string, object>());

            IFileService fileService = Mock.Of<IFileService>();
            UpdateManager manager = new UpdateManager(
                api.Object,
                versionToInstall,
                fileService,
                "unused-program-folder");
            manager.ContinueDelayMilliseconds = 0;
            return manager;
        }
    }
}