using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.VendingMachines.Commands.UpdateVendingMachine.UpdateSnackMachine;
public record RenameSnackMachineCommand(Guid Id, string Name) : IRequest;
public class UpdateSnackMachineCommandHandler : IRequestHandler<RenameSnackMachineCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateSnackMachineCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(RenameSnackMachineCommand request, CancellationToken cancellationToken)
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
