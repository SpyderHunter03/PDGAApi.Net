using System;
using System.Collections.Generic;
using System.Linq;

namespace PDGAApi.Net.Models.Enum
{
    public enum EventFormat
    {
        Singles,
        Doubles,
        Team,
        Points,
        Unknown
    }

    public static class EventFormatExtensions
    {
        private static readonly Dictionary<EventFormat, string> EventFormatNames = new()
        {
            { EventFormat.Singles, "Singles" },
            { EventFormat.Doubles, "Doubles" },
            { EventFormat.Team, "Team" },
            { EventFormat.Points, "Points" },
            { EventFormat.Unknown, "Unknown" },
        };

        public static EventFormat GetEventFormat(this string eventFormat) => EventFormatNames.FirstOrDefault(x => x.Value.Equals(eventFormat, StringComparison.OrdinalIgnoreCase)).Key;

        public static string GetEventFormat(this EventFormat eventFormat) => EventFormatNames[eventFormat];
    }
}
