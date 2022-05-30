using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.VendingMachines.Commands.MoveVendingMachine.MoveDrinkMachine;
public record MoveDrinkMachineCommand(Guid Id, string Location) : IRequest;
public class MoveDrinkMachineCommandHandler : IRequestHandler<MoveDrinkMachineCommand>
{
    private readonly IApplicationDbContext _context;
    public MoveDrinkMachineCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(MoveDrinkMachineCommand request, CancellationToken cancellationToken)
    {
        var drinkMachine = await _context.DrinkMachines

            .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

        if (drinkMachine == null)
        {
            throw new NotFoundException(nameof(drinkMachine));
        }

        drinkMachine.MoveMachine(request.Location);

        _context.DrinkMachines.Update(drinkMachine);

        await _context.SaveChangesAsync(cancellationToken); 
        
        return Unit.Value;
    }
}
