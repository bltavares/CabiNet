
using System;
using CabiNet;

namespace DB
{
    public class Venda : IThing
    {


        [Persistent]
        [NotNull]
        public Int64 vendedor_id { get; set; }


        private DateTime _dataVenda;

        [Persistent]
        public DateTime DataVenda
        {
            get
            {
                return _dataVenda == new DateTime() ? DateTime.Now : _dataVenda;
            }
            set
            {
                _dataVenda = value;
            }
        }

        private DateTime _dataPrevEntrega;

        [Persistent]
        public DateTime DataPrevEntrega
        {
            get
            {
                return _dataPrevEntrega == new DateTime() ? DateTime.Now : _dataPrevEntrega;
            }
            set
            {
                _dataPrevEntrega = value;
            }
        }

        [Persistent]
        [NotNull]
        public Double Total { get; set; }


        [MaxLength(255)]
        [Persistent]
        public String Status { get; set; }

        public Venda()
        {
            DoBeforeValidation<Venda>(v => { if (v.vendedor_id == 0)  throw new Exception(); });

        }

    }
}
