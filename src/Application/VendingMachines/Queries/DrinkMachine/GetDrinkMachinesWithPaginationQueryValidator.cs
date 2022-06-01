using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Application.VendingMachines.Queries.DrinkMachine;
public class GetDrinkMachinesWithPaginationQueryValidator : AbstractValidator<GetDrinkMachinesWithPaginationQuery>
{
    public GetDrinkMachinesWithPaginationQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");

    }
}
