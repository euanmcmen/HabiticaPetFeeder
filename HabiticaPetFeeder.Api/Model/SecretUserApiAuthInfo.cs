using HabiticaPetFeeder.Logic.Model;

namespace HabiticaPetFeeder.Api.Model
{
    public class SecretUserApiAuthInfo : UserApiAuthInfo
    {
        public bool UseSecretAuth { get; set; }
    }
}
