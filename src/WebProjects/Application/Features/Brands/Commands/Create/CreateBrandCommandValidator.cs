using Application.Features.Brands.Constants;
using FluentValidation;

namespace Application.Features.Brands.Commands.Create;

public  class CreateBrandCommandValidator:AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(p=>p.Name).NotEmpty().WithMessage(BrandValidatorMessages.NameCanNotBeEmpty);
        RuleFor(p => p.Name).MinimumLength(2).WithMessage(BrandValidatorMessages.NameLengthCanNotLowerThan2);
    }
}
