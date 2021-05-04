//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="CloudData.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dropbox.Api;
    using Dropbox.Api.Files;
    using Newtonsoft.Json;
    
    /// <summary>Manage the cloud data.</summary>
    public class CloudData
    {
        /// <summary>Saves the folder.</summary>
        /// <param name="pathOfCloud">The path of cloud.</param>
        /// <param name="pathToCopy">The path to copy.</param>
        /// <param name="user">The user.</param>
        /// <param name="cloudService">The cloud service.</param>
        public static void SaveFolder(string pathOfCloud, string pathToCopy, User user, CloudService cloudService)
        {
            if (cloudService.Equals(CloudService.Dropbox))
            {
                DropboxClient client = new DropboxClient(user.AccessToken);
                string[] entries = Directory.GetFileSystemEntries(pathToCopy, "*.*", SearchOption.AllDirectories);
                List<string> listFiles = entries.ToList();

                for (int i = 0; i < listFiles.Count; i++)
                {
                    var task = Task.Run(() => Upload(client, pathOfCloud, new FileInfo(listFiles[i]).Name, listFiles[i]));
                    task.Wait();
                    Logger.Log("File uploaded: " + pathOfCloud + "/" + new FileInfo(listFiles[i]).Name);
                }

                Logger.Log("Finish to upload " + listFiles.Count + " files.");
                return;
            }

            throw Logger.Error("CloudService Type not found" + cloudService.ToString());
        }

        /// <summary>Saves the in dropbox a folder asynchronous.</summary>
        /// <param name="pathOfCloud">The path of cloud.</param>
        /// <param name="pathToCopy">The path to copy.</param>
        /// <param name="user">The user.</param>
        /// <param name="extensions">The extensions.</param>
        public static void SaveFolder(string pathOfCloud, string pathToCopy, User user, CloudService cloudService, List<string> extensions)
        {
            if (cloudService.Equals(CloudService.Dropbox))
            {
                DropboxClient client = new DropboxClient(user.AccessToken);
                string[] entries = Directory.GetFileSystemEntries(pathToCopy, "*.*", SearchOption.AllDirectories);
                List<string> listFiles = entries.ToList().FindAll(i => extensions.Any(j => new FileInfo(i).Extension.Contains(j)));

                for (int i = 0; i < listFiles.Count; i++)
                {
                    var task = Task.Run(() => Upload(client, pathOfCloud, new FileInfo(listFiles[i]).Name, listFiles[i]));
                    task.Wait();
                    Logger.Log("File uploaded: " + pathOfCloud + "/" + new FileInfo(listFiles[i]).Name);
                }

                Logger.Log("Finish to upload " + listFiles.Count + " files.");
                return;
            }

            throw Logger.Error("CloudService Type not found" + cloudService.ToString());
        }

        /// <summary>Saves the json.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <param name="nameFile">The name file.</param>
        /// <param name="pathFile">The path file.</param>
        /// <param name="user">The user.</param>
        /// <param name="cloudService">The cloud service.</param>
        public static void SaveJson<T>(T data, string nameFile, string pathFile, User user, CloudService cloudService)
        {
            if (cloudService.Equals(CloudService.Dropbox))
            {
                var indented = Formatting.Indented;

                var settings = new JsonSerializerSettings
                {
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                    TypeNameHandling = TypeNameHandling.All
                };

                string serialized = JsonConvert.SerializeObject(data, indented, settings);
                new DropboxClient(user.AccessToken).Files.UploadAsync(pathFile + "/" + nameFile + ".json", WriteMode.Overwrite.Instance, body: new MemoryStream(Encoding.UTF8.GetBytes(serialized))).Wait();
                return;
            }

            throw Logger.Error("CloudService Type not found" + cloudService.ToString());
        }

        /// <summary>Loads the json.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameFile">The name file.</param>
        /// <param name="pathFile">The path file.</param>
        /// <param name="user">The user.</param>
        /// <param name="cloudService">The cloud service.</param>
        /// <returns></returns>
        public static T LoadJson<T>(string nameFile, string pathFile, User user, CloudService cloudService)
        {
            if (cloudService.Equals(CloudService.Dropbox))
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                    TypeNameHandling = TypeNameHandling.All
                };

                return JsonConvert.DeserializeObject<T>(new DropboxClient(user.AccessToken).Files.DownloadAsync(pathFile + "/" + nameFile + ".json").Result.GetContentAsStringAsync().Result, settings);
            }

            throw Logger.Error("CloudService Type not found" + cloudService.ToString());
        }

        /// <summary>Loads the of dropbox a folder.</summary>
        /// <param name="pathOfCloud">The path of cloud.</param>
        /// <param name="pathToDownload">The path to download.</param>
        /// <param name="user">The user.</param>
        /// <param name="extensions">The extensions.</param>
        public static void LoadFolder(string pathOfCloud, string pathToDownload, User user, CloudService cloudService, List<string> extensions)
        {
            if (cloudService.Equals(CloudService.Dropbox))
            {
                DropboxClient client = new DropboxClient(user.AccessToken);
                ListFolderResult cloudList = client.Files.ListFolderAsync(pathOfCloud, true).Result;
                List<Metadata> listFiles = cloudList.Entries.ToList().FindAll(i => i.IsFile).FindAll(i => extensions.Any(j => i.Name.Contains(j)));

                for (int i = 0; i < listFiles.Count; i++)
                {
                    string path = pathToDownload + Path.GetDirectoryName(listFiles[i].PathLower);
                    string pathWithFile = pathToDownload + listFiles[i].PathLower;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (File.Exists(pathWithFile))
                    {
                        File.Delete(pathWithFile);
                    }

                    Stream stream = client.Files.DownloadAsync(listFiles[i].PathLower).Result.GetContentAsStreamAsync().Result;
                    FileStream file = File.Create(pathWithFile);
                    stream.CopyTo(file);
                    file.Close();
                }

                return;
            }

            throw Logger.Error("CloudService Type not found" + cloudService.ToString());
        }

        public static void LoadFolder(string pathOfCloud, string pathToDownload, User user, CloudService cloudService)
        {
            if (cloudService.Equals(CloudService.Dropbox))
            {
                DropboxClient client = new DropboxClient(user.AccessToken);
                ListFolderResult cloudList = client.Files.ListFolderAsync(pathOfCloud, true).Result;
                List<Metadata> listFiles = cloudList.Entries.ToList().FindAll(i => i.IsFile);

                for (int i = 0; i < listFiles.Count; i++)
                {
                    string path = pathToDownload + Path.GetDirectoryName(listFiles[i].PathLower);
                    string pathWithFile = pathToDownload + listFiles[i].PathLower;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (File.Exists(pathWithFile))
                    {
                        File.Delete(pathWithFile);
                    }

                    Stream stream = client.Files.DownloadAsync(listFiles[i].PathLower).Result.GetContentAsStreamAsync().Result;
                    FileStream file = File.Create(pathWithFile);
                    stream.CopyTo(file);
                    file.Close();
                }

                return;
            }

            throw Logger.Error("CloudService Type not found" + cloudService.ToString());
        }

        /// <summary>Numbers the of files in folder of dropbox.</summary>
        /// <param name="pathOfCloud">The path of cloud.</param>
        /// <param name="user">The user.</param>
        /// <param name="extensions">The extensions.</param>
        /// <returns>Return num of files</returns>
        public static int NumFiles(string pathOfCloud, User user, CloudService cloudService, List<string> extensions)
        {
            if (cloudService.Equals(CloudService.Dropbox))
            {
                DropboxClient client = new DropboxClient(user.AccessToken);
                ListFolderResult cloudList = client.Files.ListFolderAsync(pathOfCloud, true).Result;
                List<Metadata> listFiles = cloudList.Entries.ToList().FindAll(i => i.IsFile).FindAll(i => extensions.Any(j => i.Name.Contains(j)));
                return listFiles.Count;
            }

            throw Logger.Error("CloudService Type not found" + cloudService.ToString());
        }

        /// <summary>Numbers the of files in folder of dropbox.</summary>
        /// <param name="pathOfCloud">The path of cloud.</param>
        /// <param name="user">The user.</param>
        /// <param name="extensions">The extensions.</param>
        /// <returns>Return num of files</returns>
        public static int NumFiles(string pathOfCloud, User user, CloudService cloudService)
        {
            if (cloudService.Equals(CloudService.Dropbox)) 
            {
                DropboxClient client = new DropboxClient(user.AccessToken);
                ListFolderResult cloudList = client.Files.ListFolderAsync(pathOfCloud, true).Result;
                List<Metadata> listFiles = cloudList.Entries.ToList().FindAll(i => i.IsFile);
                return listFiles.Count;
            }

            throw Logger.Error("CloudService Type not found" + cloudService.ToString());
        }

        /// <summary>Uploads the specified DBX.</summary>
        /// <param name="dbx">The DBX.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="file">The file.</param>
        /// <param name="pathFile">The path file.</param>
        private static async Task Upload(DropboxClient dbx, string folder, string file, string pathFile)
        {
            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(pathFile))))
            {
                var updated = await dbx.Files.UploadAsync(folder + "/" + file, WriteMode.Overwrite.Instance, body: mem);
            }
        }
    }
}