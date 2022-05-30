using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.VendingMachines.Commands.UpdateVendingMachine.UpdateDrinkMachine;
public record RenameSnackMachineCommand(Guid Id, string Name) : IRequest;
public class UpdateDrinkMachineCommandHandler : IRequestHandler<RenameSnackMachineCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateDrinkMachineCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(RenameSnackMachineCommand request, CancellationToken cancellationToken)
    {
        var drinkMachine = await _context.DrinkMachines

            .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

        if (drinkMachine == null)
        {
            throw new NotFoundException(nameof(drinkMachine));
        }

        drinkMachine.RenameMachine(request.Name);

        _context.DrinkMachines.Update(drinkMachine);

        await _context.SaveChangesAsync(cancellationToken); 
        
        return Unit.Value;
    }
}
