namespace WebAPI.Interfaces
{
    public interface ICacheService
    {
        string GetItem(string key);

        void SetItem(string key, string value);
    }
}
