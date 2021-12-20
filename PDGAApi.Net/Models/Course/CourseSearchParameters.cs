using PDGAApi.Net.Models.Exception;
using System.Collections.Generic;

namespace PDGAApi.Net.Models.Course
{
    public class CourseSearchParameters
    {
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public int? PostalCode { get; set; }
        public string City { get; set; }
        
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

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

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

            if (CourseId.HasValue) dict.Add("course_id", CourseId.Value);
            if (!string.IsNullOrWhiteSpace(CourseName)) dict.Add("course_name", CourseName);
            if (!string.IsNullOrWhiteSpace(City)) dict.Add("city", City);
            if (!string.IsNullOrWhiteSpace(Country)) dict.Add("country", Country);
            if (!string.IsNullOrWhiteSpace(StateProvince)) dict.Add("state_prov", StateProvince);
            if (Latitude.HasValue) dict.Add("latitude", Latitude.Value);
            if (Longitude.HasValue) dict.Add("longitude", Longitude.Value);
            if (Limit.HasValue) dict.Add("limit", Limit);
            if (Offset.HasValue) dict.Add("offset", Offset);

            return dict;
        }
    }
}
