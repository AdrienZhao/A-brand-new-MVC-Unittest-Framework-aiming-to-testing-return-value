namespace MD.API.MVCUTFramework
{
    public interface IUTHttpContext
    {
        IHttpFakeRequest Request { get; }

        //IHttpFakeResponse Response { get; }
    }
}