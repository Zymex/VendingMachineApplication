using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Exceptions;
public class ItemsQtyOverMaxException : Exception
{
    public ItemsQtyOverMaxException(int qty, int maxQty)
        : base($"{qty} is over the max of {maxQty} snacks.")
    {            
    }
}
