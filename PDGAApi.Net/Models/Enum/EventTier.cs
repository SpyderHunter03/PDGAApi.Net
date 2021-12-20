using System.Collections.Generic;
using System.Linq;

namespace PDGAApi.Net.Models.Enum
{
    public enum EventTier
    {
        L,
        NT,
        M,
        A,
        B,
        C,
        XA,
        XB,
        XC
    }

    public static class EventTierExtensions
    {
        private static readonly Dictionary<EventTier, string> EventTierNames = new()
        {
            { EventTier.L, "L" },
            { EventTier.NT, "NT" },
            { EventTier.M, "M" },
            { EventTier.A, "A" },
            { EventTier.B, "B" },
            { EventTier.C, "C" },
            { EventTier.XA, "XA" },
            { EventTier.XB, "XB" },
            { EventTier.XC, "XC" }
        };

        public static EventTier GetEventTier(this string eventTier) => EventTierNames.FirstOrDefault(x => x.Value.Equals(eventTier)).Key;

        public static string GetEventTier(this EventTier eventTier) => EventTierNames[eventTier];
    }
}
