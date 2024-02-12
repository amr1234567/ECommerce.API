using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;
using ECommerce.Core.Interfaces.IUseCases.IProductUseCases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAddProductUseCase _addProduct;
        private readonly IDeleteProductUseCase _deleteProduct;
        private readonly IGetProductByIdUseCase _getProductById;
        private readonly IGetProductsByCategoryIdUseCase _getProductsByCategoryId;
        private readonly IGetProductsByFiltersUseCase _getProductsByFilters;
        private readonly IGetProductsUseCase _getProducts;
        private readonly IUpdateProductUseCase _updateProduct;
        private readonly IRemoveDescoundUseCase _removeDescound;
        private readonly IMakeDescoundUseCase _makeDescound;

        public ProductController(
            IAddProductUseCase addProduct,
            IDeleteProductUseCase deleteProduct,
            IGetProductByIdUseCase getProductById,
            IGetProductsByCategoryIdUseCase getProductsByCategoryId,
            IGetProductsByFiltersUseCase getProductsByFilters,
            IGetProductsUseCase getProducts,
            IUpdateProductUseCase updateProduct,
            IRemoveDescoundUseCase removeDescound,
            IMakeDescoundUseCase makeDescound
            )
        {
            _addProduct = addProduct;
            _deleteProduct = deleteProduct;
            _getProductById = getProductById;
            _getProductsByCategoryId = getProductsByCategoryId;
            _getProductsByFilters = getProductsByFilters;
            _getProducts = getProducts;
            _updateProduct = updateProduct;
            _removeDescound = removeDescound;
            _makeDescound = makeDescound;
        }
        // GET: api/<ProductController>
        [HttpGet("products")]
        public async Task<ActionResult<List<ProductDtoOut>>> GetProducts()
        {
            var products = await _getProducts.Execute();
            if (products == null)
                return Ok(new List<ProductDtoOut>());
            return Ok(products);
        }

        [HttpGet("products/{categoryId}")]
        public async Task<ActionResult<List<ProductDtoOut>>> GetProductsByCategoryId(string categoryId)
        {
            bool checkGuidValidat = Guid.TryParse(categoryId, out Guid result);
            if (!checkGuidValidat)
                return BadRequest($"Bad input -Guid : {categoryId} not valid- ");
            var products = await _getProductsByCategoryId.Execute(result);
            if (products == null)
                return Ok(new List<ProductDtoOut>());
            return Ok(products);
        }

        [HttpGet("products/filter")]
        public async Task<ActionResult<List<ProductDtoOut>>> GetProducts(
            [FromQuery] string name = "",
            [FromQuery] double MinPrice = 0,
            [FromQuery] double MaxPrice = double.MaxValue,
            [FromQuery] int MaxQuantity = int.MaxValue,
            [FromQuery] int MinQuantity = 0)
        {
            Func<Product, bool>[] filters = new Func<Product, bool>[]
            {
                c => c.Name.ToLower().Contains(name.ToLower()),
                c => c.Price > MinPrice,
                c => c.Price < MaxPrice,
                c => c.Quentity < MaxQuantity,
                c => c.Quentity > MinQuantity,
            };

            var products = await _getProductsByFilters.Execute(filters);
            if (products == null)
                return Ok(new List<ProductDtoOut>());
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
