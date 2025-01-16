
using TestApp.Domain.Model;
using TestApp.Domain.Repository;
using TestApp.HomeScreen.AddItem;

namespace TestApp.HomeScreen;

public partial class HomePage : ContentPage
{
	public IItemRepository _itemRepository;
	public IBillRepository _billRepository;
	public List<Item> items;
	public HomePage( IItemRepository itemRepository, IBillRepository billRepository)
	{
		InitializeComponent();
		_itemRepository = itemRepository;
		_billRepository = billRepository;
		//BindingContext = new HomePageItemModel();


    }
	async void AddItem(object sender, EventArgs e){
		await Navigation.PushAsync(new TestApp.HomeScreen.AddItem.AddItem(_itemRepository));
	}
	async void NewBill(object sender, EventArgs e){
		await Navigation.PushAsync(new TestApp.HomeScreen.NewBill.NewBill(_itemRepository,_billRepository));
	}
	async void ListItems(object sender, EventArgs e){
		//items = await _itemRepository.GetAsync();
		//BindingContext = new ItemsViewModel(items);

	}
}