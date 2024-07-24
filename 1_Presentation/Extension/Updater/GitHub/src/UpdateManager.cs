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
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Updater.GitHub.Events;
using Alis.Extension.Updater.GitHub.Services.Api;
using Alis.Extension.Updater.GitHub.Services.Files;

namespace Alis.Extension.Updater.GitHub
{
    /// <summary>
    /// The update manager class
    /// </summary>
    public sealed class UpdateManager
    {
        /// <summary>
        /// The git hub api service
        /// </summary>
        private readonly IGitHubApiService _gitHubApiService;
        
        /// <summary>
        /// The file service
        /// </summary>
        private readonly IFileService _fileService;
        
        /// <summary>
        /// The program folder
        /// </summary>
        private readonly string _programFolder;
        
        public event UpdateProgressEventHandler UpdateProgressChanged;
        
        public float Progress { get; private set; }
        
        public string Message { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateManager"/> class
        /// </summary>
        /// <param name="gitHubApiService">The git hub api service</param>
        /// <param name="fileService">The file service</param>
        /// <param name="apiUrl">The api url</param>
        /// <param name="programFolder">The program folder</param>
        public UpdateManager(IGitHubApiService gitHubApiService, IFileService fileService, string programFolder)
        {
            _gitHubApiService = gitHubApiService;
            _fileService = fileService;
            _programFolder = programFolder;
        }
        
        private void OnUpdateProgressChanged(float progress, string message)
        {
            UpdateProgressChanged?.Invoke(progress, message);
            Progress = progress;
            Message = message;
        }
        
        /// <summary>
        /// Updates the game
        /// </summary>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> UpdateGameAsync()
        {
            try
            {
                Dictionary<string, object> latestRelease = await GetLatestReleaseAsync();
                if (latestRelease == null) return false;
                
                string platform = GetPlatform();
                string architecture = RuntimeInformation.OSArchitecture.ToString().ToLower();
                
                Logger.Info($"{platform}-{architecture} platform detected");
                OnUpdateProgressChanged(0.1f, $"{platform}-{architecture} platform detected");
                Thread.Sleep(3000);
                
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
                Thread.Sleep(3000);
                Logger.Info($"Downloading package for {platform}-{architecture}...");
                OnUpdateProgressChanged(0.3f, $"Downloading package for {platform}-{architecture}...");
                
                // wait 1 second
                Thread.Sleep(3000);
                if (downloadUrl != null)
                {
                    string fileName = Path.GetFileName(new Uri(downloadUrl).AbsolutePath);
                    string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                    
                    OnUpdateProgressChanged(0.4f, "Checking if the latest version is already installed...");
                    Thread.Sleep(3000);
                    
                    // Verificar si ya está descargada la última versión
                    if (File.Exists(filePath))
                    {
                        long fileSize = new FileInfo(filePath).Length;
                        long assetSize = (long) selectedAsset["size"];
                        if (fileSize == assetSize)
                        {
                            OnUpdateProgressChanged(1, "The latest version is already downloaded.");
                            Logger.Info("The latest version is already downloaded.");
                            CleanTempFile();
                            Thread.Sleep(3000);
                            return true;
                        }
                    }
                }
                
                OnUpdateProgressChanged(0.5f, $"Downloading the latest version '{version}'");
                Logger.Info($"Downloading the latest version '{version}'");
                Thread.Sleep(3000);
                
                OnUpdateProgressChanged(0.6f, "Installing the latest version...");
                Logger.Info($"Installing the latest version '{version}'");
                Thread.Sleep(3000);
                
                string zipPath = await DownloadFileAsync(downloadUrl);
                if (string.IsNullOrEmpty(zipPath))
                {
                    OnUpdateProgressChanged(0, "Error downloading package.");
                    Logger.Info("Error downloading package.");
                    Thread.Sleep(3000);
                    return false;
                }
                
                
                //Backup the current program:
                Backup();
                ExtractAndReplace(zipPath);
                
                CleanTempFile();
                OnUpdateProgressChanged(1, "Update completed successfully.");
                Logger.Info("Update completed successfully.");
                Thread.Sleep(3000);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating program: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Backups this instance
        /// </summary>
        private void Backup()
        {
            if (!Directory.Exists(_programFolder))
            {
                Logger.Info("Backup not completed.");
                OnUpdateProgressChanged(0, "Backup not completed.");
                Thread.Sleep(1000);
                return;
            }
            
            Logger.Info("Backup completed.");
            OnUpdateProgressChanged(0.7f, "Backup completed.");
            
            string backupPath = Path.Combine(Environment.CurrentDirectory, "Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            Directory.Move(_programFolder, backupPath);
            
            Thread.Sleep(2000);
            
            // Comprimir el backup:
            string zipBackupPath = Path.Combine(Environment.CurrentDirectory, "Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
            ZipFile.CreateFromDirectory(backupPath, zipBackupPath);
            Directory.Delete(backupPath, true);
            Logger.Info("Backup compressed.");
            OnUpdateProgressChanged(0.75f, "Backup compressed.");
            
            Thread.Sleep(2000);
            
            // Mantener solo los 2 backups más recientes
            List<FileInfo> backupFiles = Directory.GetFiles(Environment.CurrentDirectory, "Backup_*.zip")
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
                    Thread.Sleep(2000);
                }
            }
        }
        
        /// <summary>
        /// Gets the platform
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Platform not supported.</exception>
        /// <returns>The string</returns>
        private string GetPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return "win";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return "linux";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return "osx";
            throw new PlatformNotSupportedException("Platform not supported.");
        }
        
        
        /// <summary>
        /// Selects the asset using the specified assets
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
                if (assetName == null) continue;
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
        /// <returns>A task containing the object</returns>
        private async Task<Dictionary<string, object>> GetLatestReleaseAsync()
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "request");
            string response = await client.GetStringAsync("https://api.github.com/repos/pabllopf/alis/releases/latest");
            return JsonSerializer.Deserialize<Dictionary<string, object>>(response);
        }
        
        /// <summary>
        /// Downloads the file using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The file path</returns>
        private async Task<string> DownloadFileAsync(string url)
        {
            string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            
            using HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync(url);
            using FileStream fs = new FileStream(filePath, FileMode.CreateNew);
            await response.Content.CopyToAsync(fs);
            
            OnUpdateProgressChanged(0.5f, "Download completed.");
            
            return filePath;
        }
        
        /// <summary>
        /// Extracts the and replace using the specified zip path
        /// </summary>
        /// <param name="zipPath">The zip path</param>
        private void ExtractAndReplace(string zipPath)
        {
            ZipFile.ExtractToDirectory(zipPath, _programFolder);
            OnUpdateProgressChanged(0.7f, "Extracted and replaced.");
        }
        
        /// <summary>
        /// Cleans the backup
        /// </summary>
        private void CleanTempFile()
        {
            OnUpdateProgressChanged(0.9f, "Cleaning temporary files...");
            Thread.Sleep(3000);
            Logger.Info("Temporary files cleaned.");
            string[] files = Directory.GetFiles(Environment.CurrentDirectory, "*.zip");
            foreach (string file in files)
            {
                if (!file.Contains("Backup"))
                {
                    File.Delete(file);
                }
            }
        }
    }
}