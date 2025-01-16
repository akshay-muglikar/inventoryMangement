using System;
using System.Collections.ObjectModel;

namespace TestApp.HomeScreen;

public class HomePageItemModel
{
    public ObservableCollection<HomePageItem> HomePageItems { get; set; }

    public HomePageItemModel()
    {
        HomePageItems = new ObservableCollection<HomePageItem>
        {
            new HomePageItem
            {
                Title = "Card 1",
                Description = "This is the first card.",
                ImageUrl = "https://via.placeholder.com/150",
                ClickCommand = new Command(() => OnCardClicked("Card 1"))
            },
            new HomePageItem
            {
                Title = "Card 2",
                Description = "This is the second card.",
                ImageUrl = "https://via.placeholder.com/150",
                ClickCommand = new Command(() => OnCardClicked("Card 2"))
            }
            // Add more cards here
        };
    }

    private void OnCardClicked(string cardTitle)
    {
        Application.Current.MainPage.DisplayAlert("Card Clicked", $"You clicked {cardTitle}!", "OK");
    }
}

