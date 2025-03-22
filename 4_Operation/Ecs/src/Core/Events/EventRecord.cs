using System;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Core.Events
{
    /// <summary>
    /// The event record class
    /// </summary>
    internal class EventRecord
    {
        /// <summary>
        /// The tag
        /// </summary>
        internal TagEvent Tag;
        /// <summary>
        /// The detach
        /// </summary>
        internal TagEvent Detach;
        /// <summary>
        /// The add
        /// </summary>
        internal ComponentEvent Add;
        /// <summary>
        /// The remove
        /// </summary>
        internal ComponentEvent Remove;
        /// <summary>
        /// The delete
        /// </summary>
        internal FrugalStack<Action<Entity>> Delete;

        /// <summary>
        /// Initalizes the exists
        /// </summary>
        /// <param name="exists">The exists</param>
        /// <param name="record">The record</param>
        public static void Initalize(bool exists, ref EventRecord record)
        {
            if (!exists)
            {
                record = new EventRecord();
                record.Tag = new TagEvent();
                record.Detach = new TagEvent();
                record.Add = new ComponentEvent();
                record.Remove = new ComponentEvent();
                record.Delete = new FrugalStack<Action<Entity>>();
            }
        }
    }
}