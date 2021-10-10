using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public record Pet(string Name, string Type, int FedPoints)
    {
        string GetFullName => $"{Name}_{Type}";
    }
}
