using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CabiNet.Generator
{
    public class CabinetGenerator : ICabinetGenerator
    {
        static string Layout = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabiNet;

namespace {0}
{{
    class {1} : ICabinet
    {{

        {2}

        public {1}()
            : base(""{3}"")
        {{ }}


    }}
}}
";
        static string ShelfFormat = @"
public Shelf<{0}> {0} {{ get {{ return Unshelve<{0}>(); }} }}
";

        static string README = @"
Now you need to reference de dll under References on Solution Explorer and add the files generated on the project (Shift + Alt + A).

You may want to use it to generete de tables on the first run also:

{0} db = new {0}();
{1}

";

        static string QueryGenerator = @"
db.ExecuteNonQuery((new {0}).GenerateCreateSQL());
";

        public string NameSpace { get; set; }
        public string ConnectioString { get; set; }
        public BindingList<TableGenerator> Shelfs = new BindingList<TableGenerator>();

        public void InjectCabientOnShelfs()
        {
            foreach (TableGenerator shelf in Shelfs)
                shelf.Cabinet = this;
        }

        public override string ToString()
        {
            string _shelfs = Shelfs.Aggregate("", (output, shelf) => output += string.Format(ShelfFormat, shelf.Name));
            return string.Format(Layout, NameSpace, Name, _shelfs, ConnectioString);
        }

        public string Readme()
        {
            string shelfs = Shelfs.Aggregate("", (output, shelf) => output += string.Format(QueryGenerator, shelf.Name));
            return string.Format(README, Name, shelfs);
        }
    }
}
