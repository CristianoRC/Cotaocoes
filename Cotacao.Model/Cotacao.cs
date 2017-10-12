using System;

namespace Cotacao.Model
{
    public class Cotacao
    {
        public int Data { get; private set; }
        public int CodigoMoeda { get; private set; }
        public Double TaxaCompra { get; private set; }
        public Double TaxaVenda { get; private set; }
        public Double ParidadeCompra { get; private set; }
        public Double ParidadeVenda { get; private set; }
    }
}