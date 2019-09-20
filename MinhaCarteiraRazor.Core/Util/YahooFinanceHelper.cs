using MinhaCarteiraRazor.Core.Entities.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinhaCarteiraRazor.Core.Util
{
    public class YahooFinanceHelper
    {
        private const string UrlCotacaoYahoo = "https://query1.finance.yahoo.com/v10/finance/quoteSummary/{0}?formatted=true&lang=pt-BR&region=BR&modules=price&corsDomain=finance.yahoo.com";
        private const string UrlCotacaoYahooHistorico = "https://query2.finance.yahoo.com/v8/finance/chart/{0}?formatted=true&lang=pt-BR&region=BR&interval=1d&events=div%7Csplit&range=3mo&corsDomain=finance.yahoo.com";
        private string UrlCotacaoYahooIbov = string.Format(UrlCotacaoYahoo, "%5EBVSP");
        private string UrlCotacaoYahooIbovHistorico = string.Format(UrlCotacaoYahooHistorico, "%5EBVSP");

        /// <summary>
        /// Retorna o papel selecionado pelo usuário.
        /// </summary>
        /// <param name="papel"></param>
        /// <returns></returns>
        public async Task<PapelDTO> GetPapelPriceAsync(PapelDTO papel)
        {
            var result = new PapelDTO();
            var cnv = new Util.Conversor();

            using (var client = new HttpClient())
            {
                string url = papel == null || papel.Codigo == "IBOV" ? UrlCotacaoYahooIbov : string.Format(UrlCotacaoYahoo, papel.Codigo + ".SA");

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var r = cnv.ConverterJsonParaObject<Entities.DTO.Yahoo.RootObject>(json);

                    result.Codigo = papel.Codigo;

                    if (r.quoteSummary.result.Count > 0)
                    {
                        var p = r.quoteSummary.result[0].price;

                        result.Nome = p.shortName;
                        result.Preco = (decimal)p.regularMarketPrice.raw;
                        result.VariacaoPercentual = (decimal)p.regularMarketChangePercent.raw;
                        result.Variacao = (decimal)p.regularMarketChange.raw;
                        result.Maxima = (decimal)p.regularMarketDayHigh.raw;
                        result.Minima = (decimal)p.regularMarketDayLow.raw;
                        result.FechamentoAnterior = (decimal)p.regularMarketPreviousClose.raw;
                        result.Abertura = (decimal)p.regularMarketOpen.raw;
                        result.Fechamento = (decimal)p.regularMarketPrice.raw;
                        result.Volume = p.regularMarketVolume.longFmt;
                        result.DataAtualizacao = cnv.ConverterUnixTimeStampToDateTime(p.regularMarketTime);

                    }
                    else
                    {
                        result.Nome = "Falha ao buscar dados" + r.quoteSummary.error.ToString();
                    }
                }

            }

            return result;
        }


        public async Task<List<PapelHistoricoDTO>> GetPapelHistoricoAsync(PapelDTO papel)
        {
            var result = new List<PapelHistoricoDTO>();
            var cnv = new Util.Conversor();

            using (var client = new HttpClient())
            {
                string url = papel == null || papel.Codigo == "IBOV" ? UrlCotacaoYahooIbovHistorico : string.Format(UrlCotacaoYahooHistorico, papel.Codigo + ".SA");

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var r = cnv.ConverterJsonParaObject<Entities.DTO.YahooChart.RootObject>(json);

                    if (r.chart != null && r.chart.result != null && r.chart.result.Count > 0)
                    {
                        var quote = r.chart.result[0].indicators.quote != null ? r.chart.result[0].indicators.quote[0] : new Entities.DTO.YahooChart.Quote();

                        for (int i = 0; i < quote.open.Count; i++)
                        {
                            var h = new PapelHistoricoDTO();
                            h.Papel = papel.Codigo;
                            h.Abertura = (decimal)quote.open[i];
                            h.Fechamento = (decimal)quote.close[i];
                            h.Maxima = (decimal)quote.high[i];
                            h.Minima = (decimal)quote.low[i];
                            h.Data = cnv.ConverterUnixTimeStampToDateTime(r.chart.result[0].timestamp[i]).ToString("dd/MM/yyyy");
                            //h.Data = cnv.ConverterUnixTimeStampToDateTime(r.chart.result[0].indicators)

                            result.Add(h);
                        }
                    }
                }

                return result;

            }
        }

    }
}
