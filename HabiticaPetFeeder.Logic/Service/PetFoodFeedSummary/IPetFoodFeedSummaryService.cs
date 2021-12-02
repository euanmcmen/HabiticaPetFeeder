using HabiticaPetFeeder.Logic.Model;
using System.Collections.Generic;

namespace HabiticaPetFeeder.Logic.Service.PetFoodFeedSummary
{
    public interface IPetFoodFeedSummaryService
    {
        int GetNumberOfFoodsFed(IEnumerable<PetFoodFeed> petFoodFeeds);
        int GetNumberOfPetsFed(IEnumerable<PetFoodFeed> petFoodFeeds);
        int GetNumberOfSatisfiedPets(IEnumerable<PetFoodFeed> petFoodFeeds);
    }
}