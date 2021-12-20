using PDGAApi.Net.Models.Enum;
using System;

namespace PDGAApi.Net.Models.Event
{
    public class Event
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EventClassification Classification { get; set; }
        public EventTier Tier { get; set; }
        public EventStatus Status { get; set; }
        public EventFormat Format { get; set; }
        public string TournamentDirector { get; set; }
        public int? TournamentDirectorPDGANumber { get; set; }
        public string AsstTournamentDirector { get; set; }
        public int? AsstTournamentDirectorPDGANumber { get; set; }
        public string EventEmail { get; set; }
        public string EventPhone { get; set; }
        public string EventURL { get; set; }
        public string WebsiteURL { get; set; }
        public string RegistrationURL { get; set; }
        public DateTime LastModified { get; set; }
    }
}
