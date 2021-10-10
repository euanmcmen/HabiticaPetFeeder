using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public record Food(string Name, string Type, int Quantity)
    {
        string GetFullName => string.IsNullOrEmpty(Type) ? Name : $"{Name}_{Type}";
    }
}
