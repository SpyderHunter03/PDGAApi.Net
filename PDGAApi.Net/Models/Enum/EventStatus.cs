using System.Collections.Generic;
using System.Linq;

namespace PDGAApi.Net.Models.Enum
{
    public enum EventStatus
    {
        //sanctioned, postponed, cancelled
        Sanctioned,
        Postponed,
        Cancelled
    }

    public static class EventStatusExtensions
    {
        private static readonly Dictionary<EventStatus, string> EventStatusNames = new()
        {
            { EventStatus.Sanctioned, "Sanctioned" },
            { EventStatus.Postponed, "Postponed" },
            { EventStatus.Cancelled, "Cancelled" }
        };

        public static EventStatus GetEventStatus(this string eventStatus) => EventStatusNames.FirstOrDefault(x => x.Value.Equals(eventStatus)).Key;

        public static string GetEventStatus(this EventStatus eventStatus) => EventStatusNames[eventStatus];
    }
}
