using PDGAApi.Net.Models.Base;
using System.Collections.Generic;

namespace PDGAApi.Net.Models.Course
{
    public class CourseSearchResponse : BaseResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public List<CourseResponse> courses { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
