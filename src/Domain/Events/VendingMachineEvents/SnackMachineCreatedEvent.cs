using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Machines;

namespace CleanArchitecture.Domain.Events.MachineEvents;
public class SnackMachineCreatedEvent  : BaseEvent
{
    public SnackMachineCreatedEvent(VendingMachine vendingMachine, List<VendingMachineRow> vendingMachineRows)
    {
        VendingMachine = vendingMachine;
        VendingMachineRows = vendingMachineRows;
    }
    public VendingMachine VendingMachine;
    public List<VendingMachineRow> VendingMachineRows;
}
