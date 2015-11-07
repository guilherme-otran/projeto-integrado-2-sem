﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Models;

namespace projeto_integrado_2_sem
{
    public interface IStorableAdapter<T>
    {
        int AttributeCount();
        string[] AsStringArray(T storable);
        T FromStringArray(string identifier, string[] data);
        string Identifier(T storable);
        string Version();
        string DefineIdentifier(T storable, int autoIncrementValue);
    }
}
