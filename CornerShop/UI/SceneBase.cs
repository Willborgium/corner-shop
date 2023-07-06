namespace CornerShop.Text.UI
{
    public abstract class SceneBase : IScene
    {
        protected readonly ISceneManager _sceneManager;

        public SceneState State { get; private set; }

        protected SceneBase(ISceneManager SceneManager)
        {
            _sceneManager = SceneManager;
        }

        public virtual void Update() { }

        public virtual void Render() { }

        protected string Prompt(string question, bool clearScreen, params string[] options)
        {
            while (true)
            {
                if (clearScreen)
                {
                    Console.Clear();
                }

                Console.WriteLine(question);

                var input = Console.ReadLine();

                if (options?.Any() != true)
                {
                    return input;
                }
                else if (options.Contains(input))
                {
                    return input;
                }
                else
                {
                    return input;
                }
            }
        }

        public virtual void Initialize()
        {
            State = SceneState.Initialized;
        }

        public virtual void Uninitialize()
        {
            State = SceneState.Uninitialized;
        }
    }
}