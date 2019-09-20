using Microsoft.AspNetCore.Mvc;
using MinhaCarteiraRazor.Core.Entities;
using MinhaCarteiraRazor.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaCarteiraRazor.Api
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CarteirasController : ControllerBase
    {
        private readonly ICarteiraData data;

        public CarteirasController(ICarteiraData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IEnumerable<Carteira> GetCarteiras()
        {
            return data.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarteira([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carteira = await data.GetAllAsync();

            if (carteira == null)
            {
                return NotFound();
            }

            return Ok(carteira);
        }
    }
}
