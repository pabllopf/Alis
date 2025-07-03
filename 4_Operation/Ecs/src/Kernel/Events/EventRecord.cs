using System;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Kernel.Events
{
    /// <summary>
    ///     The event record class
    /// </summary>
    public class EventRecord
    {
        /// <summary>
        ///     The add
        /// </summary>
        internal ComponentEvent Add;

        /// <summary>
        ///     The delete
        /// </summary>
        internal FrugalStack<Action<GameObject>> Delete;

        /// <summary>
        ///     The detach
        /// </summary>
        internal TagEvent Detach;

        /// <summary>
        ///     The remove
        /// </summary>
        internal ComponentEvent Remove;

        /// <summary>
        ///     The tag
        /// </summary>
        internal TagEvent Tag;

        /// <summary>
        ///     Initalizes the exists
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
                record.Delete = new FrugalStack<Action<GameObject>>();
            }
        }
    }
}