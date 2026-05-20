using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez.");
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır.");
            RuleFor(p => p.ProductName).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır.");


            RuleFor(p => p.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez").GreaterThan(0).WithMessage("Ürün fiyatı sıfırdan küçük" +
                " olamaz.").LessThan(10000).WithMessage("Ürün fiyatı 10.000'den büyük olamaz.");

            RuleFor(p => p.Description).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez.");
        }
    }
}
