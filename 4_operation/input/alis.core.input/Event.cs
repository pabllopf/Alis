// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Event.cs
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
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DevDecoder.HIDDevices;
using Microsoft.Extensions.Logging;

namespace Alis.Core.Input
{
    /// <summary>
    ///     Class Event. This class cannot be inherited.
    ///     Each event contains a description of every log event that can be raised by this library.
    /// </summary>
    public sealed class Event
    {
        /// <summary>
        ///     The event
        /// </summary>
        private static readonly Dictionary<int, Event> s_all = new Dictionary<int, Event>();

        /// <summary>
        ///     The refresh failure event.
        /// </summary>
        public static readonly Event RefreshFailure =
            new Event(nameof(Resources.RefreshFailure), nameof(Resources.RefreshFailureDescription));

        /// <summary>
        ///     The device creation failure event.
        /// </summary>
        public static readonly Event DeviceCreationFailure = new Event(LogLevel.Warning, nameof(Resources
            .DeviceCreationFailure), nameof(Resources.DeviceCreationFailureDescription));

        /// <summary>
        ///     The device add event.
        /// </summary>
        public static readonly Event DeviceAdd = new Event(LogLevel.Information, nameof(Resources.DeviceAdd),
            nameof(Resources.DeviceAddDescription));

        /// <summary>
        ///     The device remove event.
        /// </summary>
        public static readonly Event DeviceRemove = new Event(LogLevel.Information, nameof(Resources
            .DeviceRemove), nameof(Resources.DeviceRemoveDescription));

        /// <summary>
        ///     The device update event.
        /// </summary>
        public static readonly Event DeviceUpdate = new Event(LogLevel.Information, nameof(Resources
            .DeviceUpdate), nameof(Resources.DeviceUpdateDescription));

        /// <summary>
        ///     The device connection failed event.
        /// </summary>
        public static readonly Event DeviceConnectionFailed = new Event(LogLevel.Error, nameof(Resources
            .DeviceConnectionFailed), nameof(Resources.DeviceConnectionFailedDescription));

        /// <summary>
        ///     The device connected event.
        /// </summary>
        public static readonly Event DeviceConnected = new Event(LogLevel.Information,
            nameof(Resources.DeviceConnected),
            nameof(Resources.DeviceConnectedDescription));

        /// <summary>
        ///     The device error event.
        /// </summary>
        public static readonly Event DeviceError = new Event(LogLevel.Error, nameof(Resources.DeviceError),
            nameof(Resources.DeviceErrorDescription));

        /// <summary>
        ///     The device connection closed event.
        /// </summary>
        public static readonly Event DeviceConnectionClosed = new Event(LogLevel.Information,
            nameof(Resources.DeviceConnectionClosed),
            nameof(Resources.DeviceConnectionClosedDescription));

        /// <summary>
        ///     The idcounter
        /// </summary>
        private static int s_idCounter = 3500;

        /// <summary>
        ///     The description resource
        /// </summary>
        private readonly string _descriptionResource;

        /// <summary>
        ///     The id
        /// </summary>
        private readonly int _id;

        /// <summary>
        ///     The message resource
        /// </summary>
        private readonly string _messageResource;

        /// <summary>
        ///     The event's log level.
        /// </summary>
        public readonly LogLevel Level;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Event" /> class
        /// </summary>
        /// <param name="messageResource">The message resource</param>
        /// <param name="descriptionResource">The description resource</param>
        private Event(string messageResource, string descriptionResource = null)
            : this(LogLevel.Error, messageResource, descriptionResource)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Event" /> class
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="messageResource">The message resource</param>
        /// <param name="descriptionResource">The description resource</param>
        private Event(LogLevel level, string messageResource, string descriptionResource = null)
        {
            _id = s_idCounter++;
            Level = level;
            _messageResource = messageResource;
            _descriptionResource = descriptionResource ?? messageResource;
            s_all[_id] = this;
        }

        /// <summary>
        ///     Gets the message format.
        /// </summary>
        /// <value>The message format.</value>
        public string Format => Resources.ResourceManager.GetString(_messageResource);

        /// <summary>
        ///     Gets the event's description.
        /// </summary>
        /// <value>The description.</value>
        public string Description => Resources.ResourceManager.GetString(_descriptionResource);

        /// <summary>
        ///     Gets the unique identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public EventId Id => new EventId(_id, Description);

        /// <summary>
        ///     Gets a collection of all events raised by this library.
        /// </summary>
        /// <value>All events.</value>
        public static IReadOnlyCollection<Event> All => s_all.Values;


        /// <summary>
        ///     hello
        /// </summary>
        /// <param name="id"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        public static bool TryGet(int id, out Event @event)
        {
            return s_all.TryGetValue(id, out @event);
        }


        /// <summary>
        ///     Gets the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The event</returns>
        public static Event Get(int id)
        {
            return s_all.TryGetValue(id, out var @event) ? @event : null;
        }


        /// <summary>
        ///     Logs the logger
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="args">The args</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Log(ILogger logger, params object[] args)
        {
            logger.Log(Level, Id, Format, args);
        }


        /// <summary>
        ///     Logs the logger
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="exception">The exception</param>
        /// <param name="args">The args</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Log(ILogger logger, Exception exception, params object[] args)
        {
            logger.Log(Level, Id, exception, Format, args);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Description;
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Event" /> to <see cref="EventId" />.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator EventId(Event @event)
        {
            return @event.Id;
        }
    }
}