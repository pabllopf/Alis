//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="TextManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Alis.Tools;

    /// <summary>Control the texts of the editor.</summary>
    public static class TextManager
    {
        /// <summary>The directory</summary>
        private static string directory;

        /// <summary>The file</summary>
        private static string file;

        /// <summary>The keys</summary>
        private static Dictionary<int, string> keys;

        /// <summary>The languages</summary>
        private static Dictionary<int, string> languages;

        /// <summary>The idiom</summary>
        private static Idiom idiom;

        private static string[] content;

        /// <summary>Initializes the <see cref="TextManager" /> class.</summary>
        static TextManager() 
        {
            directory ??= Environment.CurrentDirectory + "/Resources/";
            file ??= directory + "Editor.csv";
           
            keys ??= new Dictionary<int, string>();
            idiom = LocalData.Load<Idiom>("Language", Idiom.English);

            languages ??= new Dictionary<int, string>();

            content ??= File.ReadAllLines(file);

            foreach (string line in File.ReadLines(file))
            {
                if (line.Contains("LANGUAGE_EN")) 
                {
                    string[] temp = line.Split(";");
                    for (int i =0; i < temp.Length; i++) 
                    {
                        if (!temp[i].Equals("LANGUAGE_EN")) 
                        {
                            languages.Add(i, temp[i]);
                        }
                    }
                }
            }
        }

        /// <summary>Occurs when [on change idiom].</summary>
        public static event EventHandler<bool> OnChangeIdiom;

        /// <summary>Changes the idiom.</summary>
        /// <param name="idiomToChange">The idiom to change.</param>
        public static void ChangeIdiom(Idiom idiomToChange) 
        {
            idiom = idiomToChange;

            while (keys.Count > 0) 
            {
                keys.Clear();
            }

            OnChangeIdiom?.Invoke(idiom, true);
        }

        /// <summary>Gets the specified setence.</summary>
        /// <param name="setence">The setence.</param>
        /// <returns>return text.</returns>
        public static string Get(Sentence setence) 
        {
            if (keys.ContainsKey((int)setence))
            {
                return keys[(int)setence];
            }
            else 
            {
                if (!Directory.Exists(directory))
                {
                    throw Logger.Error("Directory dont`t exits " + directory);
                }

                if (!File.Exists(file))
                {
                    throw Logger.Error("File dont`t exits " + file);
                }

                foreach(KeyValuePair<int, string> language in languages)
                {
                    if (language.Value.Equals(idiom.ToString())) 
                    {
                        foreach(string line in content) 
                        {
                            if (!line.Contains("LANGUAGE_EN"))
                            {
                                string[] columns = line.Split(";");
                                if (int.Parse(columns[0]).Equals((int)setence))
                                {
                                    Console.WriteLine("Sentence:" + columns[language.Key]);
                                    keys.Add((int)setence, columns[language.Key]);
                                    return columns[language.Key];
                                }
                            }
                        }
                    }
                }

                return "Text not found";
            }
        }
    }
}