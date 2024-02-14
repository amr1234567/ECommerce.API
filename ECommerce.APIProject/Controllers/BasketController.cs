using ECommerce.Core.Entities.BusketEntities;
using ECommerce.Core.Interfaces.IUseCases.IBasketUseCases;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.APIProject.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ICreateOrUpdateBasketUseCase _createOrUpdateBasket;
        private readonly IDeleteBasketUseCase _deleteBasket;
        private readonly IGetBasketUseCase _getBasket;

        public BasketController(ICreateOrUpdateBasketUseCase createOrUpdateBasket,
            IDeleteBasketUseCase deleteBasket,
            IGetBasketUseCase getBasket)
        {
            _createOrUpdateBasket = createOrUpdateBasket;
            _deleteBasket = deleteBasket;
            _getBasket = getBasket;
        }

        [HttpGet("basket/{basketId}")]
        public async Task<ActionResult<CustomerBasket>> Get(string basketId) 
        {
            var basket = await _getBasket.Execute(basketId);
            if (basket == null) 
                return NotFound("Wrong Id Maybe");
            return Ok(basket);
        }

        [HttpPost("basket")]
        public async Task<ActionResult<CustomerBasket>> AddOrUpdateBasket([FromBody] CustomerBasket customerBasket)
        {
            var basket = await _createOrUpdateBasket.Execute(customerBasket);
            if (basket == null)
                return NotFound("Wrong Id mayber");
            return Ok(basket);
        }

        [HttpDelete("basket/{basketId}")]
        public async Task<ActionResult> AddOrUpdateBasket(string basketId)
        {
            var deleted = await _deleteBasket.Execute(basketId);
            if (!deleted)
                return NotFound("Id Wrong Maybe");

            return Ok("Basket with Id : \"" + basketId + "\" is deleted");
        }

    }
}
