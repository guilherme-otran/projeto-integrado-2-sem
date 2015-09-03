using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem
{
    interface IStorable<K>
    {
        public string[] AsStringArray();
        public static K FromStringArray(string[] data);
    }
}
