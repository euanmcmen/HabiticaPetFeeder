using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App.Model
{
    //public record Food(string FullName, string Name, string Type, int Quantity);

    public record Food(string FullName, string Name, string Type, DecreasingQuantity Quantity);

    //public class Food
    //{
    //    public string FullName { get; set; }

    //    public string Name { get; set; }

    //    public string Type { get; set; }

    //    public int Quantity { get; set; }

    //    public Food(string fullName, string name, string type, int quantity)
    //    {
    //        FullName = fullName;
    //        Name = name;
    //        Type = type;
    //        Quantity = quantity;
    //    }
    //}
}
