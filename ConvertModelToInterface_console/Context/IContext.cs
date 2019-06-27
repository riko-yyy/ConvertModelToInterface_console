using System;
using System.Collections.Generic;

namespace ConvertModelToInterface_console.Context
{
    public interface IContext
    {
        T SelectOne<T>() where T : new();
        IEnumerable<T> Select<T>() where T : new();
    }
}
