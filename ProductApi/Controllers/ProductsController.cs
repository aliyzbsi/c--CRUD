using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs;
using ProductApi.Models;

namespace ProductApi.Controllers
{   
    [ApiController]
    [Route("[controller]")]

    public class ProductsController:ControllerBase{
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context){
            this._context=context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts(){
            var products=await _context.Products.ToListAsync();
            var productResponses=products.Select(p=>new ProductResponse{
                Title=p.Title,
                Sku=p.Sku,
                Barcode=p.Barcode,
                Price=p.Price,
                TitleDomestic=p.TitleDomestic,
                HasVideo=p.HasVideo,
                Stock=p.Stock,
                CurrencyName=p.CurrencyName
            });
            return Ok(productResponses);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(long id){
            var product=await _context.Products.FindAsync(id);
            if(product==null){
                return NotFound();
            }
            var response=new ProductResponse{
                Title = product.Title,
                Sku = product.Sku,
                Barcode = product.Barcode,
                Price = product.Price,
                TitleDomestic = product.TitleDomestic,
                HasVideo = product.HasVideo,
                Stock = product.Stock,
                CurrencyName = product.CurrencyName
            };
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product){
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct),new{id=product.ProductStatusId},product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(long id,Product product){
            if(id!=product.ProductStatusId){
                return BadRequest();
            }
            _context.Entry(product).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!_context.Products.Any(p=>p.ProductStatusId==id)){
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id){
            var product=await _context.Products.FindAsync(id);
            if(product==null){
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}