namespace CornerShop.Text.UI
{
    public interface IGame
    {
        bool IsRunning { get; }
        void Update();
        void Render();
    }
}