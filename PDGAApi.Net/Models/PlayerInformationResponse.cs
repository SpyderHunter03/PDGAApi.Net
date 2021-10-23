using System.Collections.Generic;

namespace PDGAApi.Net.Models
{
    public class PlayerInformationResponse
    {
        public string sessid { get; set; }
        public int status { get; set; }
        public List<Player> players { get; set; }
    }
}
