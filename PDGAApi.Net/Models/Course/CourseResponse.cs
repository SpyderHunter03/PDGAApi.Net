namespace PDGAApi.Net.Models.Course
{
    public class CourseResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public string course_id { get; set; }
        public string course_node_nid { get; set; }
        public string course_name { get; set; }
        public string course_type { get; set; }
        public string course_description { get; set; }
        public string distance { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string location_type { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string street2 { get; set; }
        public string state_province { get; set; }
        public string postal_code { get; set; }
        public string state_province_name { get; set; }
        public string country { get; set; }
        public string holes { get; set; }
        public string directions { get; set; }
        public string basket_types { get; set; }
        public string tee_types { get; set; }
        public string total_length_of_course { get; set; }
        public string total_length_of_alternate { get; set; }
        public string number_of_holes_less_than_300 { get; set; }
        public string number_of_holes_between_300_and_400 { get; set; }
        public string number_of_holes_greater_than_400 { get; set; }
        public string camping { get; set; }
        public string facilities { get; set; }
        public string fees { get; set; }
        public string handicap { get; set; }
        public string @private { get; set; }
        public string signage { get; set; }
        public string contact_name { get; set; }
        public string contact_pdga_number { get; set; }
        public string contact_home_number { get; set; }
        public string course_foliage { get; set; }
        public string course_elevation { get; set; }
        public string legacy_course_courseid { get; set; }
        public string year_established { get; set; }
        public string external_link_1_url { get; set; }
        public string external_link_1_title { get; set; }
        public string created { get; set; }
        public string update { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}