using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Exceptions;
public class TotalPriceExceedsMoneyException : Exception
{
    public TotalPriceExceedsMoneyException(decimal totalPrice, decimal moneyEntered, string snackName)
    : base($"The total for the {snackName} are ${totalPrice}, you only have ${moneyEntered}")
    {
    }
}
