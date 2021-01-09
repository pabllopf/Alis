using Alis.Tools;
using System;
using System.Diagnostics;
using System.Reflection;

namespace ProjectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string hola = "Hola Mundo";
            
            LocalData.Save("HolaVar", hola);
            
            string loadVar = LocalData.Load<string>("HolaVar");


            Login login = new Login("Pablo", "12345");
            LocalData.Save("LastLogin", login);

            Login loginLoaded = LocalData.Load<Login>("LastLogin");

            Console.WriteLine("Last Login:: " + loginLoaded.User + loginLoaded.Passwd );

            Console.ReadKey();
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
