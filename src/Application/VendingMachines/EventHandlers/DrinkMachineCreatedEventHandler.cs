using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Events.MachineEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.VendingMachines.EventHandlers;
public class DrinkMachineCreatedEventHandler : INotificationHandler<DrinkMachineCreatedEvent>
{
    private readonly ILogger<DrinkMachineCreatedEventHandler> _logger;
    public DrinkMachineCreatedEventHandler(ILogger<DrinkMachineCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DrinkMachineCreatedEvent notification, CancellationToken cancellationToken)
    {
        //Set InService = false
        //True if MachineNetwork != null
        notification.VendingMachine.Activate();

        //Send first update
        notification.VendingMachine.Update =
            notification.VendingMachine.SetFirstUpdate();
           
      
        _logger.LogInformation($"Vending Machine {notification.VendingMachine.Name} has been created");
        return Task.CompletedTask;
    }
}

