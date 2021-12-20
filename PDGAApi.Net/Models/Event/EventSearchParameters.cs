using PDGAApi.Net.Models.Enum;
using PDGAApi.Net.Models.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PDGAApi.Net.Models.Event
{
    public class EventSearchParameters
    {
        public int? TournamentId { get; set; }
        public string EventName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        private string country;
        public string Country
        {
            get => country;

            set
            {
                if (value.Length != 2)
                    throw new ParameterException($"{nameof(Country)} must have only 2 characters");
                country = value;
            }
        }

        private string state;
        public string State
        {
            get => state;

            set
            {
                if(value.Length != 2)
                    throw new ParameterException($"{nameof(State)} must have only 2 characters");
                state = value;
            }
        }

        private string province;
        public string Province
        {
            get => province;

            set
            {
                if (value.Length != 2)
                    throw new ParameterException($"{nameof(Province)} must have only 2 characters");
                province = value;
            }
        }

        public EventTier[] Tiers { get; set; }
        public EventClassification? Classification { get; set; }

        private int? limit = 10;
        public int? Limit
        {
            get => limit;

            set
            {
                if (value > 200)
                    throw new ParameterException($"{nameof(Limit)} must be less than 200");
                limit = value;
            }
        }

        public int? Offset { get; set; }

        internal Dictionary<string, object> GetQueryParameters()
        {
            var dict = new Dictionary<string, object>();

            if (TournamentId.HasValue) dict.Add("tournament_id", TournamentId.Value);
            if (!string.IsNullOrWhiteSpace(EventName)) dict.Add("event_name", EventName);
            if (StartDate.HasValue) dict.Add("start_date", $"{StartDate.Value:yyyy-MM-dd}");
            if (EndDate.HasValue) dict.Add("end_date", $"{EndDate.Value:yyyy-MM-dd}");
            if (!string.IsNullOrWhiteSpace(Country)) dict.Add("country", Country);
            if (!string.IsNullOrWhiteSpace(State)) dict.Add("state", State);
            if (!string.IsNullOrWhiteSpace(Province)) dict.Add("province", Province);
            if (Tiers != null && Tiers.Length > 0) dict.Add("tier", string.Join(',', Tiers.Select(t => t.GetEventTier())));
            if (Classification.HasValue) dict.Add("classification", Classification.Value.GetEventClassification());
            if (Limit.HasValue) dict.Add("limit", Limit);
            if (Offset.HasValue) dict.Add("offset", Offset);

            return dict;
        }
    }
}
