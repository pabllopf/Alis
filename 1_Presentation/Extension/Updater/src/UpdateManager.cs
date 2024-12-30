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
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
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
        ///     The file service
        /// </summary>
        public readonly IFileService _fileService;

        /// <summary>
        ///     The git hub api service
        /// </summary>
        public readonly IGitHubApiService _gitHubApiService;

        /// <summary>
        ///     The program folder
        /// </summary>
        public readonly string _programFolder;

        /// <summary>
        ///     The version to install
        /// </summary>
        public readonly string _versionToInstall;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UpdateManager" /> class
        /// </summary>
        /// <param name="gitHubApiService">The git hub api service</param>
        /// <param name="versionToInstall"></param>
        /// <param name="fileService">The file service</param>
        /// <param name="programFolder">The program folder</param>
        public UpdateManager(IGitHubApiService gitHubApiService, string versionToInstall, IFileService fileService, string programFolder)
        {
            _gitHubApiService = gitHubApiService;
            _fileService = fileService;
            _programFolder = programFolder;
            _versionToInstall = versionToInstall;
        }

        /// <summary>
        ///     Gets or sets the value of the progress
        /// </summary>
        public float Progress { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        ///     Event handler for the update progress
        /// </summary>
        public event UpdateProgressEventHandler UpdateProgressChanged;

        /// <summary>
        ///     Ons the update progress changed using the specified progress
        /// </summary>
        /// <param name="progress">The progress</param>
        /// <param name="message">The message</param>
        private void OnUpdateProgressChanged(float progress, string message)
        {
            UpdateProgressChanged?.Invoke(progress, message);
            Progress = progress;
            Message = message;
        }

        /// <summary>
        ///     Updates the game
        /// </summary>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> Start()
        {
            try
            {
                Dictionary<string, object> latestRelease = await GetLatestReleaseAsync();
                if (latestRelease == null)
                {
                    return false;
                }

                string platform = GetPlatform();
                string architecture = RuntimeInformation.OSArchitecture.ToString().ToLower();

                Logger.Info($"{platform}-{architecture} platform detected");
                OnUpdateProgressChanged(0.1f, $"{platform}-{architecture} platform detected");
                WaitForContinue();

                object[] assets = (object[]) latestRelease["assets"];

                Dictionary<string, object> selectedAsset = SelectAsset(assets, platform, architecture);
                if (selectedAsset == null)
                {
                    OnUpdateProgressChanged(0, "No compatible package found.");
                    Logger.Info("No compatible package found.");
                    return false;
                }

                string downloadUrl = selectedAsset["browser_download_url"]?.ToString();
                string version = latestRelease["tag_name"]?.ToString();
                Logger.Info($"The latest version available is {version}");
                OnUpdateProgressChanged(0.2f, $"The latest version available is {version}");

                // wait 1 second
                WaitForContinue();
                Logger.Info($"Downloading package for {platform}-{architecture}...");
                OnUpdateProgressChanged(0.3f, $"Downloading package for {platform}-{architecture}...");

                // wait 1 second
                WaitForContinue();
                if (downloadUrl != null)
                {
                    string fileName = Path.GetFileName(new Uri(downloadUrl).AbsolutePath);
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                    OnUpdateProgressChanged(0.4f, "Checking if the latest version is already installed...");
                    WaitForContinue();

                    // Verificar si ya está descargada la última versión
                    if (File.Exists(filePath))
                    {
                        OnUpdateProgressChanged(1, "The latest version is already downloaded.");
                        Logger.Info("The latest version is already downloaded.");
                        CleanTempFile();
                        WaitForContinue();
                        return true;
                    }
                }

                OnUpdateProgressChanged(0.5f, $"Downloading the latest version '{version}'");
                Logger.Info($"Downloading the latest version '{version}'");
                WaitForContinue();

                string fileAsync = await DownloadFileAsync(downloadUrl);
                if (string.IsNullOrEmpty(fileAsync))
                {
                    OnUpdateProgressChanged(0, "Error downloading package.");
                    Logger.Info("Error downloading package.");
                    WaitForContinue();
                    return false;
                }

                //Backup the current program:
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
            catch (Exception ex)
            {
                throw new Exception($"Error updating program: {ex.Message}");
            }
        }

        /// <summary>
        ///     Backups this instance
        /// </summary>
        private void Backup()
        {
            if (!Directory.Exists(_programFolder))
            {
                Logger.Info("Don't need to do backup.");
                OnUpdateProgressChanged(0.7f, "Don't need to do backup.");
                Thread.Sleep(1000);
                return;
            }

            Logger.Info("Doing backup...");
            OnUpdateProgressChanged(0.7f, "Doing backup...");

            string backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            Directory.Move(_programFolder, backupPath);

            WaitForContinue();

            OnUpdateProgressChanged(0.72f, "Folder moved to backup.");
            Logger.Info("Folder moved to backup.");

            WaitForContinue();

            // Comprimir el backup:
            string zipBackupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
            ZipFile.CreateFromDirectory(backupPath, zipBackupPath);
            Directory.Delete(backupPath, true);
            Logger.Info("Backup compressed.");
            OnUpdateProgressChanged(0.75f, "Backup compressed.");

            WaitForContinue();

            // Mantener solo los 2 backups más recientes
            List<FileInfo> backupFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Backup_*.zip")
                .Select(file => new FileInfo(file))
                .OrderByDescending(fi => fi.CreationTime)
                .ToList();

            if (backupFiles.Count > 2)
            {
                foreach (FileInfo file in backupFiles.Skip(2))
                {
                    File.Delete(file.FullName);
                    Logger.Info($"Deleted old backup: {file.Name}");
                    OnUpdateProgressChanged(0.8f, $"Deleted old backup: {file.Name}");
                    WaitForContinue();
                }
            }
        }

        /// <summary>
        ///     Gets the platform
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Platform not supported.</exception>
        /// <returns>The string</returns>
        private string GetPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "win";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "linux";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return "osx";
            }

            throw new PlatformNotSupportedException("Platform not supported.");
        }


        /// <summary>
        ///     Selects the asset using the specified assets
        /// </summary>
        /// <param name="assets">The assets</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        /// <returns>The token</returns>
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
        ///     Gets the latest release
        /// </summary>
        /// <returns>A task containing the object</returns>
        private async Task<Dictionary<string, object>> GetLatestReleaseAsync()
        {
            using HttpClient _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "request");
            string response = await _httpClient.GetStringAsync(_gitHubApiService.apiUrl);
            List<Dictionary<string, object>> releases = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(response);

            foreach (Dictionary<string, object> release in releases)
            {
                string version = release["tag_name"]?.ToString();
                if (version == _versionToInstall)
                {
                    return release;
                }
            }

            if (releases.Count == 0)
            {
                Logger.Exception("No releases found.");
                return null;
            }

            if ("latest" == _versionToInstall)
            {
                return releases[0];
            }

            Logger.Exception("The latest version is already installed.");
            return null;
        }

        /// <summary>
        ///     Downloads the file using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The file path</returns>
        private async Task<string> DownloadFileAsync(string url)
        {
            string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            using HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync(url);
            using FileStream fs = new FileStream(filePath, FileMode.CreateNew);
            await response.Content.CopyToAsync(fs);

            OnUpdateProgressChanged(0.5f, "Download completed.");

            return filePath;
        }

        /// <summary>
        ///     Extracts the and replace using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <exception cref="InvalidOperationException">The file has an invalid extension.</exception>
        private void ExtractAndReplace(string fileAsync)
        {
            if (fileAsync.Contains(".zip"))
            {
                ExtractZip(fileAsync);
                OnUpdateProgressChanged(0.8f, "Extracted and replaced .zip file.");
                Logger.Info("Extracted and replaced .zip file.");
                return;
            }

            if (fileAsync.Contains(".dmg"))
            {
                ExtractDmg(fileAsync);
                OnUpdateProgressChanged(0.8f, "Extracted and replaced .dmg file.");
                Logger.Info("Extracted and replaced .dmg file.");
                return;
            }

            throw new InvalidOperationException("The file has an invalid extension.");
        }

        /// <summary>
        ///     Extracts the dmg using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        private void ExtractDmg(string fileAsync)
        {
            // Define the path where the .dmg will be mounted
            string mountPath = Path.Combine("/Volumes", Path.GetFileNameWithoutExtension(fileAsync));

            // Mount the .dmg file
            ExecuteShellCommand($"hdiutil attach \"{fileAsync}\" -nobrowse -mountpoint \"{mountPath}\"");
            OnUpdateProgressChanged(0.82f, "Mounted .dmg file.");
            Logger.Info("Mounted .dmg file.");

            WaitForContinue();

            // Assuming _programFolder is the destination where you want to copy the contents of the .dmg
            if (!Directory.Exists(_programFolder))
            {
                Directory.CreateDirectory(_programFolder);
            }

            WaitForContinue();

            OnUpdateProgressChanged(0.85f, "Copying contents from .dmg to target directory...");
            Logger.Info("Copying contents from .dmg to target directory...");

            // Copy the contents from the mounted .dmg to the target directory
            ExecuteShellCommand($"cp -R \"{mountPath}/.\" \"{_programFolder}\"");


            WaitForContinue();

            // Unmount the .dmg file
            OnUpdateProgressChanged(0.88f, "Unmounting .dmg file...");
            Logger.Info("Unmounting .dmg file...");
            ExecuteShellCommand($"hdiutil detach \"{mountPath}\"");
        }

        /// <summary>
        ///     Waits the for continue
        /// </summary>
        private void WaitForContinue()
        {
            Thread.Sleep(1000);
        }

        /// <summary>
        ///     Executes the shell command using the specified command
        /// </summary>
        /// <param name="command">The command</param>
        private void ExecuteShellCommand(string command)
        {
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
            }
        }


        /// <summary>
        ///     Extracts the zip using the specified file async
        /// </summary>
        /// <param name="fileAsync">The file</param>
        /// <exception cref="InvalidOperationException">Exceeded the maximum compression ratio threshold.</exception>
        /// <exception cref="InvalidOperationException">Exceeded the maximum number of entries threshold.</exception>
        /// <exception cref="InvalidOperationException">Exceeded the maximum uncompressed size threshold.</exception>
        private void ExtractZip(string fileAsync)
        {
            ZipFile.ExtractToDirectory(fileAsync, _programFolder);
            OnUpdateProgressChanged(0.7f, "Extracted and replaced.");
        }

        /// <summary>
        ///     Cleans the backup
        /// </summary>
        private void CleanTempFile()
        {
            OnUpdateProgressChanged(0.9f, "Cleaning temporary files...");
            WaitForContinue();
            Logger.Info("Temporary files cleaned.");
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.zip");
            foreach (string file in files)
            {
                if (!file.Contains("Backup"))
                {
                    File.Delete(file);
                    OnUpdateProgressChanged(0.95f, $"Cleaning temporary file '{Path.GetFileName(file)}'...");
                    Logger.Info($"Cleaning temporary file '{file}'...");
                    WaitForContinue();
                }
            }

            files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dmg");
            foreach (string file in files)
            {
                if (!file.Contains("Backup"))
                {
                    File.Delete(file);
                    OnUpdateProgressChanged(0.95f, $"Cleaning temporary file '{Path.GetFileName(file)}'...");
                    Logger.Info($"Cleaning temporary file '{file}'...");
                    WaitForContinue();
                }
            }
        }
    }
}