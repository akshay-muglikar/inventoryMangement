using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TestApp.Domain.Model;
using TestApp.Domain.Repository;

namespace TestApp.HomeScreen;

public class ItemsViewModel 
{
    public ObservableCollection<Item> Items { get; set; }
    public ItemsViewModel(){}

    public ItemsViewModel(List<Item> items){
        Items = new ObservableCollection<Item>(items);
    }

}