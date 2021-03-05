using System;
using System.Collections.Generic;

namespace CtasPagarAPI.Models
{
    public partial class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Imagem { get; set; }
    }
}
