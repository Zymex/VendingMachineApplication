  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Events.MachineEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.VendingMachines.EventHandlers;
public class SnackMachineCreatedEventHandler : INotificationHandler<SnackMachineCreatedEvent>
{
    private readonly ILogger<SnackMachineCreatedEventHandler> _logger;
    public SnackMachineCreatedEventHandler(ILogger<SnackMachineCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SnackMachineCreatedEvent notification, CancellationToken cancellationToken)
    {
        //Set InService = false
        //True if MachineNetwork != null
        //This serves as a test of the working spacebar. After 2 weeks it has finally been fixed.  I have to get used to using the spacebar again. IT feeels weird.!

        notification.VendingMachine.Activate();

        //Send first update
        notification.VendingMachine.Update =
            notification.VendingMachine.SetFirstUpdate();
           
      
        _logger.LogInformation($"Snack Machine {notification.VendingMachine.Name} has been created");
        return Task.CompletedTask;
    }
}

