using PDGAApi.Net.Models.Base;
using System.Collections.Generic;

namespace PDGAApi.Net.Models.PlayerStatistics
{
    public class PlayerStatisticsResponse : BaseResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public List<PlayerStatsResponse> players { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
