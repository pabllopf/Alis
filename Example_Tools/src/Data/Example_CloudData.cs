//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Example_CloudData.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Example_Tools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Alis.Tools;

    /// <summary>Examples of cloud data</summary>
    public static class Example_CloudData
    {
        /// <summary>The user</summary>
        private static User user = new User("Pablo", "12345", "oEhtHFam6SMAAAAAAAAAAWebYRhLZLwshqoT6uO1CTHzQI4Baew32W7NaP8SNH9h");

        /// <summary>Runs this instance.</summary>
        internal static void Run()
        {
            // EXAMPLES TO COUNT NUM OF FILES IN CLOUD
            Example_Num_Of_Files_CloudData();
            Example_Num_Of_Json_Files_CloudData();

            // EXAMPLES TO DOWNLOAD / UPLOAD A FOLDER OF CLOUD 
            Example_Download_folder_of_CloudData();
            Example_Upload_folder_of_CloudData();

            // EXAMPLES TO LOAD / SAVE JSON AND CONVERT OF CLOUD
            Example_Load_Json_of_CloudData();
            Example_Save_Json_On_CloudData();
        }

        #region EXAMPLES COUNT FILES ON CLOUD

        /// <summary>Examples the number of files cloud data.</summary>
        private static void Example_Num_Of_Files_CloudData()
        {
            int numOfJSONFiles = CloudData.NumFiles("/Test", user, CloudService.Dropbox);
            Logger.Log("NUM FILES: " + numOfJSONFiles);
        }

        /// <summary>Examples the number of files cloud data.</summary>
        private static void Example_Num_Of_Json_Files_CloudData()
        {
            int numOfJSONFiles = CloudData.NumFiles("/Test", user, CloudService.Dropbox, new List<string>(new string[] { ".json" }));
            Logger.Log("NUM JSON FILES: " + numOfJSONFiles);
        }

        #endregion

        #region EXAMPLES DOWNLOAD FILES/FOLDER OF CLOUD

        private static void Example_Download_folder_of_CloudData()
        {
            string pathCloud = "/Test";
            string pathToDownload = Environment.CurrentDirectory + "/Example_Download";

            CloudData.LoadFolder(pathCloud, pathToDownload, user, CloudService.Dropbox);
            Logger.Log("Dowloaded files: " + Directory.GetFiles(pathToDownload + "/", "*", SearchOption.AllDirectories).Length);
        }

        #endregion

        #region EXAMPLES UPLOAD FOLDER TO CLOUD

        private static void Example_Upload_folder_of_CloudData()
        {
            string pathCloud = "/Test_3";
            string pathToUPLOAD = Environment.CurrentDirectory + "/Data";

            CloudData.SaveFolder(pathCloud, pathToUPLOAD, user, CloudService.Dropbox);

            Logger.Log("End to upload files of folder.");
        }

        #endregion

        #region EXAMPLES DOWNLOAD JSON OF CLOUD

        private static void Example_Load_Json_of_CloudData()
        {
            string pathFileCloud = "/Test";

            User userLoaded = CloudData.LoadJson<User>("User", pathFileCloud, user, CloudService.Dropbox);

            Logger.Log("LOADED JSON: " + userLoaded.Name + " " + userLoaded.Password);
        }

        #endregion

        #region EXAMPLES UPLOAD JSON TO CLOUD

        private static void Example_Save_Json_On_CloudData()
        {
            string pathFileCloud = "/Test_2";

            User userToSave = new User("EXAMPLE", "EXAMPLE12345", "823623962");

            CloudData.SaveJson<User>(userToSave, "User", pathFileCloud, user, CloudService.Dropbox);

            Logger.Log("SAVED JSON: " + userToSave.Name + " " + userToSave.Password);
        }

        #endregion
    }
}
