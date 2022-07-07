using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Target.Business.Contract;
using Target.Entities.DTO;

namespace Target.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusinness _productBusiness;

        public ProductController(IProductBusinness productBusiness)
        {
            this._productBusiness = productBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            return await _productBusiness.AllAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            ProductDTO member = await _productBusiness.FindSync(id);
            if (member == null) return NotFound(id);
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] ProductDTO dto)
        {
            var result = await _productBusiness.AddAsync(dto);
            if (!result.success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put([FromBody] ProductDTO dto)
        {
            //ProductDTO product = await _productBusiness.FindSync(dto.Id);
            //if (product == null) return NotFound(dto.Id);

            var result = await _productBusiness.UpdateAsync(dto);
            if (!result.success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            //ProductDTO product = await _productBusiness.FindSync(dto.Id);
            //if (product == null) return NotFound(dto.Id);

            var result = await _productBusiness.DeleteAsync(id);
            if (result > 0) return Ok(result);
            return BadRequest(result);
        }
    }
}
