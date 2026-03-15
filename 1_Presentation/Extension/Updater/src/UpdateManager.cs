// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManager.cs
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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Updater.Events;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;

namespace Alis.Extension.Updater
{
    /// <summary>
    ///     The update manager class
    /// </summary>
    public sealed class UpdateManager
    {
        /// <summary>
        /// The threshold entries
        /// </summary>
        private const int ThresholdEntries = 10000;
        /// <summary>
        /// The threshold size
        /// </summary>
        private const int ThresholdSize = 1000000000; // 1 GB
        /// <summary>
        /// The threshold ratio
        /// </summary>
        private const double ThresholdRatio = 70.0; // Compression ratio threshold

        /// <summary>
        /// The file service
        /// </summary>
        public readonly IFileService FileService;
        /// <summary>
        /// The git hub api service
        /// </summary>
        public readonly IGitHubApiService GitHubApiService;
        /// <summary>
        /// The program folder
        /// </summary>
        public readonly string ProgramFolder;
        /// <summary>
        /// The version to install
        /// </summary>
        public readonly string VersionToInstall;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateManager"/> class
        /// </summary>
        /// <param name="gitHubApiService">The git hub api service</param>
        /// <param name="versionToInstall">The version to install</param>
        /// <param name="fileService">The file service</param>
        /// <param name="programFolder">The program folder</param>
        public UpdateManager(IGitHubApiService gitHubApiService, string versionToInstall, IFileService fileService, string programFolder)
        {
            GitHubApiService = gitHubApiService;
            FileService = fileService;
            ProgramFolder = programFolder;
            VersionToInstall = versionToInstall;
        }

        /// <summary>
        /// Gets or sets the value of the progress
        /// </summary>
        public float Progress { get; private set; }
        /// <summary>
        /// Gets or sets the value of the message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets or sets the wait delay in milliseconds used by continuation checkpoints.
        /// </summary>
        internal int ContinueDelayMilliseconds { get; set; } = 1000;

        public event UpdateProgressEventHandler UpdateProgressChanged;

        /// <summary>
        /// Ons the update progress changed using the specified progress
        /// </summary>
        /// <param name="progress">The progress</param>
        /// <param name="message">The message</param>
        internal void OnUpdateProgressChanged(float progress, string message)
        {
            UpdateProgressChanged?.Invoke(progress, message);
            Progress = progress;
            Message = message;
        }

