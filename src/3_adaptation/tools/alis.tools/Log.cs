// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Log.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Text.Json.Serialization;

namespace Alis.Tools;

/// <summary>

/// The log class

/// </summary>

public class Log
{
    
    
    /// <summary>
    /// The level
    /// </summary>
    private string level;
    
    /// <summary>
    /// The date time
    /// </summary>
    private DateTime dateTime;
    
    /// <summary>
    /// The message
    /// </summary>
    private string message;

    /// <summary>
    /// The method
    /// </summary>
    private string method;

    /// <summary>
    /// The assembly
    /// </summary>
    private string assembly;

    /// <summary>
    /// The thread
    /// </summary>
    private int thread;
    
    /// <summary>
    /// The stack trace
    /// </summary>
    private string stackTrace;

    /// <summary>
    /// Initializes a new instance of the <see cref="Log"/> class
    /// </summary>
    /// <param name="level">The level</param>
    /// <param name="dateTime">The date time</param>
    /// <param name="message">The message</param>
    /// <param name="method">The method</param>
    /// <param name="assembly">The assembly</param>
    /// <param name="thread">The thread</param>
    /// <param name="stackTrace">The stack trace</param>
    [JsonConstructor]
    public Log( string level, DateTime dateTime, string message, string method, string assembly, int thread, string stackTrace)
    {
        this.level = level;
        this.dateTime = dateTime;
        this.message = message;
        this.method = method;
        this.assembly = assembly;
        this.thread = thread;
        this.stackTrace = stackTrace;
    }
    
    /// <summary>
    /// Gets or sets the value of the level
    /// </summary>
    [JsonPropertyName("level")]
    public string Level
    {
        get => level;
        set => level = value;
    }


    /// <summary>
    /// Gets or sets the value of the date time
    /// </summary>
    [JsonPropertyName("dateTime")]
    public DateTime DateTime
    {
        get => dateTime;
        set => dateTime = value;
    }
    
    /// <summary>
    /// Gets or sets the value of the message
    /// </summary>
    [JsonPropertyName("message")]
    public string Message
    {
        get => message;
        set => message = value;
    }
    
    /// <summary>
    /// Gets or sets the value of the method
    /// </summary>
    [JsonPropertyName("method")]
    public string Method
    {
        get => method;
        set => method = value;
    }
    
    /// <summary>
    /// Gets or sets the value of the assembly
    /// </summary>
    [JsonPropertyName("assembly")]
    public string Assembly
    {
        get => assembly;
        set => assembly = value;
    }
    
    /// <summary>
    /// Gets or sets the value of the thread
    /// </summary>
    [JsonPropertyName("thread")]
    public int Thread
    {
        get => thread;
        set => thread = value;
    }
    
    /// <summary>
    /// Gets or sets the value of the stack trace
    /// </summary>
    [JsonPropertyName("stacktrace")]
    public string StackTrace
    {
        get => stackTrace;
        set => stackTrace = value;
    }
    
}