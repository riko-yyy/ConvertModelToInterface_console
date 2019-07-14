using System;
using System.Collections;
using System.Collections.Generic;

namespace ConvertModelToInterface_console.Model
{
    public class DuplicateKeyDictionary : Dictionary<string, IList<string>>, IModel
    {
    }
}
