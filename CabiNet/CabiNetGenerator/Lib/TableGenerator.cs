using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CabiNet.Generator
{
    public class TableGenerator : ICabinetGenerator
    {
        static string Layout = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabiNet;

namespace {0}
{{
    class {1} : IThing
    {{
        {2}
    }}
}}
";
        public CabinetGenerator Cabinet;
        public BindingList<CollumnGenerator> Collumns = new BindingList<CollumnGenerator>();

        public override string ToString()
        {
            string _columns = Collumns.Aggregate("", (output, collumn) => output += collumn.ToString());
            return string.Format(Layout, Cabinet.NameSpace, Name, _columns);
        }
    }
}
