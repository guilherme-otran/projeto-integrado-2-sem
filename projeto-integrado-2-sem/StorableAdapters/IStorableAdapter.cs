using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Models;

namespace projeto_integrado_2_sem
{
    public interface IStorableAdapter<T>
    {
        string DefineIdentifier(T storable);
        T FromSerializedToPublic(T stored);
    }
}
