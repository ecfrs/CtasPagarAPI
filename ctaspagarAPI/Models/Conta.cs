using System;
using System.Collections.Generic;

namespace CtasPagarAPI.Models
{
    public partial class Conta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
