using ECommerce.APIProject.Config;
using ECommerce.Core.Constants;
using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Entities;
using ECommerce.Core.Interfaces.IUseCases.IProductUseCases;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("product/{ProductId}")]
        public async Task<ActionResult<ProductDtoOut>> GetProductById(string ProductId)
        {
            bool checkGuidValidat = Guid.TryParse(ProductId, out Guid result);
            if (!checkGuidValidat)
                return BadRequest($"Bad input -Guid : {ProductId} not valid- ");
            var product = await _getProductById.Execute(result);
            if (product == null)
                return NotFound("Product with id : " + ProductId + " Can't Be Found");
            return Ok(product);
        }



        // POST api/<ProductController>
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("/product")]
        public async Task<ActionResult> AddProduct([FromBody] ProductDtoIn productIn)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _addProduct.Execute(productIn);
            return Ok("Product Added Successfully");
        }


        // PUT api/<ProductController>/5
        [Authorize(Roles = Roles.Admin)]
        [HttpPut("product/{ProductId}")]
        public async Task<ActionResult> UpdateProduct(string ProductId, [FromBody] ProductDtoForUpdate productForUpdating)
        {
            bool checkGuidValidat = Guid.TryParse(ProductId, out Guid result);
            if (!checkGuidValidat)
                return BadRequest($"Bad input -Guid : {ProductId} not valid- ");
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            await _updateProduct.Execute(productForUpdating, result);
            return Ok("Product Has Been Updated");
        }


        // DELETE api/<ProductController>/5
        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("product/{ProductId}")]
        public async Task<ActionResult> DeleteProduct(string ProductId)
        {
            bool checkGuidValidat = Guid.TryParse(ProductId, out Guid result);
            if (!checkGuidValidat)
                return BadRequest($"Bad input -Guid : {ProductId} not valid- ");
            await _deleteProduct.Execute(result);
            return Ok("Product Has Been Deleted");
        }


        [Authorize(Roles = Roles.Admin)]
        [HttpPost("AddDescound/{productId}")]
        public async Task<ActionResult> AddDescound(string productId, [FromBody] double amount)
        {
            bool checkGuidValidat = Guid.TryParse(productId, out Guid Id);
            if (!checkGuidValidat)
                return BadRequest($"Bad input -Guid : {productId} not valid- ");
            await _removeDescound.Execute(Id);
            var check = double.TryParse(amount.ToString(), out double AmountInDouble);
            if (!check)
                return BadRequest("Not a number");
            await _makeDescound.Execute(Id, AmountInDouble);
            return Ok("Done ");
        }


        [Authorize(Roles = Roles.Admin)]
        [HttpPost("DeleteDescound/{productId}")]
        public async Task<ActionResult> DeleteDescound(string productId)
        {
            bool checkGuidValidat = Guid.TryParse(productId, out Guid Id);
            if (!checkGuidValidat)
                return BadRequest($"Bad input -Guid : {productId} not valid- ");
            
            await _removeDescound.Execute(Id);
            return Ok("Done ");
        }
    }
}
