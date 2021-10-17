using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App.Model
{
    //public record Pet(string FullName, string Name, string Type, int FedPoints, bool IsBasicPet);

    public record Pet(string FullName, string Name, string Type, IncreasingQuantity FedPoints, bool IsBasicPet);

    //public class Pet
    //{
    //    public Pet(string fullName, string name, string type, int fedPoints)
    //    {
    //        FullName = fullName;
    //        Name = name;
    //        Type = type;
    //        FedPoints = fedPoints;
    //    }

    //    public string FullName { get; set; }

    //    public string Name { get; set; }

    //    public string Type { get; set; }

    //    public int FedPoints { get; set; }
    //}
}
