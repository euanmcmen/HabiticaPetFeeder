﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.App
{
    public record Food(string FullName, string Name, string Type, int Quantity)
    {
    }
}