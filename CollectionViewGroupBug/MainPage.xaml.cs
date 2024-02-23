using System.Collections.ObjectModel;

namespace CollectionViewGroupBug
{
    public partial class MainPage : ContentPage
    {
        private Animal a_bear = new() { Name = "Asian Black Bear" };
        private Animal a_monkey = new() { Name = "Capuchin Monkey" };

        public ObservableCollection<AnimalGroup> Animals { get; private set; } = [];

        private Command _AddRecord;
        public Command AddRecord
        {
            get
            {
                _AddRecord ??= new Command(() =>
                {
                    Animals[0].Add(a_bear);
                });

                return _AddRecord;
            }
        }

        private Command _RemoveRecord;
        public Command RemoveRecord
        {
            get
            {
                _RemoveRecord ??= new Command(() =>
                {
                    // THIS IS OK
                    //while (Animals[0].Count > 0)
                    //{
                    //    Animals[0].RemoveAt(0);
                    //}

                    // EXCEPTION WHEN USE THIS
                    Animals[0].Clear();
                });

                return _RemoveRecord;
            }
        }

        public MainPage()
        {
            InitializeComponent();

            Animals.Add(new AnimalGroup("Bears", new List<Animal>
            {
                a_bear
            }));

            Animals.Add(new AnimalGroup("Monkeys", new List<Animal>
            {
                a_monkey
            }));
        }
    }
}
