using InventoryDomain.Repository;

namespace TestApp.HomeScreen.AddItem;

public partial class AddItem : ContentPage
{
	public AddItem(IItemRepository itemRepository)
	{
		InitializeComponent();
		BindingContext = new AddItemViewModel(itemRepository, Navigation.PopAsync);
		

	}
}