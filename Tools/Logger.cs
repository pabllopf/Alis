﻿//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Debug.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.Diagnostics;

    /// <summary>Debug messages.</summary>
    public static class Logger
    {
        /// <summary>The listener</summary>
        private static readonly TextWriterTraceListener listener = new(Console.Out);

        /// <summary>The level</summary>
        private static readonly Level level = Level.Normal;

        /// <summary>Informations this instance.</summary>
        [Conditional("DEBUG")]
        public static void Info()
        {
            if (level == Level.Verbose || level == Level.Info)
            {
                Console.WriteLine("[" + DateTime.Now.ToString() + "]" + " INFO " + new StackTrace(true).GetFrame(1).GetMethod().ReflectedType.FullName + "." + new StackTrace(true).GetFrame(1).ToString());
            }


            /*if (level == Level.Verbose || level == Level.Info)
            {
                if (!Trace.Listeners.Contains(listener))
                {
                    Trace.Listeners.Add(listener);
                    Trace.AutoFlush = true;
                }

                StackTrace stack = new StackTrace(true);

                string date = "[" + DateTime.Now.ToString() + "]";
                string type = "";
                string fullName = stack.GetFrame(1).GetMethod().ReflectedType.FullName + "." + stack.GetFrame(1).GetMethod().Name;
                string fileName = Path.GetFileName(stack.GetFrame(1).GetFileName());
                string line = stack.GetFrame(1).GetFileLineNumber().ToString();

                string param = "";
                ParameterInfo[] parameters = stack.GetFrame(1).GetMethod().GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    param += parameters[i].ParameterType + " " + parameters[i].Name + ((i < parameters.Length - 1) ? ", " : "");
                }

                type = stack.GetFrame(1).GetMethod().IsConstructor ? "CONSTRUCTOR" :
                       stack.GetFrame(1).GetMethod().Name.Contains("On") ? "EVENT      " : "METHOD     ";


                if (level == Level.Verbose)
                {
                    fullName = fullName.Replace(".ctor", "Contructor");
                    Trace.WriteLine(date + " " + type + " " + fullName + "(" + param + ")" + " File:" + fileName + " Line:" + line);
                }

                if (level == Level.Info)
                {
                    fullName = fullName.Replace(".ctor", "Contructor");
                    Trace.WriteLine(date + " " + type + " " + fullName + "(" + param + ")");
                }
            }*/
        }

        /// <summary>Logs the specified message.</summary>
        /// <param name="message">The message.</param>
        [Conditional("DEBUG")]
        public static void Log(string message)
        {
            if (level == Level.Verbose || level == Level.Info || level == Level.Normal)
            {
                if (!Trace.Listeners.Contains(listener))
                {
                    Trace.Listeners.Add(listener);
                    Trace.AutoFlush = true;
                }

                StackTrace stack = new(true);

                string date = "[" + DateTime.Now.ToString() + "]";
                string type = "LOG        ";
                string fullName = stack.GetFrame(1).GetMethod().ReflectedType.FullName + "." + stack.GetFrame(1).GetMethod().Name;

                fullName = fullName.Replace(".ctor", "Contructor");

                Trace.WriteLine(date + " " + type + " " + fullName + "()" + " | " + message);
            }
        }

        /// <summary>Warnings the specified message.</summary>
        /// <param name="message">The message.</param>
        [Conditional("DEBUG")]
        public static void Warning(string message)
        {
            if (level == Level.Verbose || level == Level.Info || level == Level.Normal)
            {
                if (!Trace.Listeners.Contains(listener))
                {
                    Trace.Listeners.Add(listener);
                    Trace.AutoFlush = true;
                }

                StackTrace stack = new(true);

                string date = "[" + DateTime.Now.ToString() + "]";
                string type = "WARNING    ";
                string fullName = stack.GetFrame(1).GetMethod().ReflectedType.FullName + "." + stack.GetFrame(1).GetMethod().Name;

                fullName = fullName.Replace(".ctor", "Contructor");

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Trace.WriteLine(date + " " + type + " " + fullName + "()" + " | " + message);
                Console.ResetColor();
            }
        }

        /// <summary>Errors the specified message.</summary>
        /// <param name="message">The message.</param>
        public static Exception Error(string message)
        {
            if (!Trace.Listeners.Contains(listener))
            {
                Trace.Listeners.Add(listener);
                Trace.AutoFlush = true;
            }

            StackTrace stack = new(true);

            string date = "[" + DateTime.Now.ToString() + "]";
            string type = "ERROR      ";
            string fullName = stack.GetFrame(1).GetMethod().ReflectedType.FullName + "." + stack.GetFrame(1).GetMethod().Name;

            fullName = fullName.Replace(".ctor", "Contructor");

            Console.BackgroundColor = ConsoleColor.DarkRed;
            string result = date + " " + type + " " + fullName + " | " + message + "\nERROR " + Environment.StackTrace.Trim();
            Trace.WriteLine(result);
            Console.ResetColor();

            return new Exception(result);
        }
    }
}