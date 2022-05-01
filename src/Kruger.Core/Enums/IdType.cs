using System;

namespace Kruger.Core.Enums
{
    public enum IdType
    {
        Id,
        Passport
    }
    public static class IdTypeExtensions
    {
        public static string GetString(this IdType me)
        {
            return me switch
            {
                IdType.Id => "Identification",
                IdType.Passport => "Passport",
                _ => throw new NotImplementedException(),
            };
        }
    }
}
