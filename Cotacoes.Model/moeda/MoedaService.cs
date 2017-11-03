using System.Collections.Generic;

namespace Cotacoes.Model
{
    public static class MoedaService
    {
        public static Moeda ObterMoeda(int codigo)
        {
            return MoedaRepository.ObterMoeda(codigo);
        }

        public static Moeda ObterMoeda(string sigla)
        {
            sigla = sigla.ToUpper();

            return MoedaRepository.ObterMoeda(sigla);
        }

        public static string ObterNomeMoeda(string sigla)
        {
            sigla = sigla.ToUpper();

            return MoedaRepository.ObterNomeMoeda(sigla);
        }

        public static string ObterNomeMoeda(int codigo)
        {
            return MoedaRepository.ObterNomeMoeda(codigo);
        }

        public static string ObterSiglaMoeda(int codigo)
        {
            return MoedaRepository.ObterSiglaMoeda(codigo);
        }

        public static string ObterCodigoMoeda(string sigla)
        {
            sigla = sigla.ToUpper();

            return MoedaRepository.ObterCodigoMoeda(sigla);
        }

        public static char ObterTipoMoeda(string sigla)
        {
            sigla = sigla.ToUpper();

            return MoedaRepository.ObterTipoMoeda(sigla);
        }

        public static char ObterTipoMoeda(int codigoMoeda)
        {
            return MoedaRepository.ObterTipoMoeda(codigoMoeda);
        }

        public static string ObterNomePais(string siglaMoeda)
        {
            siglaMoeda = siglaMoeda.ToUpper();

            return MoedaRepository.ObterNomePais(siglaMoeda);
        }

        public static string ObterCodigoPais(string siglaMoeda)
        {
            siglaMoeda = siglaMoeda.ToUpper();

            return MoedaRepository.ObterCodigoPais(siglaMoeda);
        }

        public static IEnumerable<Moeda> Listar()
        {
            return MoedaRepository.Listar();
        }
    }
}