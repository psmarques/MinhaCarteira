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
        private readonly MinhaCarteiraDbContext context;

        public CarteirasController(MinhaCarteiraDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Carteira> GetCarteiras()
        {
            return context.Carteiras;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarteira([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carteira = await context.Carteiras.FindAsync(id);

            if (carteira == null)
            {
                return NotFound();
            }

            return Ok(carteira);
        }
    }
}
