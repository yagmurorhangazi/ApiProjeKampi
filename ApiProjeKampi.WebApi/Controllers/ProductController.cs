using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IValidator<Product> _productValidator;
        private readonly ApiContext _context;

        public ProductController(IValidator<Product> productValidator, ApiContext context)
        {
            _productValidator = productValidator;
            _context = context;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();
            return Ok(values);
        }

        [HttpPost]
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _productValidator.Validate(product);

            // HATA BURADAYDI: Ünlem işareti (!) ekleyerek "Geçerli değilse" yaptık
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün başarıyla eklendi.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _context.Products.Find(id);
            _context.Products.Remove(values);
            _context.SaveChanges();
            return Ok("Ürün başarıyla silindi.");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var values = _context.Products.Find(id);
            return Ok(values);
        }

        [HttpPut]

        public IActionResult UpdateProduct(Product product)
        {

            var validationResult = _productValidator.Validate(product);

            // HATA BURADAYDI: Ünlem işareti (!) ekleyerek "Geçerli değilse" yaptık
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("Ürün güncelleme başarılı.");
            }
        }
    }

        }
