using PDGAApi.Net.Models.Base;
using PDGAApi.Net.Models.Course;
using PDGAApi.Net.Models.Enum;
using PDGAApi.Net.Models.Event;
using PDGAApi.Net.Models.Exception;
using PDGAApi.Net.Models.Player;
using PDGAApi.Net.Models.PlayerStatistics;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDGAApi.Net
{
    public class PDGA : IDisposable
    {
        private const string PDGA_API_URL = "https://api.pdga.com";
        private const string PDGA_SERVICES_ENDPOINT = PDGA_API_URL + "/services/json";

        private readonly string _userName;
        private readonly string _password;
        
        private RestClient client;
        private string token;

        public PDGA(PDGARestConfig config) : this(config?.UserName ?? throw new ArgumentNullException(nameof(config)), config.Password) { }

        public PDGA(string userName, string password)
        {
            _userName = userName ?? throw new ArgumentNullException(nameof(userName));
            _password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public async Task<IEnumerable<Player>> PlayerSearchAsync(PlayerSearchParameters playerSearchParameters)
        {
            if (playerSearchParameters == null) throw new ArgumentNullException(nameof(playerSearchParameters));

            if (!HasCookies()) await Login();

            var request = new RestRequest("/players", DataFormat.Json);
            request.AddHeader("Content-Type", "application/json");

            foreach(var p in playerSearchParameters.GetQueryParameters())
                request.AddParameter(p.Key, p.Value);

            var response = await client.GetAsync<PlayerInformationResponse>(request);

            if (!string.IsNullOrWhiteSpace(response.errmsg)) throw new APIException(response);

            if (response.status != 0) return new List<Player>();

            var players = response.players.Select(p => new Player
            {
                FirstName = p.first_name,
                LastName = p.last_name,
                PDGANumber = int.Parse(p.pdga_number),
                EmailAddress = p.email_address,
                BirthYear = int.Parse(p.birth_year),
                Gender = p.gender.Equals("M") ? PlayerGender.Male : PlayerGender.Female,
                MembershipStatus = p.membership_status,
                MembershipExpirationDate = DateTime.Parse(p.membership_expiration_date),
                Classification = p.classification.Equals("P") ? PlayerClass.Professional : PlayerClass.Amatuer,
                City = p.city,
                StateProv = p.state_prov,
                Country = p.country,
                Rating = p.rating == null ? null : int.Parse(p.rating),
                RatingEffectiveDate = p.rating_effective_date == null ? null : DateTime.Parse(p.rating_effective_date),
                OfficialStatus = p.official_status,
                OfficialExpirationDate = p.official_expiration_date == null ? null : DateTime.Parse(p.official_expiration_date),
                LastModified = DateTime.Parse(p.last_modified)
            });

            return players;
        }

        public async Task<IEnumerable<PlayerStatistics>> PlayerStatisticsAsync(PlayerStatisticsParameters playerStatisticsParameters)
        {
            if (playerStatisticsParameters == null) throw new ArgumentNullException(nameof(playerStatisticsParameters));

            if (!HasCookies()) await Login();

            var request = new RestRequest("/player-statistics", DataFormat.Json);
            request.AddHeader("Content-Type", "application/json");

            foreach (var p in playerStatisticsParameters.GetQueryParameters())
                request.AddParameter(p.Key, p.Value);

            var response = await client.GetAsync<PlayerStatisticsResponse>(request);

            if (!string.IsNullOrWhiteSpace(response.errmsg)) throw new APIException(response);

            if (response.status != 0) return new List<PlayerStatistics>();

            var players = response.players.Select(p => new PlayerStatistics
            {
                FirstName = p.first_name,
                LastName = p.last_name,
                PDGANumber = int.Parse(p.pdga_number),
                Rating = int.Parse(p.rating),
                Year = int.Parse(p.year),
                Classification = p.@class.Equals("P") ? PlayerClass.Professional : PlayerClass.Amatuer,
                Gender = p.gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ? PlayerGender.Male : PlayerGender.Female,
                DivisionName = p.division_name.GetPlayerDivisionName(),
                DivisionCode = p.division_code.GetPlayerDivisionCode(),
                Country = p.country,
                StateProv = p.state_prov,
                Tournaments = int.Parse(p.tournaments),
                RatingRoundsUsed = int.Parse(p.rating_rounds_used),
                Points = int.Parse(p.points),
                LastModified = DateTime.Parse(p.last_modified)
            });

            return players;
        }

        public async Task<IEnumerable<Event>> EventSearchAsync(EventSearchParameters eventSearchParameters)
        {
            if (eventSearchParameters == null) throw new ArgumentNullException(nameof(eventSearchParameters));

            if (!HasCookies()) await Login();

            var request = new RestRequest("/event", DataFormat.Json);
            request.AddHeader("Content-Type", "application/json");

            foreach (var p in eventSearchParameters.GetQueryParameters())
                request.AddParameter(p.Key, p.Value);

            var response = await client.GetAsync<EventSearchResponse>(request);

            if (!string.IsNullOrWhiteSpace(response.errmsg)) throw new APIException(response);

            if (response.status != 0) return new List<Event>();

            var events = response.events.Select(p => new Event
            {
                TournamentId = int.Parse(p.tournament_id),
                TournamentName = p.tournament_name,
                City = p.city,
                StateProv = p.state_prov,
                Country = p.country,
                Latitude = double.TryParse(p.latitude, out var l) ? l : null,
                Longitude = double.TryParse(p.longitude, out var o) ? o : null,
                StartDate = DateTime.Parse(p.start_date),
                EndDate = DateTime.Parse(p.end_date),
                Classification = p.@class.GetEventClassification(),
                Tier = p.tier.GetEventTier(),
                Status = p.status.GetEventStatus(),
                Format = p.format.GetEventFormat(),
                TournamentDirector = p.tournament_director,
                TournamentDirectorPDGANumber = int.TryParse(p.tournament_director_pdga_number, out var t) ? t : null,
                AsstTournamentDirector = p.asst_tournament_director,
                AsstTournamentDirectorPDGANumber = int.TryParse(p.asst_tournament_director_pdga_number, out var asst) ? asst : null,
                EventEmail = p.event_email,
                EventPhone = p.event_phone,
                EventURL = p.event_url,
                WebsiteURL = p.website_url,
                RegistrationURL = p.registration_url,
                LastModified = DateTime.Parse(p.last_modified)
            });

            return events;
        }

        public async Task<IEnumerable<Course>> CourseSearchAsync(CourseSearchParameters courseSearchParameters)
        {
            if (courseSearchParameters == null) throw new ArgumentNullException(nameof(courseSearchParameters));

            if (!HasCookies()) await Login();

            var request = new RestRequest("/course", DataFormat.Json);
            request.AddHeader("Content-Type", "application/json");

            foreach (var p in courseSearchParameters.GetQueryParameters())
                request.AddParameter(p.Key, p.Value);

            var response = await client.GetAsync<CourseSearchResponse>(request);

            if (!string.IsNullOrWhiteSpace(response.errmsg)) throw new APIException(response);

            if (response.status != 0) return new List<Course>();

            var courses = response.courses.Select(p => new Course
            {
                CourseId = int.Parse(p.course_id),
                CourseNodeNid = int.Parse(p.course_node_nid),
                CourseName = p.course_name,
                CourseType = p.course_type,
                CourseDescription = "",
                Distance = int.TryParse(p.distance, out var d) ? d : null,
                Latitude = double.TryParse(p.latitude, out var lt) ? lt : null,
                Longitude = double.TryParse(p.longitude, out var lg) ? lg : null,
                LocationType = p.location_type,
                City = p.city,
                Street = p.street,
                Street2 = p.street2,
                StateProvince = p.state_province,
                PostalCode = int.TryParse(p.postal_code, out var pc) ? pc : null,
                StateProvinceName = p.state_province_name,
                Country = p.country,
                Holes = int.TryParse(p.holes, out var h) ? h : null,
                Directions = p.directions,
                BasketTypes = p.basket_types,
                TeeTypes = p.tee_types,
                TotalLengthOfCourse = int.TryParse(p.total_length_of_course, out var le) ? le : null,
                TotalLengthOfAlternate = int.TryParse(p.total_length_of_alternate, out var a) ? a : null,
                NumberOfHolesLessThan300 = int.TryParse(p.number_of_holes_less_than_300, out var th) ? th : null,
                NumberOfHolesBetween300And400 = int.TryParse(p.number_of_holes_between_300_and_400, out var bt) ? bt : null,
                NumberOfHolesGreaterThan400 = int.TryParse(p.number_of_holes_greater_than_400, out var fo) ? fo : null,
                Camping = p?.camping?.Equals("Yes", StringComparison.OrdinalIgnoreCase),
                Facilities = p?.facilities?.Equals("Yes", StringComparison.OrdinalIgnoreCase),
                Fees = p?.fees?.Equals("Yes", StringComparison.OrdinalIgnoreCase),
                Handicap = p?.handicap?.Equals("Yes", StringComparison.OrdinalIgnoreCase),
                @Private = p?.@private?.Equals("Yes", StringComparison.OrdinalIgnoreCase),
                Signage = p?.signage?.Equals("Yes", StringComparison.OrdinalIgnoreCase),
                ContactName = p.contact_name,
                ContactPdgaNumber = int.TryParse(p.contact_pdga_number, out var c) ? c : null,
                ContactHomeNumber = p.contact_home_number,
                CourseFoliage = int.TryParse(p.course_foliage, out var f) ? f : null,
                CourseElevation = int.TryParse(p.course_elevation, out var ce) ? ce : null,
                LegacyCourseCourseId = int.TryParse(p.legacy_course_courseid, out var l) ? l : null,
                YearEstablished = int.TryParse(p.year_established, out var y) ? y : null,
                ExternalLink1Url = p.external_link_1_url,
                ExternalLink1Title = p.external_link_1_title,
                Created = DateTime.Parse(p.created),
                Update = DateTime.Parse(p.update)
            });

            return courses;
        }

        private async Task<LoginResponse> Login()
        {
            var request = new RestRequest("user/login", DataFormat.Json);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new LoginBody { username = _userName, password = _password });

            var response = await client.PostAsync<LoginResponse>(request);

            if (response != null && !string.IsNullOrWhiteSpace(response.token))
                token = response.token;

            return response;
        }

        private async Task<bool> Logout()
        {
            var request = new RestRequest("user/logout", DataFormat.Json);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-CSRF-Token", token);

            var response = await client.PostAsync<JsonArray>(request);

            return response.All(x => (x as bool?) ?? false);
        }

        private bool HasCookies()
        {
            if (client == null)
                InitializeClient();

            var cookies = client.CookieContainer.GetCookies(new Uri(PDGA_API_URL));
            return cookies.Count > 0;
        }

        private void InitializeClient()
        {
            client = new RestClient(PDGA_SERVICES_ENDPOINT)
            {
                CookieContainer = new System.Net.CookieContainer()
            };
        }

        public void Dispose()
        {
            try
            {
                Logout().Wait();
            }
            catch
            { 
                // Eat the exception
            }

            client = null;

            GC.SuppressFinalize(this);
        }
    }
}
