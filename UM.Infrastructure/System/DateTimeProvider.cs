using UM.SharedKernel.Interfaces;

namespace UM.Infrastructure.System
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
