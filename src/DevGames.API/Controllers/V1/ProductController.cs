using DevGames.Application.Interfaces;
using DevGames.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DevGames.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _productAppService.SearchAsync(a => true);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> Get(Guid id)
        {
            var result = await _productAppService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ProductViewModel model)
        {
            var result = await _productAppService.AddAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProductViewModel model)
        {
            return Ok(_productAppService.Update(model));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _productAppService.Remove(id);
            return Ok();
        }

        [HttpPost("decreaseStock/{productId}/{quantity}")]
        public ActionResult SetDecreaseStock(Guid productId, int quantity)
        {
            try
            {
                _productAppService.DecreaseStock(productId, quantity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
