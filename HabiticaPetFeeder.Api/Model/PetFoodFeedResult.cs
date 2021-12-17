using HabiticaPetFeeder.Logic.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Api.Model;

public class PetFoodFeedResult
{
    public List<PetFoodFeed> PetFoodFeeds { get; init; }

    public PetFoodFeedSummary PetFoodFeedSummary { get; init; }
}