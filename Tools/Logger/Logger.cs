//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Debug.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>Debug messages.</summary>
    public static class Logger
    {
        /// <summary>The listener</summary>
        private static readonly TextWriterTraceListener listener;

        /// <summary>My file</summary>
        private static readonly Stream myFile;

        /// <summary>The writer</summary>
        private static readonly TextWriterTraceListener writer;

        /// <summary>The level</summary>
        private static Level level;

        /// <summary>Initializes a new instance of the <see cref="Logger" /> class.</summary>
        static Logger() 
        {
            if (listener == null && writer == null) 
            {
                level = (Level)Enum.Parse(level.GetType(), LocalData.Load("Config_Log", Level.Normal.ToString()));

                listener = new(Console.Out);

                string path = Environment.CurrentDirectory + "/logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                myFile = File.Create(path + "/" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".log");

                writer = new(myFile);

                if (!Trace.Listeners.Contains(listener))
                {
                    Trace.Listeners.Add(listener);
                    Trace.Listeners.Add(writer);
                    Trace.AutoFlush = true;
                }
            }
        }

        /// <summary>Informations this instance.</summary>
        public static void Info()
        {
            if (level == Level.Verbose || level == Level.Info)
            {
                Trace.WriteLine("[" + DateTime.Now.ToString() + "]" + " INFO        " + Environment.StackTrace.Split("at")[3]);
            }
        }

        /// <summary>Logs the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Log(string message)
        {
            if (level == Level.Verbose || level == Level.Info || level == Level.Normal)
            {
                StackTrace stack = new(true);
                string fullName = stack.GetFrame(1).GetMethod().ReflectedType.FullName + "." + stack.GetFrame(1).GetMethod().Name;
                Trace.WriteLine("[" + DateTime.Now.ToString() + "]" + " " + "LOG        " + " " + fullName + "()" + " | " + message);
            }
        }

        /// <summary>Warnings the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Warning(string message)
        {
            if (level == Level.Verbose || level == Level.Info || level == Level.Normal)
            {
                StackTrace stack = new(true);
                string fullName = stack.GetFrame(1).GetMethod().ReflectedType.FullName + "." + stack.GetFrame(1).GetMethod().Name;

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Trace.WriteLine("[" + DateTime.Now.ToString() + "]" + " " + "WARNING      " + " " + fullName + "()" + " | " + message);
                Console.ResetColor();
            }
        }

        /// <summary>Errors the specified message.</summary>
        /// <param name="message">The message.</param>
        public static Exception Error(string message)
        {
            StackTrace stack = new(true);
            string fullName = stack.GetFrame(1).GetMethod().ReflectedType.FullName + "." + stack.GetFrame(1).GetMethod().Name;

            Console.BackgroundColor = ConsoleColor.DarkRed;

            string result = "[" + DateTime.Now.ToString() + "]" + " " + "ERROR        " + " " + fullName + "()" + " | " + message + "\nERROR " + Environment.StackTrace.Trim();
            Trace.WriteLine(result);
            Console.ResetColor();

            return new Exception(result);
        }
    }
}