namespace MD.API.MVCUTFramework
{
    public interface IHttpFakeRequest
    {
        string this[string key] { get; set; }
    }
}