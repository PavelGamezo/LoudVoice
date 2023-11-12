using LoudVoice.Application.Common.Services;

namespace LoudVoice.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
