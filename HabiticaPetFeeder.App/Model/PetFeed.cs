using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App.Model
{
    public record PetFeed(string PetFullName, string FoodFullName, int FeedQuantity);
}
