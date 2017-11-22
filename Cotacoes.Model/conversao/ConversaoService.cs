namespace Cotacoes.Model
{
    public static class ConversaoService
    {
        public static Conversao ConverterParaReais(decimal Montante, string SiglaMoeda)
        {
            if (!string.IsNullOrEmpty(SiglaMoeda))
            {
                return ConversaoRepository.ConverterParaReais(Montante, SiglaMoeda);
            }
            else
            {
                throw new System.Exception("Erro ao efetuar a conversão, verifique a sigla");
            }
        }
        public static Conversao ConverterParaDolar(decimal Montante, string SiglaMoeda)
        {
            if (!string.IsNullOrEmpty(SiglaMoeda))
            {
                return ConversaoRepository.ConverterParaDolar(Montante, SiglaMoeda);
            }
            else
            {
                throw new System.Exception("Erro ao efetuar a conversão, verifique a sigla");
            }
        }
    }
}
