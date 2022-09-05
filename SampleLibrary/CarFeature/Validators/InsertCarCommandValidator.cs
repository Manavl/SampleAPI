using FluentValidation;
using SampleLibrary.Car.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Car.Validators
{
    public class InsertCarCommandValidator : AbstractValidator<InsertCarCommand>
    {
        public InsertCarCommandValidator()
        {
            RuleFor(x => x.car.Brand).NotEmpty().WithMessage("Zapomněl si zapsat značku.");
            RuleFor(x => x.car.Model).NotEmpty().WithMessage("Zapomněl si zapsat model.");
            RuleFor(x => x.car.Price).NotEmpty().WithMessage("Zapomněl si zapsat cenu.");
        }
    }
}
