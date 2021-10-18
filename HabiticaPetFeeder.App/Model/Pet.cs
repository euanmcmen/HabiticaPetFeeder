using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App.Model
{
    public record Pet(string FullName, string Type, IncreasingQuantity FedPoints, bool IsBasicPet);
}
