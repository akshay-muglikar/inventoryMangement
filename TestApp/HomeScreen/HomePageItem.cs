using System;

namespace TestApp.HomeScreen;

public class HomePageItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Command ClickCommand { get; set; }

}
