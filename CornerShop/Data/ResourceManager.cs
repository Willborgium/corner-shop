namespace CornerShop.Text.Data
{
    public class ResourceManager : IResourceManager
    {
        public ResourceManager()
        {
            _resources = new Dictionary<string, object>();
        }

        public TResource Get<TResource>(string key)
        {
            return (TResource)_resources[key];
        }

        public void Set<TResource>(string key, TResource resource)
        {
            _resources[key] = resource;
        }

        public void Remove(string key)
        {
            _resources.Remove(key);
        }

        private readonly IDictionary<string, object> _resources;
    }
}