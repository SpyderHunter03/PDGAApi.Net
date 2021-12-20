using PDGAApi.Net.Models.Enum;
using System;

namespace PDGAApi.Net.Models.PlayerStatistics
{
    public class PlayerStatistics
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PDGANumber { get; set; }
        public int Rating { get; set; }
        public int Year { get; set; }
        public PlayerClass Classification { get; set; }
        public PlayerGender Gender { get; set; }
        public PlayerDivisionName DivisionName { get; set; }
        public PlayerDivisionCode DivisionCode { get; set; }
        public string Country { get; set; }
        public string StateProv { get; set; }
        public int Tournaments { get; set; }
        public int RatingRoundsUsed { get; set; }
        public int Points { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
