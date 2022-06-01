using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Items;
using MediatR;

namespace CleanArchitecture.Application.VendingMachineRows.Commands;
public record CreateVendingMachineRowCommand : IRequest<int>
{
    public int Id { get; set; }
    public int RowCapacity { get; set; }
    public List<VendingMachineItem>? MachineItems { get; set; }
}
public class CreateVendingMachineCommandHandler : IRequestHandler<CreateVendingMachineRowCommand, int>

{
    public Task<int> Handle(CreateVendingMachineRowCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
