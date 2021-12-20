using PDGAApi.Net.Models.Enum;
using System;

namespace PDGAApi.Net.Models.Player
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PDGANumber { get; set; }
        public string EmailAddress { get; set; }
        public int BirthYear { get; set; }
        public PlayerGender Gender { get; set; }
        public string MembershipStatus { get; set; }
        public DateTime? MembershipExpirationDate { get; set; }
        public PlayerClass Classification { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string Country { get; set; }
        public int? Rating { get; set; }
        public DateTime? RatingEffectiveDate { get; set; }
        public string OfficialStatus { get; set; }
        public DateTime? OfficialExpirationDate { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
