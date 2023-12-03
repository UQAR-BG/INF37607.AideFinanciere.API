using System;

namespace INF37607.AideFinanciere.Core.Enums;

// Tout le crédit de cette classe doit revenir à l'utilisateur Josie Thompson
// Repéré à https://stackoverflow.com/questions/3132126/how-do-i-select-a-random-value-from-an-enumeration
public static class RandomExtensions
{   
    public static TEnum NextEnumValue<TEnum>(this Random random)
        where TEnum : struct, Enum
    {
        TEnum[] vals = Enum.GetValues<TEnum>();
        return vals[random.Next(vals.Length)];
    }
}