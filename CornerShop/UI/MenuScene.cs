namespace CornerShop.Text.UI
{
    public abstract class MenuScene : SceneBase
    {
        protected string BackLabel { get; set; }

        protected MenuScene(string title, ISceneManager SceneManager)
            : base(SceneManager)
        {
            _options = new List<(string, Action)>();
            _labels = new List<string>();
            _title = title;
            BackLabel = "Back";
        }

        public override void Initialize()
        {
            if (!string.IsNullOrWhiteSpace(BackLabel))
            {
                AddOption(BackLabel, () => _sceneManager.PopScene());
            }

            base.Initialize();
        }

        public override void Update()
        {
            if (string.IsNullOrWhiteSpace(_input))
            {
                return;
            }

            if (!int.TryParse(_input, out var index))
            {
                return;
            }

            var option = _options.ElementAtOrDefault(index - 1);

            option.Item2?.Invoke();

            base.Update();
        }

        public override void Render()
        {
            Console.Clear();

            Console.WriteLine($">> {_title} <<");
            Console.WriteLine();

            if (_labels.Any())
            {
                foreach (var label in _labels)
                {
                    Console.WriteLine(label);
                }

                Console.WriteLine();
            }

            var index = 1;

            foreach (var option in _options)
            {
                Console.WriteLine($"{index} - {option.Item1}");

                index++;
            }

            Console.WriteLine();

            Console.WriteLine("Enter your choice");

            _input = Console.ReadLine();
        }

        protected void AddOption(string label, Action action) => _options.Add((label, action));
        protected void AddLabel(string label) => _labels.Add(label);
        protected void RemoveOption(string label)
        {
            var option = _options.FirstOrDefault(o => o.Item1 == label);
            _options.Remove(option);
        }

        private readonly string _title;
        private readonly ICollection<(string, Action)> _options;
        private readonly ICollection<string> _labels;
        private string? _input;
    }
}