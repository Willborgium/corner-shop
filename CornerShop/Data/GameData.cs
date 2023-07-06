namespace CornerShop.Text.Data
{
    public class Material
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ShopMaterial
    {
        public Guid MaterialId { get; set; }
        public int Quantity { get; set; }
    }

    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public ICollection<ShopMaterial> Materials { get; set; }
    }

    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class GameData
    {
        public Guid Id { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}