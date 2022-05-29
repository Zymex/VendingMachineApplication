using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Update 
{
    public Guid Id { get; set; }
    public Update()
    {
        DateCreated = DateTime.Now;
    }
    public string UpdateName { get; set; }
    public string TypeOfUpdate { get; set; }
    public string PurposeOfUpdate { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdatedSent { get; set; }

}
