using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Items;

namespace CleanArchitecture.Domain.Events.MachineItemEvents;

public class VendingMachineItemCreatedEvent : BaseEvent
{
    public VendingMachineItemCreatedEvent(VendingMachineItem vendingMachineItem)
    {
        VendingMachineItem = vendingMachineItem;
    }
    public VendingMachineItem VendingMachineItem { get; set; }
}
