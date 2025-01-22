using System.Windows.Input;
using InventoryDomain.Repository;

namespace TestApp.HomeScreen.NewBill;

public partial class NewBill : ContentPage
{
	public ICommand AddItemCommand { get; }

	public NewBill(IItemRepository itemRepository, IBillRepository billRepository)
	{
		InitializeComponent();
		BindingContext = new NewBillPageViewModel(itemRepository, billRepository);
	}
}