// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManagerAdditionalCoverageTest.cs
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
using System.Threading.Tasks;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;
using Moq;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    /// The update manager additional coverage test class
    /// </summary>
    public class UpdateManagerAdditionalCoverageTest
    {
        /// <summary>
        /// Tests that finish already downloaded flow returns true
        /// </summary>
        [Fact]
        public void FinishAlreadyDownloadedFlow_ReturnsTrue()
        {
            UpdateManager sut = CreateManagerFast();
            bool result = sut.FinishAlreadyDownloadedFlow();
            Assert.True(result);
        }

        /// <summary>
        /// Tests that remove old backup archives with zero backups does not throw
        /// </summary>
        [Fact]
        public void RemoveOldBackupArchives_WithZeroBackups_DoesNotThrow()
        {
            using TempFolder temp = TempFolder.Create();
            UpdateManager sut = CreateManagerFast(programFolder: temp.Path);
            sut.RemoveOldBackupArchives();
        }

        /// <summary>
        /// Tests that remove old backup archives with one backup does not delete
        /// </summary>
        [Fact]
        public void RemoveOldBackupArchives_WithOneBackup_DoesNotDelete()
        {
            using TempFolder temp = TempFolder.Create();
            string backupFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_20250101000000.zip");
            File.WriteAllText(backupFile, "content");
            try
            {
                UpdateManager sut = CreateManagerFast(programFolder: temp.Path);
                sut.RemoveOldBackupArchives();
                Assert.True(File.Exists(backupFile));
            }
            finally
            {
                if (File.Exists(backupFile)) File.Delete(backupFile);
            }
        }

        /// <summary>
        /// Tests that remove old backup archives with three backups deletes oldest
        /// </summary>
        [Fact]
        public void RemoveOldBackupArchives_WithThreeBackups_DeletesOldest()
        {
            using TempFolder temp = TempFolder.Create();
            string oldBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_20200101000000.zip");
            string midBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_20230101000000.zip");
            string newBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_20260101000000.zip");
            File.WriteAllText(oldBackup, "old");
            File.WriteAllText(midBackup, "mid");
            File.WriteAllText(newBackup, "new");
            try
            {
                UpdateManager sut = CreateManagerFast(programFolder: temp.Path);
                sut.RemoveOldBackupArchives();
                Assert.False(File.Exists(oldBackup), "Oldest backup should be deleted");
            }
            finally
            {
                if (File.Exists(oldBackup)) File.Delete(oldBackup);
                if (File.Exists(midBackup)) File.Delete(midBackup);
                if (File.Exists(newBackup)) File.Delete(newBackup);
            }
        }

        /// <summary>
        /// Tests that compress backup folder creates zip and removes directory
        /// </summary>
        [Fact]
        public void CompressBackupFolder_CreatesZipAndRemovesDirectory()
        {
            using TempFolder temp = TempFolder.Create();
            string backupDir = Path.Combine(temp.Path, "BackupFolder");
            Directory.CreateDirectory(backupDir);
            File.WriteAllText(Path.Combine(backupDir, "test.txt"), "content");

            UpdateManager sut = CreateManagerFast(programFolder: temp.Path);
            sut.ContinueDelayMilliseconds = 0;
            sut.CompressBackupFolder(backupDir);

            Assert.False(Directory.Exists(backupDir), "Original directory should be deleted");
            string[] zips = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Backup_*.zip");
            Assert.NotEmpty(zips);
            foreach (string z in zips)
            {
                if (File.Exists(z)) File.Delete(z);
            }
        }

        /// <summary>
        /// Tests that move program folder to backup when folder exists moves and returns path
        /// </summary>
        [Fact]
        public void MoveProgramFolderToBackup_WhenFolderExists_MovesAndReturnsPath()
        {
            using TempFolder temp = TempFolder.Create();
            string programFolder = Path.Combine(temp.Path, "ProgramDir");
            Directory.CreateDirectory(programFolder);
            File.WriteAllText(Path.Combine(programFolder, "app.exe"), "binary");

            UpdateManager sut = CreateManagerFast(programFolder: programFolder);
            sut.ContinueDelayMilliseconds = 0;
            string backupPath = sut.MoveProgramFolderToBackup();

            Assert.False(Directory.Exists(programFolder), "Original program folder should be moved");
            Assert.NotNull(backupPath);
            Assert.Contains("Backup_", backupPath);
            Assert.True(Directory.Exists(backupPath), "Backup directory should exist");
            Assert.True(File.Exists(Path.Combine(backupPath, "app.exe")), "Backup should contain app.exe");

            if (Directory.Exists(backupPath)) Directory.Delete(backupPath, true);
        }

        /// <summary>
        /// Tests that get latest release async with valid url returns task
        /// </summary>
        [Fact]
        public void GetLatestReleaseAsync_WithValidUrl_ReturnsTask()
        {
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(new Uri("https://api.github.com/repos/test/test/releases/latest"));
            IFileService fileService = Mock.Of<IFileService>();
            UpdateManager sut = new UpdateManager(api.Object, "latest", fileService, Path.GetTempPath());
            sut.ContinueDelayMilliseconds = 0;

            Task<Dictionary<string, object>> task = sut.GetLatestReleaseAsync();
            Assert.NotNull(task);
        }

        /// <summary>
        /// Tests that backup when program folder exists moves and compresses
        /// </summary>
        [Fact]
        public void Backup_WhenProgramFolderExists_MovesAndCompresses()
        {
            using TempFolder temp = TempFolder.Create();
            string programFolder = System.IO.Path.Combine(temp.Path, "ProgDir");
            Directory.CreateDirectory(programFolder);
            File.WriteAllText(System.IO.Path.Combine(programFolder, "app.exe"), "data");

            UpdateManager sut = CreateManagerFast(programFolder: programFolder);
            sut.ContinueDelayMilliseconds = 0;

            sut.Backup();

            Assert.False(Directory.Exists(programFolder), "Program folder should be moved");
            string[] backupZips = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Backup_*.zip");
            Assert.NotEmpty(backupZips);
            foreach (string z in backupZips)
            {
                if (File.Exists(z)) File.Delete(z);
            }
        }

        /// <summary>
        /// Tests that backup when program folder does not exist sets progress to 07
        /// </summary>
        [Fact]
        public void Backup_WhenProgramFolderDoesNotExist_SetsProgressTo07()
        {
            string nonExistent = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "no-such-dir", Guid.NewGuid().ToString("N"));
            UpdateManager sut = CreateManagerFast(programFolder: nonExistent);
            sut.ContinueDelayMilliseconds = 0;

            sut.Backup();

            Assert.Equal(0.7f, sut.Progress, 5);
        }

        /// <summary>
        /// Tests that clean temp file deletes matching files
        /// </summary>
        [Fact]
        public void CleanTempFile_DeletesMatchingFiles()
        {
            string testZip = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_cleanup.zip");
            string testDmg = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_cleanup.dmg");
            try
            {
                File.WriteAllText(testZip, "zip");
                File.WriteAllText(testDmg, "dmg");
                Assert.True(File.Exists(testZip));
                Assert.True(File.Exists(testDmg));

                UpdateManager sut = CreateManagerFast();
                sut.ContinueDelayMilliseconds = 0;
                sut.CleanTempFile();

                Assert.False(File.Exists(testZip), "Zip file should be deleted");
                Assert.False(File.Exists(testDmg), "Dmg file should be deleted");
            }
            finally
            {
                if (File.Exists(testZip)) File.Delete(testZip);
                if (File.Exists(testDmg)) File.Delete(testDmg);
            }
        }

        /// <summary>
        /// Tests that clean temp file does not delete backup files
        /// </summary>
        [Fact]
        public void CleanTempFile_DoesNotDeleteBackupFiles()
        {
            string testBackup = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_test.zip");
            try
            {
                File.WriteAllText(testBackup, "backup");
                UpdateManager sut = CreateManagerFast();
                sut.ContinueDelayMilliseconds = 0;
                sut.CleanTempFile();
                Assert.True(File.Exists(testBackup), "Backup files should not be deleted");
            }
            finally
            {
                if (File.Exists(testBackup)) File.Delete(testBackup);
            }
        }

        /// <summary>
        /// Tests that install latest version when program folder does not exist still completes
        /// </summary>
        [Fact]
        public void InstallLatestVersion_WhenProgramFolderDoesNotExist_StillCompletes()
        {
            using TempFolder temp = TempFolder.Create();
            string zipPath = System.IO.Path.Combine(temp.Path, "package.zip");
            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry("test.txt");
                using StreamWriter sw = new StreamWriter(entry.Open());
                sw.Write("content");
            }

            string nonExistentFolder = System.IO.Path.Combine(temp.Path, "NonExistentProg");
            UpdateManager sut = CreateManagerFast(programFolder: nonExistentFolder);
            sut.ContinueDelayMilliseconds = 0;

            bool result = sut.InstallLatestVersion(zipPath, "v1.0.0");
            Assert.True(result);
            Assert.True(Directory.Exists(nonExistentFolder));
            Assert.True(File.Exists(System.IO.Path.Combine(nonExistentFolder, "test.txt")));
        }

        /// <summary>
        /// Tests that wait for continue with zero delay does not block
        /// </summary>
        [Fact]
        public void WaitForContinue_WithZeroDelay_DoesNotBlock()
        {
            UpdateManager sut = CreateManagerFast();
            sut.ContinueDelayMilliseconds = 0;
            sut.WaitForContinue();
        }

        /// <summary>
        /// Tests that get selected asset with empty assets throws key not found
        /// </summary>
        [Fact]
        public void GetSelectedAsset_WithEmptyAssets_ThrowsKeyNotFound()
        {
            Dictionary<string, object> release = new Dictionary<string, object>();
            Assert.Throws<KeyNotFoundException>(() => UpdateManager.GetSelectedAsset(release, "win", "x64"));
        }

        /// <summary>
        /// Creates the manager fast using the specified version to install
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
        /// The temp folder class
        /// </summary>
        /// <seealso cref="IDisposable"/>
        private class TempFolder : IDisposable
        {
            /// <summary>
            /// Gets or sets the value of the path
            /// </summary>
            public string Path { get; private set; }

            /// <summary>
            /// Creates
            /// </summary>
            /// <returns>The temp folder</returns>
            public static TempFolder Create()
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-test", Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(path);
                return new TempFolder { Path = path };
            }

            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose()
            {
                try
                {
                    if (Directory.Exists(Path)) Directory.Delete(Path, true);
                }
                catch
                {
                }
            }
        }
    }
}
