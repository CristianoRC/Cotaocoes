using System;
using System.Collections.Generic;
using Dapper;

namespace Cotacoes.Model
{
    internal class AtualizacoesCotacao
    {
        internal static void AtualizarCotacoes()
        {
            try
            {
                if (AtualizacoesCotacao.LiberarAtualizacao())
                {
                    var listaCotacoes = CotacaoCSV.ListarCotacoes();
                    CotacaoService.Adicionar(listaCotacoes);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atualizar cotações: {e.Message}");
            }
        }
        private static bool LiberarAtualizacao()
        {   /*
                O sistema do Banco Central libera atualizações somente de
                Segunda a Sexta, apartir das 13:00
             */

            if (DateTime.Now.Hour >= 13 && (DateTime.Now.DayOfWeek != DayOfWeek.Saturday &&
                                            DateTime.Now.DayOfWeek != DayOfWeek.Sunday))
            {
                try
                {
                    var dataSaida = CotacaoService.ObterDataUltumaCotacao();

                    if (dataSaida == null)
                        return true;
                    else if ((DateTime.Now - dataSaida).TotalDays >= 1)
                        return true;
                    else
                        return false;

                }
                catch (Exception e)
                {
                    throw new Exception($"Erro ao buscar a data da ultima cotação: {e.Message}");
                }
            }
            else
                return false;
        }
    }
}