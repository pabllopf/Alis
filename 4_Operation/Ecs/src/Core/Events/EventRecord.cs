﻿using System;
using Frent.Collections;

namespace Frent.Core.Events;

internal class EventRecord
{
    internal TagEvent Tag;
    internal TagEvent Detach;
    internal ComponentEvent Add;
    internal ComponentEvent Remove;
    internal FrugalStack<Action<Entity>> Delete;

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