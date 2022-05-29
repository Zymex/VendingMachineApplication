using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.Machines;
using CleanArchitecture.Domain.Events.MachineEvents;
using MediatR;

namespace CleanArchitecture.Application.VendingMachines.Commands.CreateVendingMachine.CreateSnackMachine;

public record CreateSnackMachineCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

}
public class CreateVendingMachineCommandHandler : IRequestHandler<CreateSnackMachineCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    public CreateVendingMachineCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateSnackMachineCommand request, CancellationToken cancellationToken)
    {
        var entity = new SnackMachine
        {
            Id = request.Id,
            Name = request.Name,
            Location = request.Location
        };
        entity.AddDomainEvent(new SnackMachineCreatedEvent(entity, entity.MachineRows));

        _context.SnackMachines.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
