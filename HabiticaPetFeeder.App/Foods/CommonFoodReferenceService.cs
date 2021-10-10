namespace HabiticaPetFeeder.App
{
    public interface ICommonFoodsReferenceService
    {
        string GetPreferringTypeForFood(string name);
    }

    public class CommonFoodReferenceService : ICommonFoodsReferenceService
    {
        private readonly ICommonFoodReferenceData commonFoodReferenceData;

        public CommonFoodReferenceService(ICommonFoodReferenceData commonFoodReferenceData)
        {
            this.commonFoodReferenceData = commonFoodReferenceData;
        }

        public string GetPreferringTypeForFood(string name)
        {
            return commonFoodReferenceData.CommonFoodPreferencesByName[name];
        }
    }
}
