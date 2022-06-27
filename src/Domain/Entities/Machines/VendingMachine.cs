using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Items;
using CleanArchitecture.Domain.Entities.Network;

namespace CleanArchitecture.Domain.Entities.Machines;
public class VendingMachine : BaseEntity
{
    public new Guid Id { get; set; }
    public VendingMachine()
    {
        DateCreated = DateTime.Now;
        Activate();
        Update = SetFirstUpdate();
    }
    public int RowsToCreate{ get; set; }
    public string? Name { get; set; }
    public DateTime DateCreated { get; private set; }
    public string? Location { get; set; }
    public bool InService { get; private set; }
    public bool IsPerminatelyDeactivated { get; private set; }


    //Rows of Vending Machine ex - A1, B1, C1, D1
    public List<VendingMachineRow> MachineRows { get; set; }

    //Machine Network the Machine is on
    public MachineNetwork Network { get; private set; }

    //Active, Inactive, Deactivated(Perminately)
    public MachineStatus MachineStatus { get; private set; }

    //Current Machine Update
    public Update Update { get; set; }

    //Create Machine Rows - 
    //Get a count of total rows in machine 
    //Label them based alphanumerically
    //Validate Before
    public void CreateMachineRows(char itemId, int rowCount, string snackName, decimal snackPrice)
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
            VendingMachineRow v = new(itemId, RowsToCreate, snackName, snackPrice)
            {
                RowNumberId = c,
            };
        }
    }

    //Relocate our Machine Elsewhere
    public void MoveMachine(string location)
    {
        if (String.IsNullOrEmpty(location))
        {
            Location = Location;
        }
        else
        {
            Location = location;
        }
    }

    //Rename our Machine
    public void RenameMachine(string name)
    {
        if (String.IsNullOrEmpty(name))
        {
            Name = Name;
        }
        else
        {
            Name = name;
        }
    }


    public string ReturnIPAdress(MachineNetwork machineNetwork)
    {
        return machineNetwork.IPAddress;
    }
    //Create our Initial Update
    public Update SetFirstUpdate()
    {
        Update update = new Update()
        {
            UpdateName = "Initialization of Machine",
            TypeOfUpdate = "Initialization",
            PurposeOfUpdate = "Machine Startup",
            DateUpdatedSent = DateTime.Now
        };
        return update;
    }
    public string Vend(int qty, decimal moneyEntered, VendingMachineRow vendingRow)
    {

        var itemRow = vendingRow.MachineItems;

        if (qty > vendingRow.MachineItems.Count)
        {
            throw new ItemsQtyOverMaxException(qty, MachineRows.Select(i => i.MachineItems).Count());
        }
        //Change to rep
        var machineItemPrice = MachineRows.Select(x => x.SnackPrice).FirstOrDefault();

        var snackName = vendingRow.SnackName;

        var totalCostOfSnacks = machineItemPrice * qty;

        if (moneyEntered < totalCostOfSnacks)
        {
            throw new TotalPriceExceedsMoneyException(totalCostOfSnacks, moneyEntered, snackName);
        }
        List<VendingMachineItem> snacksToRemove = new(qty);
        VendingMachineItem vi = new VendingMachineItem();
        for (int i = 0; i < qty; i++)
        {
            snacksToRemove.Add(vi);
        }
        foreach (var snack in snacksToRemove)
        {
            itemRow.Remove(snack);
        }

       var msg = $"{MachineRows.Select(x => x.MachineItems).Count().ToString()} {MachineRows.Select(x => x.SnackName).FirstOrDefault()} remain";
        return msg;
    }

    //Turn off ONLY if Machine is on a Network
    public void Activate() { MachineStatus = MachineStatus.Active; InService = false; }

    public void Maintenance() { MachineStatus = MachineStatus.Inactive; InService = false; }

    public void PerminatelyDeactivateMachine() 
    { 
        InService = false;
        MachineStatus = MachineStatus.Decativated; IsPerminatelyDeactivated = true; 
    }


}
