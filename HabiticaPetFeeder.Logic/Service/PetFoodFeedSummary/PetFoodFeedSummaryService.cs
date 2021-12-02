using HabiticaPetFeeder.Logic.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HabiticaPetFeeder.Logic.Service.PetFoodFeedSummary
{
    public class PetFoodFeedSummaryService : IPetFoodFeedSummaryService
    {
        private ILogger<PetFoodFeedSummaryService> logger;

        public PetFoodFeedSummaryService(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<PetFoodFeedSummaryService>();
        }

        public int GetNumberOfPetsFed(IEnumerable<PetFoodFeed> petFoodFeeds)
        {
            return petFoodFeeds
                .Select(petFoodFeed => petFoodFeed.PetFullName)
                .Distinct()
                .Count();
        }

        public int GetNumberOfFoodsFed(IEnumerable<PetFoodFeed> petFoodFeeds)
        {
            return petFoodFeeds.Sum(x => x.FeedQuantity);
        }

        public int GetNumberOfSatisfiedPets(IEnumerable<PetFoodFeed> petFoodFeeds)
        {
            return petFoodFeeds
                .Where(x => x.WillSatisfyPet)
                .Select(petFoodFeed => petFoodFeed.PetFullName)
                .Distinct()
                .Count();
        }
    }
}
