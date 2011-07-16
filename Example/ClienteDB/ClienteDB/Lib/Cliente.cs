using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabiNet;

namespace ClienteDB
{
    class Cliente : IThing
    {
        [Persistent]
        [NotNull]
        public string Nome { get; set; }

        [Persistent]
        [MaxLength(5)]
        public string Endereco { get; set; }

        [Persistent]
        public string Telefone { get; set; }

        [Persistent]
        public string Email { get; set; }

    }
}
