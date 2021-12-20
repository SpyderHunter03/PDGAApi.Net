namespace PDGAApi.Net.Models.Event
{
    public class EventResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public string tournament_id { get; set; }
        public string tournament_name { get; set; }
        public string city { get; set; }
        public string state_prov { get; set; }
        public string country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string @class { get; set; }
        public string tier { get; set; }
        public string status { get; set; }
        public string format { get; set; }
        public string tournament_director { get; set; }
        public string tournament_director_pdga_number { get; set; }
        public string asst_tournament_director { get; set; }
        public string asst_tournament_director_pdga_number { get; set; }
        public string event_email { get; set; }
        public string event_phone { get; set; }
        public string event_url { get; set; }
        public string website_url { get; set; }
        public string registration_url { get; set; }
        public string last_modified { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}