
using CommunityToolkit.Maui.Views;
using System;
using TestApp.Domain.Model;
namespace TestApp.HomeScreen.NewBill;

public partial class AddBillItem : Popup  
{
	public AddBillItem()
	{
		InitializeComponent();
	}

	private void OnAddItemClicked(object sender, EventArgs e)
	{
		
		// Create a new BillItem and pass it back
		var newItem = new BillItemModel
		{
			Name = ItemNameEntry.Text,
			Amount = int.Parse(ItemAmountEntry.Text),
			Quantity = int.Parse(ItemQuantity.Text)
		};

		Close(newItem); // Return the BillItem object to the parent page
	}

	private void OnCancelClicked(object sender, EventArgs e)
	{
		Close(null); // Close without returning a value
	}
}