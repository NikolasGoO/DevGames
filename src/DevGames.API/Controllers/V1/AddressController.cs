using DevGames.Application.Interfaces;
using DevGames.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DevGames.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/address")]
    public class AddressController : Controller
    {
        private readonly IAddressAppService _addressAppService;

        public AddressController(IAddressAppService addressAppService)
        {
            _addressAppService = addressAppService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _addressAppService.SearchAsync(a => true);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressViewModel>> Get(Guid id)
        {
            var result = await _addressAppService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] AddressViewModel model)
        {
            var result = await _addressAppService.AddAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] AddressViewModel model)
        {
            return Ok(_addressAppService.Update(model));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _addressAppService.Remove(id);
            return Ok();
        }
    }
}
