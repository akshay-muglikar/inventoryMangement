using System.Collections.ObjectModel;
using System.Threading.Tasks;
using InventoryDomain.Model;
using InventoryDomain.Repository;

namespace TestApp.HomeScreen;

public partial class BillHistory : ContentPage
{
	private ObservableCollection<Bill> orderInfo;
	private IBillRepository _billRepository;
	 public ObservableCollection<Bill> OrderInfoCollection
    {
        get { return orderInfo; }
        set { this.orderInfo = value; }
    }
	public BillHistory(IItemRepository itemRepository, IBillRepository billRepository)
	{
		_billRepository=billRepository;
		orderInfo = new ObservableCollection<Bill>();
		InitializeComponent();
		GetBillHistory();
		BindingContext = this;
	}

    private async Task GetBillHistory()
    {
        var bills = await _billRepository.GetAsync();
		bills.ForEach(bill=>
			OrderInfoCollection.Add(bill));
    }
}