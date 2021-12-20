using PDGAApi.Net.Models.Enum;
using PDGAApi.Net.Models.Exception;
using System;
using System.Collections.Generic;

namespace PDGAApi.Net.Models.Player
{
    public class PlayerSearchParameters
    {
        public long? PDGANumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public PlayerClass? Class { get; set; }
        public string City { get; set; }

        private string stateprov;
        public string StateProvince
        {
            get => stateprov;

            set
            {
                if (value.Length < 2 || value.Length > 3)
                    throw new ParameterException($"{nameof(StateProvince)} must have only 2 or 3 characters");
                stateprov = value;
            }
        }

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

        public DateTime? LastModified { get; set; }

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
            
            if (PDGANumber.HasValue) dict.Add("pdga_number", PDGANumber);
            if (!string.IsNullOrWhiteSpace(LastName)) dict.Add("last_name", LastName);
            if (!string.IsNullOrWhiteSpace(FirstName)) dict.Add("first_name", FirstName);
            if (Class.HasValue) dict.Add("class", (char)Class);
            if (!string.IsNullOrWhiteSpace(City)) dict.Add("city", City);
            if (!string.IsNullOrWhiteSpace(StateProvince)) dict.Add("state_prov", StateProvince);
            if (!string.IsNullOrWhiteSpace(Country)) dict.Add("country", Country);
            if (LastModified.HasValue) dict.Add("last_modified", $"{LastModified.Value:yyyy-MM-dd}");
            if (Limit.HasValue) dict.Add("limit", Limit);
            if (Offset.HasValue) dict.Add("offset", Offset);

            return dict;
        }
    }
}
