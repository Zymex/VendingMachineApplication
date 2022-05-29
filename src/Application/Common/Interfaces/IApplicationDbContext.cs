using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.Items;
using CleanArchitecture.Domain.Entities.Machines;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<DrinkMachine> DrinkMachines { get; }

    DbSet<Drink> Drinks { get; }

    DbSet<SnackMachine> SnackMachines { get; }

    DbSet<Snack> Snacks { get; }
    
    DbSet<MachineNetwork> Networks { get; }

    DbSet<VendingMachineRow> MachineRows { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
