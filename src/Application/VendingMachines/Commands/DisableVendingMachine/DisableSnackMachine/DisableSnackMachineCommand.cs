using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.VendingMachines.Commands.DisableVendingMachine.DisableSnackMachine;
public record DisableSnackMachineCommand(Guid Id) : IRequest;

public class DisableSnackMachineCommandHandler : IRequestHandler<DisableSnackMachineCommand>
{
    private readonly IApplicationDbContext _context;
    public DisableSnackMachineCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DisableSnackMachineCommand request, CancellationToken cancellationToken)
    {
        var snackMachine = await _context.SnackMachines
            
            .Where(x => x.Id == request.Id)
                 .SingleOrDefaultAsync(cancellationToken);
       
        if (snackMachine == null)
        {
            throw new NotFoundException(nameof(snackMachine));
        }
        //Disable Vending Machine
        snackMachine.PerminatelyDeactivateMachine();

        _context.SnackMachines.Update(snackMachine);

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
       
    }
}
