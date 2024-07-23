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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Updater.GitHub
{
    /// <summary>
    /// The update manager class
    /// </summary>
    public class UpdateManager
    {
        
        public  string UpdateStatus = $"Checking for updates...";
        
        public float Progress = 0;
        
        /// <summary>
        /// The api url
        /// </summary>
        private readonly string _apiUrl = "https://api.github.com/repos/pabllopf/Alis/releases/latest";
        
        /// <summary>
        /// The current directory
        /// </summary>
        private readonly string _programFolder = Path.Combine(Environment.CurrentDirectory, "bin");

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
                
                Console.WriteLine($"{platform}-{architecture} platform detected");
                Progress = 0.1f;
                UpdateStatus = $"{platform}-{architecture} platform detected";
                Thread.Sleep(3000);

                object[] assets = (object[])latestRelease["assets"];
                
                Dictionary<string, object> selectedAsset = SelectAsset(assets, platform, architecture);
                if (selectedAsset == null)
                {
                    UpdateStatus = "No compatible package found.";
                    Progress = 0;
                    Console.WriteLine("No compatible package found.");
                    return false;
                }

                string downloadUrl = selectedAsset["browser_download_url"]?.ToString();
                string version = latestRelease["tag_name"]?.ToString();
                Console.WriteLine($"The latest version available is {version}");
                UpdateStatus = $"The latest version available is {version}";
                Progress = 0.2f;
               
                // wait 1 second
                Thread.Sleep(3000);
                Console.WriteLine($"Downloading package for {platform}-{architecture}...");
                UpdateStatus = $"Downloading package for {platform}-{architecture}...";
                Progress = 0.3f;
                
                // wait 1 second
                Thread.Sleep(3000);
                if (downloadUrl != null)
                {
                    string fileName = Path.GetFileName(new Uri(downloadUrl).AbsolutePath);
                    string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                    
                    UpdateStatus = $"Checking if the latest version is already installed...";
                    Progress = 0.4f;
                    Thread.Sleep(3000);

                    // Verificar si ya está descargada la última versión
                    if (File.Exists(filePath))
                    {
                        long fileSize = new FileInfo(filePath).Length;
                        long assetSize = (long)selectedAsset["size"];
                        if (fileSize == assetSize)
                        {
                            UpdateStatus = "The latest version is already installed.";
                            Progress = 1;
                            Console.WriteLine("La última versión ya está descargada.");
                            CleanTempFile();
                            Thread.Sleep(3000);
                            return true; 
                        }
                    }
                }

                UpdateStatus = $"Downloading the latest version '{version}'";
                Progress = 0.5f;
                Console.WriteLine($"Downloading the latest version '{version}'");
                Thread.Sleep(3000);
                
                UpdateStatus = $"Installing the latest version '{version}'";
                Progress = 0.6f;
                Console.WriteLine($"Installing the latest version '{version}'");
                Thread.Sleep(3000);

                string zipPath = await DownloadFileAsync(downloadUrl);
                if (string.IsNullOrEmpty(zipPath))
                {
                    UpdateStatus = "Error downloading package.";
                    Progress = 0;
                    Console.WriteLine("Error downloading package.");
                    Thread.Sleep(3000);
                    return false;
                }
                
                
                //Backup the current program:
                Backup();
                ExtractAndReplace(zipPath);

                CleanTempFile();
                UpdateStatus = "Update completed successfully.";
                Progress = 1;
                Console.WriteLine("Update completed successfully.");
                Thread.Sleep(3000);
                return true;
            }
            catch (Exception ex)
            {
                UpdateStatus = $"Error updating program: {ex.Message}";
                throw new Exception($"Error updating program: {ex.Message}");
            }
        }

        private void Backup()
        {
            if (!Directory.Exists(_programFolder))
            {
                Console.WriteLine("Backup not completed.");
                UpdateStatus = "Backup not completed.";
                Progress = 0.6f;
                Thread.Sleep(1000);
                return;
            }
            
            Console.WriteLine("Backup completed.");
            UpdateStatus = "Backup completed.";
            Progress = 0.7f;

            string backupPath = Path.Combine(Environment.CurrentDirectory, "Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            Directory.Move(_programFolder, backupPath);

            Thread.Sleep(2000);

            // Comprimir el backup:
            string zipBackupPath = Path.Combine(Environment.CurrentDirectory, "Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
            ZipFile.CreateFromDirectory(backupPath, zipBackupPath);
            Directory.Delete(backupPath, true);
            Console.WriteLine("Backup compressed.");
            UpdateStatus = "Backup compressed.";
            Progress = 0.75f;

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
                    Console.WriteLine($"Deleted old backup: {file.Name}");
                    UpdateStatus = $"Deleted old backup: {file.Name}";
                    Progress = 0.77f;
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
            string response = await client.GetStringAsync(_apiUrl);
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

            UpdateStatus = "Download completed.";
            Progress = 0.5f;
            
            return filePath;
        }
        
        /// <summary>
        /// Extracts the and replace using the specified zip path
        /// </summary>
        /// <param name="zipPath">The zip path</param>
        private void ExtractAndReplace(string zipPath)
        {
            ZipFile.ExtractToDirectory(zipPath, _programFolder);
            UpdateStatus = "Extracted package.";
            Progress = 0.8f;
        }

        /// <summary>
        /// Cleans the backup
        /// </summary>
        private void CleanTempFile()
        {
            UpdateStatus = "Temporary files cleaned.";
            Progress = 0.9f;
            Thread.Sleep(3000);
            Console.WriteLine("Temporary files cleaned.");
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