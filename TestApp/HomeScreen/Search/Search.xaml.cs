using System.Collections.ObjectModel;
using InventoryDomain.Model;
using InventoryDomain.Repository;

namespace TestApp.HomeScreen.Search;

public partial class Search : ContentPage
{
	private ObservableCollection<Item> orderInfo;
	private IItemRepository _itemRepository;
	 public ObservableCollection<Item> OrderInfoCollection
    {
        get { return orderInfo; }
        set { this.orderInfo = value; }
    }

	public Search(IItemRepository itemRepository, IBillRepository billRepository)
	{
		_itemRepository= itemRepository;
		orderInfo = new ObservableCollection<Item>();

		InitializeComponent();
		BindingContext = this;
		GetAllItemsAsync();
	}


    private async Task GetAllItemsAsync()
    {
		var items= await _itemRepository.GetAsync();
		items.ForEach(item=> OrderInfoCollection.Add(item));
    }
}