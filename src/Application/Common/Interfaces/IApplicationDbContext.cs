using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.Items;
using CleanArchitecture.Domain.Entities.Machines;
using CleanArchitecture.Domain.Entities.Network;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{


    DbSet<DrinkMachine> DrinkMachines { get; }

    DbSet<Drink> Drinks { get; }

    DbSet<SnackMachine> SnackMachines { get; }

    DbSet<Snack> Snacks { get; }
    
    DbSet<MachineNetwork> Networks { get; }

    DbSet<VendingMachineRow> MachineRows { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
