using Eshop.Database.Services.Interfaces;

namespace Eshop.Database.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}