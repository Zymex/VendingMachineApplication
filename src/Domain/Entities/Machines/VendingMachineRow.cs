using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Items;

namespace CleanArchitecture.Domain.Entities.Machines;
public class VendingMachineRow : BaseEntity
{   
    public char RowNumberId { get; set; }
    public int ItemsToList { get; set; }
    public string SnackName { get; set; }
    public decimal SnackPrice { get; set; }
    public string SnackType { get; set; }
    public List<VendingMachineItem> MachineItems { get; set; }
    public VendingMachineRow(char rowId, int itemsToList, string snackName, decimal snackPrice)
    {
        
        SnackPrice = snackPrice;
        SnackName = snackName;
        RowNumberId = rowId;
        MachineItems = new List<VendingMachineItem>();
        ItemsToList = itemsToList;

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
    public void CreateMachineRowItems()
    {
        //String to define row id char
        var oldAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        //Build new list & set capacity
        List<VendingMachineItem> machineRowItems = new List<VendingMachineItem>();

        // Creates and initializes a new ArrayList.
        ArrayList alphabet = new ArrayList();
        foreach (var c in oldAlphabet)
        {
            alphabet.Add(c);
        }

        // Create a fixed-size wrapper around the ArrayList.
        ArrayList idAlphabetLetters = ArrayList.FixedSize(alphabet);        

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
                v.RowNumberId = RowNumberId.ToString() + i;
            }
            MachineItems.Add(v);
        }
    }

    
    /// <summary>
    /// Whats required to vend an item
    /// We need to be on an item row. 
    /// RowID
    /// We need a price and a qty to buy
    /// After we vend. The items are removed from the array
    /// Handle error checking if the qty is 0
    /// 
    /// </summary>


   //We need this
    public string ReturnRowId()
    {
        return RowNumberId.ToString();
    }

}
