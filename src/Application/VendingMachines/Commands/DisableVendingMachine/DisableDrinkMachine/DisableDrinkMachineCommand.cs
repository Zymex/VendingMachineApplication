using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.VendingMachines.Commands.DisableVendingMachine.DisableDrinkMachine;
public record DisableSnackMachineCommand(Guid Id) : IRequest;

public class DisableDrinkMachineCommandHandler : IRequestHandler<DisableSnackMachineCommand>
{
    private readonly IApplicationDbContext _context;
    public DisableDrinkMachineCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DisableSnackMachineCommand request, CancellationToken cancellationToken)
    {
        var drinkMachine = await _context.DrinkMachines
             .Where(x => x.Id == request.Id)
             .SingleOrDefaultAsync(cancellationToken);
        if (drinkMachine == null)
        {
            throw new NotFoundException(nameof(drinkMachine));
        }
        //Disable Vending Machine
        drinkMachine.PerminatelyDeactivateMachine();

        _context.DrinkMachines.Update(drinkMachine);

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
       
    }
}
