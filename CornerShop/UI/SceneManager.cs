using static System.Formats.Asn1.AsnWriter;

namespace CornerShop.Text.UI
{
    public class SceneManager : ISceneManager, IGame
    {
        public bool IsRunning => _scenes.Any();

        public SceneManager()
        {
            _scenes = new Stack<IScene>();
        }

        public void PopScene()
        {
            _popScene = true;
        }

        public void PushScene(IScene Scene)
        {
            _nextScene = Scene;
        }

        public void SetScene(IScene Scene, bool popAll)
        {
            _nextScene = Scene;
            _popAllScenes = popAll;
            _popScene = !popAll;
        }

        public IScene? TryTransition()
        {
            if (_popAllScenes == true)
            {
                while (_scenes.TryPeek(out var sceneToPop))
                {
                    sceneToPop.Uninitialize();
                    _scenes.Pop();
                }
            }
            else if (_popScene == true)
            {
                if (_scenes.TryPeek(out var sceneToPop))
                {
                    sceneToPop.Uninitialize();
                    _scenes.Pop();
                }
            }

            _popAllScenes = null;
            _popScene = null;

            if (_nextScene != null)
            {
                if (_nextScene.State == SceneState.Uninitialized)
                {
                    _nextScene.Initialize();
                }

                _scenes.Push(_nextScene);
                _nextScene = null;
            }

            _scenes.TryPeek(out var result);

            return result;
        }

        public void Update()
        {
            var scene = TryTransition();

            scene?.Update();
        }

        public void Render()
        {
            var scene = TryTransition();

            scene?.Render();
        }

        private readonly Stack<IScene> _scenes;

        private IScene? _nextScene;
        private bool? _popScene;
        private bool? _popAllScenes;
    }
}