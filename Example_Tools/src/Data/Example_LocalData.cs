//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Example_CloudData.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Example_Tools
{
    using System;
    using System.IO;
    using Alis.Tools;

    public static class Example_LocalData
    {
        internal static void Run()
        {
            // EXAMPLES TO LOAD / SAVE JSON AND CONVERT OF LOCAL
            Example_Save_Json_On_LocalData();
            Example_Load_Json_of_LocalData();
        }

        private static void Example_Save_Json_On_LocalData()
        {
            string path = Environment.CurrentDirectory + "/Data/example.json";
            LocalData.Save<int>("example", 10);
            Logger.Log("SAVED IN LOCAL: " + " value: " + File.ReadAllText(path) + " of file:" + path);
        }

        private static void Example_Load_Json_of_LocalData()
        {
            string path = Environment.CurrentDirectory + "/Data/example.json";
            int loaded = LocalData.Load<int>("example");
            Logger.Log("LOADED OF LOCAL: " + " value: " + loaded + " of file:" + path);
        }
    }
}
