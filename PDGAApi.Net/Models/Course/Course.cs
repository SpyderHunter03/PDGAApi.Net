using System;

namespace PDGAApi.Net.Models.Course
{
    public class Course
    {
        public int CourseId { get; set; }
        public int CourseNodeNid { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }
        public string CourseDescription { get; set; }
        public int? Distance { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string LocationType { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string StateProvince { get; set; }
        public int? PostalCode { get; set; }
        public string StateProvinceName { get; set; }
        public string Country { get; set; }
        public int? Holes { get; set; }
        public string Directions { get; set; }
        public string BasketTypes { get; set; }
        public string TeeTypes { get; set; }
        public int? TotalLengthOfCourse { get; set; }
        public int? TotalLengthOfAlternate { get; set; }
        public int? NumberOfHolesLessThan300 { get; set; }
        public int? NumberOfHolesBetween300And400 { get; set; }
        public int? NumberOfHolesGreaterThan400 { get; set; }
        public bool? Camping { get; set; }
        public bool? Facilities { get; set; }
        public bool? Fees { get; set; }
        public bool? Handicap { get; set; }
        public bool? @Private { get; set; }
        public bool? Signage { get; set; }
        public string ContactName { get; set; }
        public int? ContactPdgaNumber { get; set; }
        public string ContactHomeNumber { get; set; }
        public int? CourseFoliage { get; set; }
        public int? CourseElevation { get; set; }
        public int? LegacyCourseCourseId { get; set; }
        public int? YearEstablished { get; set; }
        public string ExternalLink1Url { get; set; }
        public string ExternalLink1Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
    }
}
