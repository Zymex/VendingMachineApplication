using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Items;

namespace CleanArchitecture.Domain.Entities.Machines;
public class VendingMachineRow : BaseEntity
{   
    public string RowNumberId { get; set; }
    public List<VendingMachineItem> MachineItems { get; set; }
    public VendingMachineRow()
    {

        MachineItems = new List<VendingMachineItem>();


    }

    //Set Vending Machine Item ID's, ect A1, B1, C1 
    public void SetVendingMachineItemId()
    {
        int i = 1;
        foreach (var snack in MachineItems)
        {
            snack.RowNumberId = ReturnRowId() + i++;
        }
    }
    public void CreateMachineRows(int rowCount)
    {
        //String to define row id char
        var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        //Build new list & set capacity
        List<VendingMachineRow> machineRows = new List<VendingMachineRow>();
        machineRows.Capacity = rowCount;

        alphabet.ToList().Capacity = rowCount;

        //Foreach loop to set the RowNumberId
        foreach (var c in alphabet)
        {
            VendingMachineRow v = new VendingMachineRow()
            {
                RowNumberId = c.ToString()
            };
        }
    }
    public void SetUpItems(int itemCount, string typeOfSnack, string itemName, decimal price)
    {
        //Setup our items on the row.
        for (int i = 1; i < itemCount; i++)
        {
            //New Item to add
            VendingMachineItem v = new();
            {
                v.ItemPrice = price;
                v.TypeOfSnack = typeOfSnack;
                v.ItemName = itemName;
                v.RowNumberId = RowNumberId + i;
            }
            MachineItems.Add(v);
        }
    }
    //We need this
    public string ReturnRowId()
    {
        return RowNumberId;
    }
}
