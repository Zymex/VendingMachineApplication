using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Machines;

namespace CleanArchitecture.Domain.Events.VendingMachineRowEvents;
public class VendingMachineRowCreatedEvent : BaseEvent
{
    public VendingMachineRowCreatedEvent(VendingMachineRow vendingMachineRow)
    {
        VendingMachineRow = vendingMachineRow;
    }
    public VendingMachineRow VendingMachineRow { get; set; }
}
