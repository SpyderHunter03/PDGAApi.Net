namespace PDGAApi.Net.Models.Enum
{
    public enum EventClassification
    {
        Pro,
        Am,
        ProAm
    }

    public static class EventClassificationExtensions
    {
        public static EventClassification GetEventClassification(this string eventClassification)
        {
            return eventClassification switch
            {
                "Pro" => EventClassification.Pro,
                "Am" => EventClassification.Am,
                "Pro-Am" => EventClassification.ProAm,

                _ => throw new System.NotImplementedException()
            };
        }

        public static string GetEventClassification(this EventClassification eventClassification)
        {
            return eventClassification switch
            {
                EventClassification.Pro => "Pro",
                EventClassification.Am => "Am",
                EventClassification.ProAm => "Pro-Am",
                
                _ => throw new System.NotImplementedException(),
            };
        }
    }
}