using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Machines;

namespace CleanArchitecture.Domain.Entities.Network;
public class MachineNetwork : BaseEntity
{
    public new Guid Id { get; set; }
    public string Name { get; set; }
    public string IPAddress { get; private set; }

    //List of Updates with History - Search by Date Sent
    public List<Update> UpdateHistory { get; set; }

    //Machine List
    public List<VendingMachine> VendingMachines { get; set; }

    //Build our Network IP Address
    public MachineNetwork()
    {
        SetIpAddress();
        UpdateHistory = new List<Update>();
    }
    //Record our Update History.
    public void Record(Update updateToRecord)
    {
        UpdateHistory.Add(updateToRecord);
    }

    //Send our updates from the Machine Network
    public void SendUpdate(List<VendingMachine> machinesToUpdate, Update updateToSend)
    {
        foreach (var machine in machinesToUpdate)
        {
            updateToSend.DateUpdatedSent = DateTime.Now;
            machine.Update = updateToSend;

        }

        Record(updateToSend);
    }

    //174.246.128.43 Example format
    public void SetIpAddress()
    {
        var random = new Random();
        IPAddress = $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";

    }

}

