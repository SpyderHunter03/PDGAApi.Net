namespace PDGAApi.Net.Models
{
    public class Player
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string pdga_number { get; set; }
        public string email_address { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string membership_status { get; set; }
        public string membership_expiration_date { get; set; }
        public string classification { get; set; }
        public string city { get; set; }
        public string state_prov { get; set; }
        public string country { get; set; }
        public string rating { get; set; }
        public string rating_effective_date { get; set; }
        public string official_status { get; set; }
        public string official_expiration_date { get; set; }
        public string last_modified { get; set; }
    }
}
