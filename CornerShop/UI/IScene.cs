namespace CornerShop.Text.UI
{
    public interface IScene
    {
        SceneState State { get; }

        void Initialize();

        void Uninitialize();

        void Update();

        void Render();
    }
}