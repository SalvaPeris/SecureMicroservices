namespace Movies.API.ApiServices
{
    public interface IIdentityApiService
    {
        Task<Dictionary<string, string>> GetUserInfo();
    }
}
