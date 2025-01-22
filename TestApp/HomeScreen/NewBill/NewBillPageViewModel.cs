using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using InventoryDomain.Model;
using InventoryDomain.Repository;

namespace TestApp.HomeScreen.NewBill;

public class NewBillPageViewModel
{
    public int Id { get; set; }
        private string name;

    private string mobile;

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
    public string Mobile
    {
        get => mobile;
        set
        {
            if (mobile != value)
            {
                mobile = value;
                OnPropertyChanged(nameof(Mobile));
            }
        }
    }
    public int BillAmount { get; set; }
    public ObservableCollection<BillItemModel> BillItems { get; set; } = new ObservableCollection<BillItemModel>();

    public ICommand AddItemCommand { get; }
    public ICommand SubmitBillCommand { get; }


    public IItemRepository ItemRepository;
    public IBillRepository BillRepository;

    public NewBillPageViewModel(IItemRepository ItemRepository, IBillRepository BillRepository)
    {
        AddItemCommand = new Command(OnAddItemAsync);
        SubmitBillCommand = new Command(OnSubmitBill);
        this.ItemRepository = ItemRepository;
        this.BillRepository = BillRepository;

    }


/* Unmerged change from project 'TestApp (net9.0-maccatalyst)'
Before:
    private void OnAddItem()
After:
    private async Task OnAddItemAsync()
*/
    private async void OnAddItemAsync()
    {
        var popup = new AddBillItem();
        var result = await Application.Current.MainPage.ShowPopupAsync(popup) as BillItemModel;

        if (result != null)
        {
            BillItems.Add(result);
        }

        
    }

    private async void OnSubmitBill()
    {
        // Validate and submit the bill to the backend or database
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(mobile))
        {
            Application.Current.MainPage.DisplayAlert("Error", "Please fill all fields correctly.", "OK");
            return;
        }

        var items = new List<BillItem>();
        
        foreach(var billItem in BillItems){
            var billItemModel = new BillItem();
            var item  = await ItemRepository.GetSearchResultAsync(billItem.Name);
            if(item==null){
                billItemModel.OtherItem= billItem.Name;
            }else{
                billItemModel.ItemId=  item.Id;
                item.Quantity-=billItem.Quantity;
                await ItemRepository.UpdateAsync(item);
                billItemModel.OtherItem= item.Name;

            }
            billItemModel.Amount = billItem.Amount;
            billItemModel.Quantity = billItem.Quantity;
            items.Add(billItemModel);

         
        }

        // Create the bill object and save it
        var bill = new Bill
        {
            Id = Id,
            Name = Name,
            Mobile = Mobile,
            BillAmount = items.Sum(x=>x.Amount),
            BillItems = items
        };

        await BillRepository.AddAsync(bill);

        await GenerateBillMessageAndSendAsync(bill);
        // Submit logic (save to DB, etc.)
        Application.Current.MainPage.DisplayAlert("Success", "Bill Submitted Successfully", "OK");
    }


/* Unmerged change from project 'TestApp (net9.0-maccatalyst)'
Before:
    private void GenerateBillMessageAndSend()
After:
    private async Task GenerateBillMessageAndSendAsync()
*/
    private async Task GenerateBillMessageAndSendAsync(Bill bill)
    {
        var message = "Bill Details:\n";

        foreach (var item in BillItems)
        {
            message += $"- {item.Name}: {item.Amount}\n";
        }

        message += $"\nTotal Amount: {BillItems.Sum(i => i.Amount)}";

        var encodedMessage = Uri.EscapeDataString(message);
        var url = $"https://wa.me/{bill.Mobile}?text={encodedMessage}";

        try
        {
            await Launcher.Default.OpenAsync(url);
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Failed to open WhatsApp.", "OK");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

     protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}