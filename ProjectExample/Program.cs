using Alis.Tools;
using System;
using System.Diagnostics;
using System.Reflection;

namespace ProjectExample
{
    class Program
    {
        public static string example = "Pirate";

        static void Main(string[] args)
        {
            
            Language.Change += Language_Change;

            Language.TranslateTo(Idiom.English);
            
            Language.TranslateTo(Idiom.Spanish);
            
            Language.TranslateTo(Idiom.French);
            
            Language.TranslateTo(Idiom.Italian);

            Console.ReadKey();
        }

        private static void Language_Change(object sender, Idiom idiom)
        {
            Console.WriteLine("Change to: " + idiom.ToString());
            example = Language.GetSentence(idiom, "CONTEXT_CLASS_PIRATE");
            Console.WriteLine("string: " + example + "\n");
        }
    }

    public class Login 
    {
        private string user;
        private string passwd;

        public Login(string user, string passwd)
        {
            this.user = user;
            this.passwd = passwd;
        }

        public string User { get => user; set => user = value; }
        public string Passwd { get => passwd; set => passwd = value; }
    }

}
