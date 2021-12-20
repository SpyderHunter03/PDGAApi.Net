using PDGAApi.Net.Models.Base;
using System.Collections.Generic;

namespace PDGAApi.Net.Models.Event
{
    public class EventSearchResponse : BaseResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public List<EventResponse> events { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
