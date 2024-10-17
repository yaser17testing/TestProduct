using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProduct.Data;
using TestProduct.Dto;
using TestProduct.Models;
using TestProduct.Repositories;

namespace TestProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly TestDbContext testDbContext;
        private readonly IProduct productRepo;


        public ProductController(TestDbContext testDbContext, IProduct productRepo)
        {
            this.testDbContext = testDbContext;
            this.productRepo = productRepo;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {



            var productsDomain = await productRepo.GetAllAsync();

            var productsDto = new List<ProductDto>();
            foreach (var productDomain in productsDomain)
            {

                productsDto.Add(new ProductDto()
                {
                    ProductId = productDomain.ProductId,
                    ProductTitle = productDomain.ProductTitle,
                    Description = productDomain.Description,

                });

            }


            return Ok(productsDto);


        }



        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var productDomain = await productRepo.GetByIdAsync(id);

            if (productDomain == null)
            {
                return NotFound();
            }
            var productDto = new ProductDto
            {
                ProductId = productDomain.ProductId,
                ProductTitle = productDomain.ProductTitle,
                Description = productDomain.Description,

            };
            return Ok(productDto);

        }




        [HttpPost]

        public async Task<IActionResult> Create([FromBody] ProductDto addProductDto)
        {
            var productDomainModel = new Product
            {
                ProductTitle = addProductDto.ProductTitle,
                Description = addProductDto.Description,
               

            };




            productDomainModel = await productRepo.CreateAsync(productDomainModel);


            var productDto = new ProductDto
            {
                ProductId = productDomainModel.ProductId,
                ProductTitle = productDomainModel.ProductTitle,
                Description = productDomainModel.Description,
                



            };
            return CreatedAtAction(nameof(GetById), new { id = productDto.ProductId }, productDto);
        }













    }
}
