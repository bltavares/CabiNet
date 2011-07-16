using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabiNet.Generator
{
    public class CollumnGenerator : ICabinetGenerator
    {

        static string Layout = @"
        {0}
        [Persistent]
        public {1} {2} {{ get; set; }}
        
";

        public bool NotNull { get; set; }
        public string Type { get; set; }
        public bool IsMaxLength { get; set; }
        public int MaxLength { get; set; }

        public override string ToString()
        {
            return string.Format(Layout, (IsMaxLength ? "[MaxLength(" + MaxLength + ")]" : ""), Type, Name);
        }
    }
}
