using Microsoft.AspNetCore.Mvc;
using MinhaCarteiraRazor.Core.Entities.DTO;
using MinhaCarteiraRazor.Data;
using System.Collections.Generic;

namespace MinhaCarteiraRazor.ApiPublic
{
    [Route("apiPublic/[controller]")]
    public class CarteiraTopFiveController
    {
        private ICarteiraData data { get; }

        public CarteiraTopFiveController(ICarteiraData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IEnumerable<TopFiveDTO> Get()
        {
            return new Core.Util.Conversor().ConverterCarteiraParaTopFive(data.GetTop5());
        }
    }


}
