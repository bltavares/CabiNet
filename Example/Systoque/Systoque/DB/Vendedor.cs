
using System;
using CabiNet;

namespace DB
{
    public class Vendedor : IThing
    {

        [MaxLength(255)]
        [Persistent]
        public String Nome { get; set; }

        [MaxLength(255)]
        [Persistent]
        public String Matricula { get; set; }

        [Persistent]
        public DateTime Nascimento
        {
            get
            {
                return _nascimento == new DateTime() ? DateTime.Now : _nascimento;
            }
            set
            {
                _nascimento = value;
            }
        }

        private DateTime _nascimento;

        [Persistent]
        public Double Comissao { get; set; }

    }
}
