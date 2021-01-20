
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
            AudioSource audio = new AudioSource(Application.ProjectPath + "/Resources/Example.wav");
            
            audio.OnPlay += Audio_OnPlay;
            audio.OnPause += Audio_OnPause;
            audio.OnStop += Audio_OnStop;
            audio.OnRestart += Audio_OnRestart;
            
            audio.Play();


            Console.WriteLine("example:" + new Application().ToString());
            Console.ReadKey();
        }

        private static void Audio_OnRestart(object sender, bool e)
        {
            throw new NotImplementedException();
        }

        private static void Audio_OnStop(object sender, bool e)
        {
            throw new NotImplementedException();
        }

        private static void Audio_OnPause(object sender, bool e)
        {
            throw new NotImplementedException();
        }

        private static void Audio_OnPlay(object sender, bool e)
        {
            Console.WriteLine(sender.ToString() + " playing");
        }
    }
}
