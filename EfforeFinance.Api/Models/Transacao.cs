using System;

namespace EfforeFinance.Api.Models
{
    public class Transacao
    {
        public int idTransacao { get; set; }
        public int idConta { get; set; }
        public int idCategoria { get; set; }
        public decimal vlTransacao { get; set; }
        public DateTime dtTransacao { get; set; }
        public string deTransacao { get; set; }
        public string tpTransacao { get; set; }
        public string statusTransacao { get; set; } = "Efetivada";
    }
}