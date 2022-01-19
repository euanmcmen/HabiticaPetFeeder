using HabiticaPetFeeder.Logic.Model;
using HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;
using HabiticaPetFeeder.Logic.Model.ApiModel.UserResponse;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service.Interfaces;

public interface IDataService
{
    IEnumerable<Food> GetFoods(UserResponse userResponse, ContentResponse contentResponse);
    IEnumerable<Pet> GetPets(UserResponse userResponse, ContentResponse contentResponse);
}
