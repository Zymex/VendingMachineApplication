using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Items;
using CleanArchitecture.Domain.Entities.Machines;
using NUnit.Framework;

namespace Entities.UnitTests;
public class VendingMachineRowUnitTest
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void VendItemTest()
    {
        VendingMachine v = new();
        v.MachineRows = new List<VendingMachineRow>();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       var vRow = new VendingMachineRow('A', 30, "Doritoes", 2.50M);
        v.MachineRows.Add(vRow);
        vRow.CreateMachineRowItems();
        vRow.SetUpItems(30, vRow.SnackType , vRow.SnackName, vRow.SnackPrice);
        v.Vend(10, 30.00M, vRow);
    }
}