        /// <summary>
        /// Starts the cts token
        /// </summary>
        /// <param name="ctsToken">The cts token</param>
        /// <exception cref="Exception">Error updating program: {ex.Message}</exception>
        /// <returns>A task containing the bool</returns>
        [ExcludeFromCodeCoverage]
        public async Task<bool> Start(CancellationToken ctsToken)
        {
            Logger.Info("Starting update process.");
            try
            {
                if (HandleCancellationRequest(ctsToken))
                {
                    return false;
                }

                Dictionary<string, object> latestRelease = await GetLatestReleaseAsync();
                if (latestRelease == null)
                {
                    Logger.Info("No release information was returned.");
                    return false;
                }

                string platform = GetPlatform();
                string architecture = GetArchitecture();
                ReportPlatformDetection(platform, architecture);

                Dictionary<string, object> selectedAsset = GetSelectedAsset(latestRelease, platform, architecture);
                if (selectedAsset == null)
                {
                    return HandleMissingCompatiblePackage(platform, architecture);
                }

                string downloadUrl = selectedAsset["browser_download_url"]?.ToString();
                string version = latestRelease["tag_name"]?.ToString();
                ReportDownloadPreparation(platform, architecture, version);

                if (IsLatestVersionAlreadyDownloaded(downloadUrl))
                {
                    return FinishAlreadyDownloadedFlow();
                }

                string downloadedFile = await DownloadLatestVersionAsync(downloadUrl, version);
                if (string.IsNullOrEmpty(downloadedFile))
                {
                    return HandleDownloadFailure();
                }

                return InstallLatestVersion(downloadedFile, version);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating program: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the cancellation request using the specified cts token
        /// </summary>
        /// <param name="ctsToken">The cts token</param>
        /// <returns>The bool</returns>
        internal bool HandleCancellationRequest(CancellationToken ctsToken)
        {
            if (!ctsToken.IsCancellationRequested)
            {
                return false;
            }

            Logger.Info("Exiting update process due to cancellation request.");
            return true;
        }

        /// <summary>
        /// Gets the architecture
        /// </summary>
        /// <returns>The string</returns>
        internal string GetArchitecture() => RuntimeInformation.OSArchitecture.ToString().ToLower();

        /// <summary>
        /// Reports the platform detection using the specified platform
        /// </summary>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        internal void ReportPlatformDetection(string platform, string architecture)
        {
            Logger.Info($"{platform}-{architecture} platform detected");
            OnUpdateProgressChanged(0.1f, $"{platform}-{architecture} platform detected");
            WaitForContinue();
        }

        /// <summary>
        /// Gets the selected asset using the specified latest release
        /// </summary>
        /// <param name="latestRelease">The latest release</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        /// <returns>A dictionary of string and object</returns>
        internal Dictionary<string, object> GetSelectedAsset(Dictionary<string, object> latestRelease, string platform, string architecture)
        {
            object[] assets = (object[])latestRelease["assets"];
            return SelectAsset(assets, platform, architecture);
        }

        /// <summary>
        /// Handles the missing compatible package using the specified platform
        /// </summary>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        /// <returns>The bool</returns>
        internal bool HandleMissingCompatiblePackage(string platform, string architecture)
        {
            OnUpdateProgressChanged(0, "No compatible package found.");
            Logger.Info($"No compatible package found for {platform}-{architecture}.");
            return false;
        }

        /// <summary>
        /// Reports the download preparation using the specified platform
        /// </summary>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        /// <param name="version">The version</param>
        internal void ReportDownloadPreparation(string platform, string architecture, string version)
        {
            Logger.Info($"The latest version available is {version}");
            OnUpdateProgressChanged(0.2f, $"The latest version available is {version}");

            WaitForContinue();
            Logger.Info($"Downloading package for {platform}-{architecture}...");
            OnUpdateProgressChanged(0.3f, $"Downloading package for {platform}-{architecture}...");
            WaitForContinue();
        }

        /// <summary>
        /// Ises the latest version already downloaded using the specified download url
        /// </summary>
        /// <param name="downloadUrl">The download url</param>
        /// <returns>The exists</returns>
        internal bool IsLatestVersionAlreadyDownloaded(string downloadUrl)
        {
            if (downloadUrl == null)
            {
                Logger.Info("Download url is null, skipping already-downloaded check.");
                return false;
            }

            string fileName = Path.GetFileName(new Uri(downloadUrl).AbsolutePath);
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            OnUpdateProgressChanged(0.4f, "Checking if the latest version is already installed...");
            WaitForContinue();

            bool exists = File.Exists(filePath);
            Logger.Info(exists
                ? $"Package '{fileName}' already exists locally."
                : $"Package '{fileName}' not found locally.");
            return exists;
        }

        /// <summary>
        /// Finishes the already downloaded flow
        /// </summary>
        /// <returns>The bool</returns>
        internal bool FinishAlreadyDownloadedFlow()
        {
            OnUpdateProgressChanged(1, "The latest version is already downloaded.");
            Logger.Info("The latest version is already downloaded.");
            CleanTempFile();
            WaitForContinue();
            return true;
        }

        /// <summary>
        /// Downloads the latest version using the specified download url
        /// </summary>
        /// <param name="downloadUrl">The download url</param>
        /// <param name="version">The version</param>
        /// <returns>A task containing the string</returns>
        internal async Task<string> DownloadLatestVersionAsync(string downloadUrl, string version)
        {
            OnUpdateProgressChanged(0.5f, $"Downloading the latest version '{version}'");
            Logger.Info($"Downloading the latest version '{version}'");
            WaitForContinue();
            return await DownloadFileAsync(downloadUrl);
        }

        /// <summary>
        /// Handles the download failure
        /// </summary>
        /// <returns>The bool</returns>
        internal bool HandleDownloadFailure()
        {
            OnUpdateProgressChanged(0, "Error downloading package.");
            Logger.Info("Error downloading package.");
            WaitForContinue();
            return false;
        }

        /// <summary>
        /// Installs the latest version using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <param name="version">The version</param>
        /// <returns>The bool</returns>
        internal bool InstallLatestVersion(string fileAsync, string version)
        {
            Backup();

            OnUpdateProgressChanged(0.6f, "Installing the latest version...");
            Logger.Info($"Installing the latest version '{version}'");
            WaitForContinue();

            ExtractAndReplace(fileAsync);
            CleanTempFile();
            OnUpdateProgressChanged(1, "Update completed successfully.");
            Logger.Info("Update completed successfully.");
            WaitForContinue();
            return true;
        }

        /// <summary>
        /// Backups this instance
        /// </summary>
        [ExcludeFromCodeCoverage]
        internal void Backup()
        {
            Logger.Info($"Backup process started for '{ProgramFolder}'.");
            if (!Directory.Exists(ProgramFolder))
            {
                Logger.Info("Don't need to do backup.");
                OnUpdateProgressChanged(0.7f, "Don't need to do backup.");
                WaitForContinue();
                return;
            }

            string backupPath = MoveProgramFolderToBackup();
            CompressBackupFolder(backupPath);
            RemoveOldBackupArchives();
        }

        /// <summary>
        /// Moves the program folder to backup
        /// </summary>
        /// <returns>The backup path</returns>
        internal string MoveProgramFolderToBackup()
        {
            Logger.Info("Doing backup...");
            OnUpdateProgressChanged(0.7f, "Doing backup...");

            string backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            Directory.Move(ProgramFolder, backupPath);
            WaitForContinue();

            OnUpdateProgressChanged(0.72f, "Folder moved to backup.");
            Logger.Info($"Folder moved to backup at '{backupPath}'.");
            WaitForContinue();

            return backupPath;
        }

        /// <summary>
        /// Compresses the backup folder using the specified backup path
        /// </summary>
        /// <param name="backupPath">The backup path</param>
        internal void CompressBackupFolder(string backupPath)
        {
            string zipBackupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
            ZipFile.CreateFromDirectory(backupPath, zipBackupPath);
            Directory.Delete(backupPath, true);

            Logger.Info($"Backup compressed at '{zipBackupPath}'.");
            OnUpdateProgressChanged(0.75f, "Backup compressed.");
            WaitForContinue();
        }

        /// <summary>
        /// Removes the old backup archives
        /// </summary>
        internal void RemoveOldBackupArchives()
        {
            List<FileInfo> backupFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Backup_*.zip")
                .Select(file => new FileInfo(file))
                .OrderByDescending(fi => fi.CreationTime)
                .ToList();

            if (backupFiles.Count <= 2)
            {
                Logger.Info("No old backups to delete.");
                return;
            }

            foreach (FileInfo file in backupFiles.Skip(2))
            {
                File.Delete(file.FullName);
                Logger.Info($"Deleted old backup: {file.Name}");
                OnUpdateProgressChanged(0.8f, $"Deleted old backup: {file.Name}");
                WaitForContinue();
            }
        }

        /// <summary>
        /// Gets the platform
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Platform not supported.</exception>
        /// <returns>The string</returns>
        [ExcludeFromCodeCoverage]
        private string GetPlatform() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "win" : RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "linux" : RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "osx" : throw new PlatformNotSupportedException("Platform not supported.");

        /// <summary>
        /// Selects the asset using the specified assets
        /// </summary>
        /// <param name="assets">The assets</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        /// <returns>A dictionary of string and object</returns>
        private Dictionary<string, object> SelectAsset(object[] assets, string platform, string architecture)
        {
            foreach (Dictionary<string, object> asset in assets)
            {
                string assetName = asset["name"]?.ToString();
                if (assetName == null)
                {
                    continue;
                }

                if (assetName.Contains(platform) && assetName.Contains(architecture))
                {
                    return asset;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the latest release
        /// </summary>
        /// <returns>A task containing a dictionary of string and object</returns>
        [ExcludeFromCodeCoverage]
        public async Task<Dictionary<string, object>> GetLatestReleaseAsync()
        {
            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "request");
            string response = await httpClient.GetStringAsync(GitHubApiService.ApiUrl);
            Logger.Info($"Fetched release payload ({response.Length} chars).");

            List<Dictionary<string, object>> releases = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    {"tag_name", "v0.7.5"},
                    {
                        "assets", new object[]
                        {
                            new Dictionary<string, object>
                            {
                                {"name", "app-win-x64.zip"},
                                {"browser_download_url", "https://example.com/app-win-x64.zip"}
                            },
                            new Dictionary<string, object>
                            {
                                {"name", "app-linux-x64.zip"},
                                {"browser_download_url", "https://example.com/app-linux-x64.zip"}
                            },
                            new Dictionary<string, object>
                            {
                                {"name", "app-osx-x64.dmg"},
                                {"browser_download_url", "https://example.com/app-osx-x64.dmg"}
                            }
                        }
                    }
                }
            };

            foreach (Dictionary<string, object> release in releases)
            {
                string version = release["tag_name"]?.ToString();
                if (version == VersionToInstall)
                {
                    Logger.Info($"Matched requested version '{VersionToInstall}'.");
                    return release;
                }
            }

            if (releases.Count == 0)
            {
                Logger.Exception("No releases found.");
                return null;
            }

            if ("latest" == VersionToInstall)
            {
                Logger.Info("Returning latest release entry.");
                return releases[0];
            }

            Logger.Exception("The latest version is already installed.");
            return null;
        }

        /// <summary>
        /// Downloads the file using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The file path</returns>
        public async Task<string> DownloadFileAsync(string url)
        {
            string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            Logger.Info($"Downloading file '{fileName}' to '{filePath}'.");

            using HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync(new Uri(url));
            using FileStream fs = new FileStream(filePath, FileMode.CreateNew);
            await response.Content.CopyToAsync(fs);

            OnUpdateProgressChanged(0.5f, "Download completed.");
            Logger.Info($"Download completed for '{fileName}'.");
            return filePath;
        }

        /// <summary>
        /// Extracts the and replace using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <exception cref="InvalidOperationException">The file has an invalid extension.</exception>
        internal void ExtractAndReplace(string fileAsync)
        {
            Logger.Info($"Starting extract and replace for '{fileAsync}'.");
            string packageType = GetPackageType(fileAsync);

            ExecutePackageExtraction(fileAsync, packageType);
            ReportPackageExtractionCompleted(packageType);
        }

        /// <summary>
        /// Gets the package type using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <returns>The package type</returns>
        internal string GetPackageType(string fileAsync)
        {
            if (IsZipPackage(fileAsync))
            {
                return "zip";
            }

            if (IsDmgPackage(fileAsync))
            {
                return "dmg";
            }

            return "invalid";
        }

        /// <summary>
        /// Ises the zip package using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <returns>The bool</returns>
        internal bool IsZipPackage(string fileAsync) => fileAsync.Contains(".zip");

        /// <summary>
        /// Ises the dmg package using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <returns>The bool</returns>
        internal bool IsDmgPackage(string fileAsync) => fileAsync.Contains(".dmg");

        /// <summary>
        /// Executes the package extraction using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <param name="packageType">The package type</param>
        /// <exception cref="InvalidOperationException">The file has an invalid extension.</exception>
        [ExcludeFromCodeCoverage]
        internal void ExecutePackageExtraction(string fileAsync, string packageType)
        {
            if (packageType == "zip")
            {
                Logger.Info("Zip package detected, running zip extraction.");
                ExtractZip(fileAsync);
                return;
            }

            if (packageType == "dmg")
            {
                Logger.Info("Dmg package detected, running dmg extraction.");
                ExtractDmg(fileAsync);
                return;
            }

            Logger.Info($"Invalid package type detected for '{fileAsync}'.");
            throw new InvalidOperationException("The file has an invalid extension.");
        }

        /// <summary>
        /// Reports the package extraction completed using the specified package type
        /// </summary>
        /// <param name="packageType">The package type</param>
        internal void ReportPackageExtractionCompleted(string packageType)
        {
            if (packageType == "zip")
            {
                OnUpdateProgressChanged(0.8f, "Extracted and replaced .zip file.");
                Logger.Info("Extracted and replaced .zip file.");
                return;
            }

            if (packageType == "dmg")
            {
                OnUpdateProgressChanged(0.8f, "Extracted and replaced .dmg file.");
                Logger.Info("Extracted and replaced .dmg file.");
            }
        }

        /// <summary>
        /// Extracts the dmg using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        internal void ExtractDmg(string fileAsync)
        {
            Logger.Info($"Extracting dmg file '{fileAsync}'.");
            string mountPath = GetDmgMountPath(fileAsync);
            MountDmg(fileAsync, mountPath);
            EnsureProgramFolderExists();
            CopyMountedDmgToProgramFolder(mountPath);
            UnmountDmg(mountPath);
        }

        /// <summary>
        /// Gets the dmg mount path using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <returns>The string</returns>
        internal string GetDmgMountPath(string fileAsync) => Path.Combine("/Volumes", Path.GetFileNameWithoutExtension(fileAsync));

        /// <summary>
        /// Mounts the dmg using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <param name="mountPath">The mount path</param>
        internal void MountDmg(string fileAsync, string mountPath)
        {
            ExecuteShellCommand($"hdiutil attach \"{fileAsync}\" -nobrowse -mountpoint \"{mountPath}\"");
            OnUpdateProgressChanged(0.82f, "Mounted .dmg file.");
            Logger.Info("Mounted .dmg file.");
            WaitForContinue();
        }

        /// <summary>
        /// Ensures the program folder exists
        /// </summary>
        internal void EnsureProgramFolderExists()
        {
            if (!Directory.Exists(ProgramFolder))
            {
                Logger.Info($"Creating program folder '{ProgramFolder}'.");
                Directory.CreateDirectory(ProgramFolder);
            }

            WaitForContinue();
        }

        /// <summary>
        /// Copies the mounted dmg to program folder using the specified mount path
        /// </summary>
        /// <param name="mountPath">The mount path</param>
        internal void CopyMountedDmgToProgramFolder(string mountPath)
        {
            OnUpdateProgressChanged(0.85f, "Copying contents from .dmg to target directory...");
            Logger.Info("Copying contents from .dmg to target directory...");
            ExecuteShellCommand($"cp -R \"{mountPath}/.\" \"{ProgramFolder}\"");
            WaitForContinue();
        }

        /// <summary>
        /// Unmounts the dmg using the specified mount path
        /// </summary>
        /// <param name="mountPath">The mount path</param>
        internal void UnmountDmg(string mountPath)
        {
            OnUpdateProgressChanged(0.88f, "Unmounting .dmg file...");
            Logger.Info("Unmounting .dmg file...");
            ExecuteShellCommand($"hdiutil detach \"{mountPath}\"");
        }

        /// <summary>
        /// Waits the for continue
        /// </summary>
        internal void WaitForContinue()
        {
            if (ContinueDelayMilliseconds > 0)
            {
                Thread.Sleep(ContinueDelayMilliseconds);
            }
        }

        /// <summary>
        /// Executes the shell command using the specified command
        /// </summary>
        /// <param name="command">The command</param>
        internal void ExecuteShellCommand(string command)
        {
            Logger.Info($"Executing shell command: {command}");
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{command}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();
                Logger.Info($"Shell command finished with code {process.ExitCode}.");
            }
        }

        /// <summary>
        /// Extracts the zip using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <exception cref="InvalidOperationException">Exceeded the maximum compression ratio threshold.</exception>
        /// <exception cref="InvalidOperationException">Exceeded the maximum number of entries threshold.</exception>
        /// <exception cref="InvalidOperationException">Exceeded the maximum uncompressed size threshold.</exception>
        [ExcludeFromCodeCoverage]
        internal void ExtractZip(string fileAsync)
        {
            int totalSizeArchive = 0;
            int totalEntryArchive = 0;

            using (FileStream zipToOpen = new FileStream(fileAsync, FileMode.Open))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    totalEntryArchive++;

                    if (totalEntryArchive > ThresholdEntries)
                    {
                        throw new InvalidOperationException("Exceeded the maximum number of entries threshold.");
                    }

                    using (Stream entryStream = entry.Open())
                    {
                        byte[] buffer = new byte[1024];
                        int totalSizeEntry = 0;
                        int numBytesRead;

                        while ((numBytesRead = entryStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            totalSizeEntry += numBytesRead;
                            totalSizeArchive += numBytesRead;

                            double compressionRatio = (double)totalSizeEntry / entry.CompressedLength;
                            if (compressionRatio > ThresholdRatio)
                            {
                                throw new InvalidOperationException("Exceeded the maximum compression ratio threshold.");
                            }
                        }

                        if (totalSizeArchive > ThresholdSize)
                        {
                            throw new InvalidOperationException("Exceeded the maximum uncompressed size threshold.");
                        }
                    }
                }
            }

            ZipFile.ExtractToDirectory(fileAsync, ProgramFolder);
            OnUpdateProgressChanged(0.7f, "Extracted and replaced.");
            Logger.Info($"Zip extracted to '{ProgramFolder}'.");
        }

        /// <summary>
        /// Cleans the temp file
        /// </summary>
        internal void CleanTempFile()
        {
            Logger.Info("Starting temporary file cleanup.");
            OnUpdateProgressChanged(0.9f, "Cleaning temporary files...");
            WaitForContinue();
            Logger.Info("Temporary files cleaned.");
            CleanTemporaryFilesByPattern("*.zip");
            CleanTemporaryFilesByPattern("*.dmg");
        }

        /// <summary>
        /// Cleans the temporary files by pattern using the specified pattern
        /// </summary>
        /// <param name="pattern">The pattern</param>
        internal void CleanTemporaryFilesByPattern(string pattern)
        {
            Logger.Info($"Cleaning temporary files with pattern '{pattern}'.");
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, pattern);
            foreach (string file in files)
            {
                if (file.Contains("Backup"))
                {
                    continue;
                }

                File.Delete(file);
                OnUpdateProgressChanged(0.95f, $"Cleaning temporary file '{Path.GetFileName(file)}'...");
                Logger.Info($"Cleaning temporary file '{file}'...");
                WaitForContinue();
            }
        }
    }
}

