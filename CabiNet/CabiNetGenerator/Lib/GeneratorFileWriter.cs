using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CabiNet.Generator
{
    class GeneratorFileWriter
    {
        public string DirectoryPath { get; private set; }

        public GeneratorFileWriter(string path)
        {
            DirectoryPath = path;
        }

        public void ClassToFile(ICabinetGenerator @class)
        {
            StreamWriter writer = File.CreateText(Path.Combine(DirectoryPath, @class.Name + ".cs"));
            writer.Write(@class.ToString());
            writer.Close();
        }
        public void ToFile(string name, string content)
        {
            StreamWriter writer = File.CreateText(Path.Combine(DirectoryPath, name));
            writer.Write(content);
            writer.Close();
        }
    }
}
