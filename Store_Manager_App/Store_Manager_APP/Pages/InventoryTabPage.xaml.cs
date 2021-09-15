using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Manager_APP.Data;
using Store_Manager_APP.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Store_Manager_APP.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryTabPage : ContentPage
    {
        public InventoryTabPage()
        {
            InitializeComponent();
        }

        public async void OnItemAddClicked(object sender, EventArgs eventArgs)
        {
           await Navigation.PushAsync(new AddItemPage
           {
               BindingContext = new Inventory()
           });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            InventoryClient inventoryClient = new InventoryClient();
            List<Inventory> inventory = await inventoryClient.GetInventoryAsync();
            var trends = new ObservableCollection<Inventory>(inventory);
            InventoryList.ItemsSource = trends;


        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ItemDetailsPage
                {
                    BindingContext = e.SelectedItem as Inventory
                });
            }
        }
    }
}