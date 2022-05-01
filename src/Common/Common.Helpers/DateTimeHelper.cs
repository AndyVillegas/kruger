using Common.Helpers.Interfaces;
using System;

namespace Common.Helpers
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTime Now => DateTime.Now;
    }
}
