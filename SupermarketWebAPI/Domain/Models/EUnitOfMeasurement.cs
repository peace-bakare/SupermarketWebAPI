using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketWebAPI.Domain.Models
{
    //An attribute is a way to define metadata over classes, interfaces, properties and other components of the C# language.
    public enum EUnitOfMeasurement : byte
    {
        [Description("UN")]
        Unity = 1,

        [Description("MG")]
        Milligram = 2,

        [Description("G")]
        Gram = 3,

        [Description("KG")]
        Kilogram = 4,

        [Description("L")]
        Litre = 5
    }
}
