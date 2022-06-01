using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.VendingMachines.Commands.CreateVendingMachine.CreateDrinkMachine;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.VendingMachines.Commands.CreateVendingMachine.CreateSnackMachine;
public class CreateSnackMachineCommandValidator : AbstractValidator<CreateDrinkMachineCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateSnackMachineCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(d => d.Name).NotEmpty().WithMessage("Name is required")
            .MaximumLength(50).WithMessage("The name must not exceed 50 characters")
            .MustAsync(BeUniqueName).WithMessage("The Snack Machine name already exists");

    }
    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _context.SnackMachines
            .AllAsync(n => n.Name != name, cancellationToken);
    }
}

