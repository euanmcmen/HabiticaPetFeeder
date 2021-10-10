namespace HabiticaPetFeeder.App
{
    public interface ICommonFoodsReferenceService
    {
        string GetPreferringTypeForFood(string name);
    }

    public class CommonFoodsReferenceService : ICommonFoodsReferenceService
    {
        private readonly ICommonFoodReferenceData commonFoodReferenceData;

        public CommonFoodsReferenceService(ICommonFoodReferenceData commonFoodReferenceData)
        {
            this.commonFoodReferenceData = commonFoodReferenceData;
        }

        public string GetPreferringTypeForFood(string name)
        {
            return commonFoodReferenceData.CommonFoodPreferencesByName[name];
        }
    }
}
