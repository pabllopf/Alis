//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Language.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>Manage the languages of videogame.</summary>
    public static class Language
    {
        /// <summary>Dictionary of current language</summary>
        private static Dictionary<string, string> currentLanguage = new Dictionary<string, string>();

        /// <summary>The directory</summary>
        private static string directory = Environment.CurrentDirectory + "/Resources";

        /// <summary>Occurs when [change].</summary>
        public static event EventHandler<Idiom> OnChange;

        /// <summary>Initializes the <see cref="Language" /> class.</summary>
        static Language()
        {
            OnChange += Language_OnChange;
        }

        /// <summary>Translates to.</summary>
        /// <param name="idiom">The idiom.</param>
        public static void TranslateTo(Idiom idiom)
        {
            OnChange?.Invoke(idiom, idiom);
        }

        /// <summary>Gets the sentence.</summary>
        /// <param name="idiom">The idiom.</param>
        /// <param name="id">The sentence</param>
        /// <returns>Return the sentence.</returns>
        public static string GetSentence(Idiom idiom, string id) 
        {
            string directory = Environment.CurrentDirectory + "/Resources/";
            string file = directory + "Languages.csv";

            if (!Directory.Exists(directory)) 
            {
                throw Logger.Error("Directory dont found " + directory);
            }

            if (!File.Exists(file)) 
            {
                throw Logger.Error("File dont found " + file);
            }

            string[] lineOfId = new List<string>(File.ReadLines(file, GetEncoding(file))).Find(i => i.Contains(id)).Split(',');
            string[] languages = new List<string>(File.ReadLines(file, GetEncoding(file))).Find(i => i.Contains("LANGUAGE_EN")).Split(',');
            string language = languages.ToList().Find(i => i.Contains(idiom.ToString()));
            
            return lineOfId[languages.ToList().IndexOf(language)];
        }

        /// <summary>Gets the encoding.</summary>
        /// <param name="filename">The filename.</param>
        /// <returns>Return the encode</returns>
        public static Encoding GetEncoding(string filename)
        {
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            return bom[0] switch
            {
                0x2b when bom[1] == 0x2f && bom[2] == 0x76 => Encoding.UTF7,
                0xef when bom[1] == 0xbb && bom[2] == 0xbf => Encoding.UTF8,
                0xff when bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0 => Encoding.UTF32,
                0xff when bom[1] == 0xfe => Encoding.Unicode,
                0xfe when bom[1] == 0xff => Encoding.BigEndianUnicode,
                0 when bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff => new UTF32Encoding(true, true),
                _ => Encoding.ASCII,
            };
        }

        #region Define_Events

        /// <summary>Languages the on change.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private static void Language_OnChange(object sender, Idiom e) => Logger.Info();

        #endregion
    }
}