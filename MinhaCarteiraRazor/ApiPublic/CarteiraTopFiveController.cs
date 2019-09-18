using Microsoft.AspNetCore.Mvc;
using MinhaCarteiraRazor.Core.DTO;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
