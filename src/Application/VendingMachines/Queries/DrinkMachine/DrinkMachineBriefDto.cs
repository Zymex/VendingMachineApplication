using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.VendingMachines.Queries.DrinkMachine;
public class SnackMachineBriefDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public int CurrentRowsInMachine { get; set; }
    public string? MachineStatus { get; set; }
    public string? IPAdress { get; set; }


}
