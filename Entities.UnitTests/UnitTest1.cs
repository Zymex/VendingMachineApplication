using CleanArchitecture.Domain.Entities.Machines;
using NUnit.Framework;

namespace Entities.UnitTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateVendingMachineRow()
    {
        VendingMachineRow vmr = new VendingMachineRow('A',10);

        vmr.CreateMachineRowItems();
        vmr.SetUpItems(vmr.ItemsToList, "Chips", "Doritos", 2.0m);
        vmr.SetVendingMachineItemId();

        Assert.Pass();
    }
}
