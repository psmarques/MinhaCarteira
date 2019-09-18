using Microsoft.AspNetCore.Mvc;
using MinhaCarteiraRazor.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaCarteiraRazor.ApiPublic
{
    [Route("apiPublic/[controller]")]
    public class IbovDataController
    {


        [HttpGet]
        public async Task<PapelDTO> GetAsync()
        {
            //TODO: Implementar esquema de autenticação

            var client = new Core.Util.YahooFinanceHelper();

            var papel = await client.GetPapelPriceAsync(new PapelDTO { Codigo = "IBOV" });

            return papel;
        }

        [HttpGet("{papel}")]
        public async Task<PapelDTO> GetAsync(string papel)
        {
            //TODO: Implementar esquema de autenticação

            var client = new Core.Util.YahooFinanceHelper();

            var ret = await client.GetPapelPriceAsync(new PapelDTO { Codigo = papel });

            return ret;
        }

        [HttpGet("hist/{papel}")]
        public async Task<List<PapelHistoricoDTO>> GetHistoricoAsync(string papel)
        {
            //TODO: Implementar esquema de autenticação

            var client = new Core.Util.YahooFinanceHelper();

            var ret = await client.GetPapelHistoricoAsync(new PapelDTO { Codigo = papel });

            return ret;
        }

        [HttpGet("ibovdata")]
        public async Task<List<string[]>> GetIbovDataAsync()
        {
            //TODO: Implementar esquema de autenticação
            var client = new Core.Util.YahooFinanceHelper();
            var ret = new List<string[]>();

            var r = await client.GetPapelHistoricoAsync(new PapelDTO { Codigo = "IBOV" });
            foreach (var item in r)
            {
                //OHLC
                ret.Add(new string[] { item.Data, item.Abertura.ToString(), item.Maxima.ToString(), item.Minima.ToString(), item.Fechamento.ToString() });
            }

            return ret;
        }



    }
}
