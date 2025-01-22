using System;

namespace TestApp.HomeScreen.AddItem;

using System.ComponentModel;
using System.Windows.Input;
using InventoryDomain.Model;
using InventoryDomain.Repository;

public class AddItemViewModel : INotifyPropertyChanged
{
    private string name;
    private string category;
    private string car;
    private int quantity;
    private string type;
    private string description;

    public string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }

    public string Category
    {
        get => category;
        set
        {
            if (category != value)
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
    }

    public string Car
    {
        get => car;
        set
        {
            if (car != value)
            {
                car = value;
                OnPropertyChanged(nameof(Car));
            }
        }
    }

    public int Quantity
    {
        get => quantity;
        set
        {
            if (quantity != value)
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }

    public string Type
    {
        get => type;
        set
        {
            if (type != value)
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
    }

    public string Description
    {
        get => description;
        set
        {
            if (description != value)
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    public ICommand SubmitCommand { get; }
    public IItemRepository _itemRepository;
    public Func<Task<Page>> successPage;
    public AddItemViewModel(IItemRepository itemRepository, Func<Task<Page>> popAsync)
    {
        SubmitCommand = new Command(OnSubmit);
        _itemRepository = itemRepository;
        successPage = popAsync;
    }

    private async void OnSubmit()
    {
        Item item  = new Item(){
            Name = name,
            Car = car,
            Quantity = quantity,
            Category = category,
            Type= type,
            Description = description
        };
        await _itemRepository.AddAsync(item);
        // Handle form submission logic
        await successPage();
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
