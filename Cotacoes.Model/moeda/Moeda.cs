namespace Cotacoes.Model
{
    public class Moeda
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string NomePais { get; set; }
        public int CodigoPais { get; set; }
        public char Tipo { get; set; }

        public Moeda() { }

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