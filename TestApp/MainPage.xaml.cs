using TestApp.HomeScreen;

namespace TestApp;

public partial class MainPage : ContentPage
{
	HomePage _homePage;
	public MainPage(HomePage homePage)
	{
		_homePage = homePage;
		InitializeComponent();
	}
	async void Authenticate(object sender, EventArgs e){
		await Navigation.PushAsync(_homePage);
	}
}

