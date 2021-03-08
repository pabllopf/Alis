//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Input.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Alis.Tools;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using static SFML.Window.Keyboard;

    /// <summary>Manage the inputs of game.</summary>
    public class Input
    {
        /// <summary>The keys</summary>
        private List<Key> keys = new List<Key>();

        private Array keysHist;

        /// <summary>Occurs when [on press key].</summary>
        public event EventHandler<Key> OnPressKey;

        /// <summary>Occurs when [on press once].</summary>
        public event EventHandler<Key> OnPressKeyOnce;

        public Input()
        {
            keysHist = Enum.GetValues(typeof(Key));
        }

        internal Task Start()
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                watch.Stop();
                Console.WriteLine($"  Time to Start INPUT: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        internal Task Update() 
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                List<Task> tasks = new List<Task>();

                foreach (Key key in Enum.GetValues(typeof(Key)))
                {
                    if (IsKeyPressed(key))
                    {
                        tasks.Add(PullTask(key));
                    }
                }

                if (tasks.Count > 0) 
                {
                    Task.WaitAll(tasks.ToArray());
                }
               
                watch.Stop();
                Console.WriteLine($"    Time to Input: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        private Task PullTask(Key key) 
        {
            return Task.Factory.StartNew(()=> 
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                if (IsKeyPressed(key))
                {
                    if (!keys.Contains(key))
                    {
                        Console.WriteLine("Key presed: " + key);
                        keys.Add(key);
                        OnPressKeyOnce?.Invoke(null, key);
                    }
                }

                if (IsKeyPressed(key))
                {
                    Console.WriteLine("Key presed: " + key);
                    OnPressKey?.Invoke(null, key);
                }

                if (!IsKeyPressed(key) && keys.Contains(key))
                {
                    keys.Remove(key);
                }

                watch.Stop();
                Console.WriteLine($"        Time to Press: "+ key + " " + watch.ElapsedMilliseconds + " ms");
            });
        }
    }
}

/*
/// <summary>The keys</summary>
private static List<SFML.Window.Keyboard.Key> keys = new List<SFML.Window.Keyboard.Key>();

/// <summary>Occurs when [on press key].</summary>
public static event EventHandler<SFML.Window.Keyboard.Key> OnPressKey;

/// <summary>Occurs when [on press once].</summary>
public static event EventHandler<SFML.Window.Keyboard.Key> OnPressKeyOnce;

/// <summary>Polls the events.</summary>
private static void PollEvents()
{
    foreach (SFML.Window.Keyboard.Key key in Enum.GetValues(typeof(SFML.Window.Keyboard.Key)))
    {
        if (SFML.Window.Keyboard.IsKeyPressed(key))
        {
            if (!keys.Contains(key))
            {
                keys.Add(key);
                if (OnPressKeyOnce != null)
                {
                    OnPressKeyOnce?.Invoke(null, key);
                }
            }
        }

        if (SFML.Window.Keyboard.IsKeyPressed(key))
        {
            if (OnPressKey != null)
            {
                if (IsKeyPressed(key))
        {
            Console.WriteLine("Key presed: " + key);
            keys.Add(key);
            OnPressKeyOnce?.Invoke(null, key);
        }
            }
        }

        if (!SFML.Window.Keyboard.IsKeyPressed(key) && keys.Contains(key))
        {
            keys.Remove(key);
        }
    }
}

internal async Task Update()
{
    await Task.Run(()=> 
    {
        List<Task> tasks = new List<Task>();

        foreach (SFML.Window.Keyboard.Key key in Enum.GetValues(typeof(SFML.Window.Keyboard.Key)))
        {
            tasks.Add(PollInputAsync(key));
        }

        Task.WhenAll(tasks).Wait();
    });
}

private async Task PollInputAsync(SFML.Window.Keyboard.Key key)
{
    if (SFML.Window.Keyboard.IsKeyPressed(key))
    {
        if (!keys.Contains(key))
        {
            keys.Add(key);
            if (OnPressKeyOnce != null)
            {
                OnPressKeyOnce?.Invoke(null, key);
            }
        }

        if (SFML.Window.Keyboard.IsKeyPressed(key))
        {
            if (OnPressKey != null)
            {
                OnPressKey?.Invoke(null, key);
            }
        }

        if (!SFML.Window.Keyboard.IsKeyPressed(key) && keys.Contains(key))
        {
            keys.Remove(key);
        }
    }
}
}
}*/