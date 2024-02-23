using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CollectionViewGroupBug;

public class Animal
{
    public string Name { get; set; }
}

public class AnimalGroup : ObservableCollection<Animal>
{
    public string GroupName { get; private set; }

    public AnimalGroup(string name, IList<Animal> animals) : base(animals)
    {
        GroupName = name;
    }
}
