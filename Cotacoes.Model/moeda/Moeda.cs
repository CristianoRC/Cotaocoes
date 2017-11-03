namespace Cotacoes.Model
{
    public class Moeda
    {
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public string NomePais { get; private set; }
        public int CodigoPais { get; private set; }
        public char Tipo { get; private set; }


        public Moeda(int codigo)
        {
            atualizarPropriedades(MoedaService.ObterMoeda(codigo));
        }

        public Moeda(string sigla)
        {
            atualizarPropriedades(MoedaService.ObterMoeda(sigla));
        }
        
        private void atualizarPropriedades(Moeda moedaConsulta)
        {
            this.Codigo = moedaConsulta.Codigo;
            this.CodigoPais = moedaConsulta.CodigoPais;
            this.Nome = moedaConsulta.Nome;
            this.NomePais = moedaConsulta.NomePais;
            this.Sigla = moedaConsulta.Sigla;
            this.Tipo = moedaConsulta.Tipo;
        }
    }
}