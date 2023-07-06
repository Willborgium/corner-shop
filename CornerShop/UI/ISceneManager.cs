namespace CornerShop.Text.UI
{
    public interface ISceneManager
    {
        void PushScene(IScene Scene);
        void PopScene();
        void SetScene(IScene Scene, bool popAll);
    }
}