using System;

namespace Alis.Extension.Io.FileDialog.Sample
{
    /// <summary>
    /// The program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        static void Main(string[] args)
        {
            PrintResult(Dialog.FileOpenMultiple("pdf", null));
            PrintResult(Dialog.FileOpen(null));
            PrintResult(Dialog.FileSave(null));
            PrintResult(Dialog.FolderPicker(null));
        }

        /// <summary>
        /// Prints the result using the specified result
        /// </summary>
        /// <param name="result">The result</param>
        static void PrintResult(DialogResult result)
        {
            Console.WriteLine($"Path: {result.Path}, IsError {result.IsError}, IsOk {result.IsOk}, IsCancelled {result.IsCancelled}, ErrorMessage {result.ErrorMessage}");
            if (result.Paths != null)
            {
                Console.WriteLine("Paths");
                foreach (string path2 in result.Paths)
                {
                    Console.WriteLine(path2);
                }
            }
        }
    }
}
