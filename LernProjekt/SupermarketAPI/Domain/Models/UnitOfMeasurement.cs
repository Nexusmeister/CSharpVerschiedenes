using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models
{
    public enum UnitOfMeasurement : byte
    {
        [Description("UN")]
        Unity = 1,

        [Description("MG")]
        Milligramm = 2,

        [Description("G")]
        Gramm = 3,

        [Description("KG")]
        Kilogramm = 4,

        [Description("L")]
        Liter = 5
    }
}
