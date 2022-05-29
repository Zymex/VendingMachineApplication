using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Items;
public class VendingMachineItem : BaseEntity
{
    public string TypeOfSnack { get; set; }
    public string ItemName { get; set; }
    public decimal ItemPrice { get; set; }
    public string RowNumberId { get; set; }

    public decimal UpdatePrice(decimal price)
    {
        ItemPrice = price;
        return price;
    }
    public VendingMachineItem()
    {

    }
}


