using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Model.ApiModel.ContentResponse;

public class ContentResponseData
{
    public Dictionary<string, string> pets { get; set; }

    public Dictionary<string, string> premiumPets { get; set; }

    public Dictionary<string, string> specialPets { get; set; }

    public Dictionary<string, string> questPets { get; set; }

    public Dictionary<string, string> wackyPets { get; set; }

    public Dictionary<string, ContentResponsePetInfo> petInfo { get; set; }

    public Dictionary<string, ContentResponseFoodInfo> food { get; set; }
}
