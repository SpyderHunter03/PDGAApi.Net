using PDGAApi.Net.Models.Base;
using System.Collections.Generic;

namespace PDGAApi.Net.Models.Player
{
    public class PlayerInformationResponse : BaseResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public List<PlayerResponse> players { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
