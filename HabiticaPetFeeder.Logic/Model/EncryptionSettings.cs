using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Model;

public class EncryptionSettings
{
    public const string AppSettingName = "Encryption";

    public string Secret { get; set; }
}