namespace PDGAApi.Net.Models.Base
{
    public abstract class BaseResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public string sessid { get; set; }
        public int status { get; set; }
        public string errmsg { get; set; }
        public string errtitle { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
