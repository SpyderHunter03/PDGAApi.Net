using PDGAApi.Net.Models.Enum;
using PDGAApi.Net.Models.Exception;
using System;
using System.Collections.Generic;

namespace PDGAApi.Net.Models.PlayerStatistics
{
    public class PlayerStatisticsParameters
    {
        private int? year;
        public int? Year
        {
            get => year;

            set
            {
                if (value > DateTime.UtcNow.Year)
                    throw new ParameterException($"{nameof(Year)} must be less than {DateTime.UtcNow.Year}");
                year = value;
            }
        }

        public PlayerClass? Class { get; set; }
        //TODO: Implement with enum once I know all divisions
        public string DivisionName { get; set; } //public PlayerDivisionName DivisionName { get; set; }
        
        //TODO: Implement with enum once I know all divisions
        private string divisionCode;
        public string DivisionCode //public PlayerDivisionCode DivisionName { get; set; }
        {
            get => divisionCode;

            set
            {
                if (value.Length < 3 || value.Length > 4)
                    throw new ParameterException($"{nameof(DivisionCode)} must have only 3 or 4 characters");
                divisionCode = value;
            }
        }

        private string continent;
        public string Continent
        {
            get => continent;

            set
            {
                if (value.Length != 2)
                    throw new ParameterException($"{nameof(Continent)} must have only 2 characters");
                continent = value;
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

        public PlayerGender? Gender { get; set; }
        public long? PDGANumber { get; set; }
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

            if (Year.HasValue) dict.Add("year", Year.Value);
            if (Class.HasValue) dict.Add("class", (char)Class);
            if (!string.IsNullOrWhiteSpace(DivisionName)) dict.Add("division_name", DivisionName);
            if (!string.IsNullOrWhiteSpace(DivisionCode)) dict.Add("division_code", DivisionCode);
            if (!string.IsNullOrWhiteSpace(Continent)) dict.Add("continent", Continent);
            if (!string.IsNullOrWhiteSpace(Country)) dict.Add("country", Country);
            if (!string.IsNullOrWhiteSpace(StateProvince)) dict.Add("state_prov", StateProvince);
            if (Gender.HasValue) dict.Add("gender", (char)Gender);
            if (PDGANumber.HasValue) dict.Add("pdga_number", PDGANumber);
            if (LastModified.HasValue) dict.Add("last_modified", $"{LastModified.Value:yyyy-MM-dd}");
            if (Limit.HasValue) dict.Add("limit", Limit);
            if (Offset.HasValue) dict.Add("offset", Offset);

            return dict;
        }
    }
}
