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
public record MoveSnackMachineCommand(Guid Id, string Name) : IRequest;
public class MoveSnackMachineCommandHandler : IRequestHandler<MoveSnackMachineCommand>
{
    private readonly IApplicationDbContext _context;
    public MoveSnackMachineCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(MoveSnackMachineCommand request, CancellationToken cancellationToken)
    {
        var snackMachine = await _context.SnackMachines

            .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

        if (snackMachine == null)
        {
            throw new NotFoundException(nameof(snackMachine));
        }

        snackMachine.RenameMachine(request.Name);

        _context.SnackMachines.Update(snackMachine);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
