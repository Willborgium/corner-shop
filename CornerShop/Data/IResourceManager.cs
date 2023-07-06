namespace CornerShop.Text.Data
{
    public interface IResourceManager
    {
        TResource Get<TResource>(string key);
        void Remove(string key);
        void Set<TResource>(string key, TResource resource);
    }
}