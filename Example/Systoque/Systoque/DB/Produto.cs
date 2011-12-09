
using System;
using CabiNet;

namespace DB
{
    public class Produto : IThing
    {

        [MaxLength(255)]
        [Persistent]
        public String Nome { get; set; }

        [MaxLength(255)]
        [Persistent]
        public String CodBarra { get; set; }


        [Persistent]
        public Double Valor { get; set; }



        [Persistent]
        public Double Quantidade { get; set; }



        [Persistent]
        public Double QuantidadeMinima { get; set; }



        [Persistent]
        public DateTime Validade
        {
            get { return _validade == new DateTime() ? DateTime.Now : _validade; }
            set { _validade = value; }
        }

        private DateTime _validade;


        [MaxLength(255)]
        [Persistent]
        public String Lote { get; set; }


        [MaxLength(255)]
        [Persistent]
        public String PrazoGarantia { get; set; }


        public Produto()
        {
            DoBeforeValidation<Produto>(p => { if (p.PrazoGarantia == null) p.PrazoGarantia = ""; });
        }

    }
}
